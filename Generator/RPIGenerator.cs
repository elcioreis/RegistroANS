using ClosedXML.Excel;
using RegistroANS.Models.RPI;
using System.Xml.Serialization;

namespace RegistroANS.Generator;
internal class RPIGenerator
{
    public RPIGenerator(string origin, string destination = "")
    {
        if (File.Exists(origin))
        {
            Console.WriteLine($"Carregando o arquivo {origin}");
            try
            {
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
                    var inclusao = new RPI_InclusaoPrestador();

                    inclusao.Classificacao = planilha.Cell($"E{i}").Value.ToString();
                    inclusao.CnpjCpf = planilha.Cell($"F{i}").Value.ToString();
                    inclusao.Cnes = planilha.Cell($"G{i}").Value.ToString();
                    inclusao.Uf = planilha.Cell($"H{i}").Value.ToString();
                    inclusao.CodigoMunicipioIBGE = planilha.Cell($"I{i}").Value.ToString();
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
                }

                operadora.Solicitacao = solicitacao;

                if (string.IsNullOrEmpty(destination))
                {
                    destination = "Operadora_" + operadora.RegistroANS + "_" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".rpi";
                }

                // Cria um namespace para a saída
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                // Define o prefixo e namespace como vazio
                ns.Add("", "");

                var serializer = new XmlSerializer(typeof(RPI_Operadora));

                using (var writer = new StreamWriter(destination))
                {
                    // Grava em writer a serialização do objeto operadora utilizando o namespace ns
                    serializer.Serialize(writer, operadora, ns);
                }
                Console.WriteLine($"Arquivo {destination} foi gerado");
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
