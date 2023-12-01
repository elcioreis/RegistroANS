using RegistroANS.Tools;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace RegistroANS.Models.RPE;


//[XmlRoot("Operadora")]
[XmlType(TypeName = "operadora")]
public class RPE_Operadora
{
    [XmlIgnore]
    private string _cnpjOperadora { get; set; } = null!;
    [XmlIgnore]
    private string _registroANS { get; set; } = null!;

    [XmlElement(ElementName = "registroANS")]
    public string RegistroANS
    {
        get
        {
            return this._registroANS;
        }
        set
        {
            // Retira qualquer caractere não numérico do parâmetro e coloca os dígitos na variável registro
            var registro = Regex.Replace(value, "[^0-9]+", "");

            // Se a variável tiver qualquer tamanho diferente de 06 não aceita a informação
            if (registro.Length != 6)
                this._registroANS = new string('#', 6);
            else
                this._registroANS = registro;
        }
    }

    [XmlElement(ElementName = "cnpjOperadora")]
    public string CnpjOperadora
    {
        get
        {
            return this._cnpjOperadora;
        }
        set
        {
            if (Validator.CNPJ(value))
                this._cnpjOperadora = value;
            else
                this._cnpjOperadora = new String('#', 14);
        }
    }

    public RPE_Solicitacao solicitacao { get; set; } = null!;
}
