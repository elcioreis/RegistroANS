using RegistroANS.Tools;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace RegistroANS.Models.RPI;


//[XmlRoot("Operadora")]
[XmlType(TypeName = "Operadora")]
public class RPI_Operadora
{
    [XmlIgnore]
    private string cnpjOperadora { get; set; } = null!;
    [XmlIgnore]
    private string registroANS { get; set; } = null!;

    public string RegistroANS
    {
        get
        {
            return this.registroANS;
        }
        set
        {
            // Se o parâmetro tiver tamanho diferente de 06 não aceita a informação
            if (value.Length != 6)
                this.registroANS = new string('#', 6);

            // Retira qualquer caractere não numérico do parâmetro e coloca os dígitos na variável registro
            var registro = Regex.Replace(value, "[^0-9]+", "");

            // Se a variável tiver qualquer tamanho diferente de 06 não aceita a informação
            if (registro.Length != 6)
                this.registroANS = new string('#', 6);
            else
                this.registroANS = registro;
        }
    }

    public string CnpjOperadora
    {
        get
        {
            return this.cnpjOperadora;
        }
        set
        {
            if (Validator.CNPJ(value))
                this.cnpjOperadora = value;
            else
                this.cnpjOperadora = new String('#', 14);
        }
    }

    public RPI_Solicitacao Solicitacao { get; set; } = null!;
}
