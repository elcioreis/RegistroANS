using ClosedXML.Excel;
using RegistroANS.Models.RPI;
using RegistroANS.Tools;
using System.Xml;
using System.Xml.Serialization;

namespace RegistroANS.Generator;
internal class RPIGenerator
{
    const string diretorio = "Saida";
    public RPIGenerator(string origin, string destination = "")
    {
        if (File.Exists(origin))
        {
            Console.WriteLine($"Carregando o arquivo {origin}");
            try
            {
                int exportadas = 0;
                int ignoradas = 0;

                var xls = new XLWorkbook(origin);
                var planilha = xls.Worksheets.First();

                var totalLinhas = planilha.Rows().Count();

                if (totalLinhas < 2)
                {
                    Console.WriteLine("O arquivo deve conter ao menos uma linha cabeçalho e mais uma com o conteúdo");
                    return;
                }

                Console.WriteLine($"Total de {totalLinhas - 1} linhas no arquivo");

                var operadora = new RPI_Operadora();

                operadora.RegistroANS = planilha.Cell("A2").Value.ToString();
                operadora.CnpjOperadora = planilha.Cell("B2").Value.ToString();

                var solicitacao = new RPI_Solicitacao();
                solicitacao.NossoNumero = planilha.Cell("C2").Value.ToString();
                solicitacao.IsencaoOnus = planilha.Cell("D2").Value.ToString();

                for (var i = 2; i <= totalLinhas; i++)
                {
                    //string status = planilha.Cell($"T{i}").Value.ToString().ToLower();
                    //var cell = planilha.Cell($"T{i}").Value;
                    var row = planilha.Row(i);

                    if (!row.IsHidden)
                    {

                        var inclusao = new RPI_InclusaoPrestador();

                        inclusao.Classificacao = planilha.Cell($"E{i}").Value.ToString();
                        inclusao.CnpjCpf = planilha.Cell($"F{i}").Value.ToString();
                        inclusao.Cnes = planilha.Cell($"G{i}").Value.ToString().PadLeft(7, '0');
                        inclusao.Uf = planilha.Cell($"H{i}").Value.ToString();
                        inclusao.CodigoMunicipioIBGE = planilha.Cell($"I{i}").Value.ToString().Substring(0, 6);
                        inclusao.RazaoSocial = planilha.Cell($"J{i}").Value.ToString();
                        inclusao.RelacaoOperadora = planilha.Cell($"K{i}").Value.ToString();
                        inclusao.TipoContratualizacao = planilha.Cell($"L{i}").Value.ToString();
                        inclusao.RegistroANSOperadoraIntermediaria = planilha.Cell($"M{i}").Value.ToString();
                        inclusao.DataContratualizacao = planilha.Cell($"N{i}").Value.ToString();
                        inclusao.DataInicioPrestacaoServico = planilha.Cell($"O{i}").Value.ToString();
                        inclusao.DisponibilidadeServico = planilha.Cell($"P{i}").Value.ToString();
                        inclusao.UrgenciaEmergencia = planilha.Cell($"Q{i}").Value.ToString();
                        inclusao.Vinculacao.NumeroRegistroPlanoVinculacao = planilha.Cell($"R{i}").Value.ToString();
                        inclusao.Vinculacao.CodigoPlanoOperadoraVinculacao = planilha.Cell($"S{i}").Value.ToString();
                        solicitacao.InclusaoPrestador.Add(inclusao);
                        exportadas++;
                    }
                    else
                    {
                        ignoradas++;
                    }
                }

                operadora.solicitacao = solicitacao;

                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                if (string.IsNullOrEmpty(destination))
                {
                    destination = diretorio + "\\" + "C" + operadora.RegistroANS + "_" + DateTime.Now.ToString("yyMMddHHmm") + ".rpi";
                }

                using (var sw = new Utf8StringWriter())
                using (var xw = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true }))
                {
                    xw.WriteStartDocument(true);
                    var ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty);
                    var serializer = new XmlSerializer(typeof(RPI_Operadora));
                    serializer.Serialize(xw, operadora, ns);

                    using (var writer = new StreamWriter(destination))
                    {
                        writer.WriteLine(sw.ToString()
                            .Replace("utf-8", "UTF-8")
                            .Replace("  ", "\t")
                            .Replace(" /", "/"));
                    }
                }

                Console.WriteLine($"Arquivo {destination} foi gerado");

                Console.WriteLine($"Total de {exportadas} linhas exportada");
                Console.WriteLine($"Total de {ignoradas} linhas ignoradas");

            }
            catch (IOException ex)
            {
                Console.WriteLine("Problemas ao tentar gravar o arquivo RPI");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas ao tentar gerar o arquivo RPI");
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine($"Arquivo {origin} não existe");
        }
    }
}
