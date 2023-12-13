using ClosedXML.Excel;
using RegistroANS.Models.RPE;
using RegistroANS.Tools;
using System.Xml;
using System.Xml.Serialization;

namespace RegistroANS.Generator;
internal class RPEGenerator
{
    const string diretorio = "Saida";
    public RPEGenerator(string origin, string destination = "")
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

                var operadora = new RPE_Operadora();

                operadora.RegistroANS = planilha.Cell("A2").Value.ToString();
                operadora.CnpjOperadora = planilha.Cell("B2").Value.ToString();

                var solicitacao = new RPE_Solicitacao();

                for (var i = 2; i <= totalLinhas; i++)
                {
                    var row = planilha.Row(i);

                    if (!row.IsHidden)
                    {
                        var identificacao = new RPE_Identificacao();

                        identificacao.CnpjCpf = planilha.Cell($"C{i}").Value.ToString();
                        identificacao.Cnes = planilha.Cell($"D{i}").Value.ToString().PadLeft(7, '0');
                        identificacao.CodigoMunicipioIBGE = planilha.Cell($"E{i}").Value.ToString().Substring(0, 6);

                        var exclusao = new RPE_ExclusaoPrestador();
                        exclusao.Identificacao.Add(identificacao);
                        solicitacao.ExclusaoPrestador.Add(exclusao);
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
                    destination = diretorio + "\\" + "C" + operadora.RegistroANS + "_" + DateTime.Now.ToString("yyMMddHHmm") + ".rpe";
                }

                using (var sw = new Utf8StringWriter())
                using (var xw = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true }))
                {
                    xw.WriteStartDocument(true);
                    var ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty);
                    var serializer = new XmlSerializer(typeof(RPE_Operadora));
                    serializer.Serialize(xw, operadora, ns);

                    using (var writer = new StreamWriter(destination))
                    {
                        writer.WriteLine(sw.ToString()
                            .Replace("utf-8", "UTF-8")
                            .Replace("  ", "\t")
                            .Replace(" /", "/"));
                    }
                }

                Console.WriteLine($"Total de {exportadas} linhas exportada");
                Console.WriteLine($"Total de {ignoradas} linhas ignoradas");

                Console.WriteLine($"Arquivo \"{destination}\" foi gerado");

                var validator = new XMLValidator();

                if (validator.Validate(destination, Enums.RPSTypes.RPE))
                {
                    Console.WriteLine($"Arquivo \"{destination}\" válido conforme arquivo de Schema");
                }
                else
                {
                    Console.WriteLine($"Arquivo \"{destination}\" INVÁLIDO conforme arquivo de Schema");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Problemas ao tentar gravar o arquivo RPE");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas ao tentar gerar o arquivo RPE");
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine($"Arquivo {origin} não existe");
        }
    }
}
