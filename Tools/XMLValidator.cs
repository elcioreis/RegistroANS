using RegistroANS.Enums;
using System.Xml;
using System.Xml.Schema;

namespace RegistroANS.Tools;
public class XMLValidator
{
    private bool falhou;
    public bool Falhou
    {
        get { return falhou; }
    }

    public bool Validate(string xmlFilename, RPSTypes tipo)
    {
        string schemaFilename = string.Empty;

        switch (tipo)
        {
            case RPSTypes.RPI:
                schemaFilename = @".\Schemas\InclusaoPrestadores.xsd";
                break;
            case RPSTypes.RPA:
                break;
            case RPSTypes.RPE:
                schemaFilename = @".\Schemas\ExclusaoPrestadores.xsd";
                break;
            default:
                break;
        }

        // Define o tipo de validação
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.Schema;
        // Carrega o arquivo de esquema
        XmlSchemaSet schemas = new XmlSchemaSet();
        settings.Schemas = schemas;
        // Quando carregar o eschema, especificar o namespace que ele valida
        // e a localização do arquivo 
        schemas.Add(null, schemaFilename);
        // Especifica o tratamento de evento para os erros de validacao
#pragma warning disable CS8622 // A nulidade de tipos de referência no tipo de parâmetro não corresponde ao delegado de destino (possivelmente devido a atributos de nulidade).
        settings.ValidationEventHandler += ValidationEventHandler;
#pragma warning restore CS8622 // A nulidade de tipos de referência no tipo de parâmetro não corresponde ao delegado de destino (possivelmente devido a atributos de nulidade).
        // cria um leitor para validação
        XmlReader validator = XmlReader.Create(xmlFilename, settings);
        falhou = false;
        try
        {
            // Faz a leitura de todos os dados XML
            while (validator.Read())
            { }
        }
        catch (XmlException err)
        {
            // Um erro ocorre se o documento XML inclui caracteres ilegais
            // ou tags que não estão aninhadas corretamente
            Console.WriteLine("Ocorreu um erro crítico durante a validação XML.");
            Console.WriteLine(err.Message);
            falhou = true;
        }
        finally
        {
            validator.Close();
        }
        return !falhou;
    }

    private void ValidationEventHandler(object sender, ValidationEventArgs args)
    {
        falhou = true;
        // Exibe o erro da validação
        Console.WriteLine("Erros da validação : " + args.Message);
    }
}
