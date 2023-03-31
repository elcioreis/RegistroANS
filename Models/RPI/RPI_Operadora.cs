using System.Xml.Serialization;

namespace RegistroANS.Models.RPI;


//[XmlRoot("Operadora")]
[XmlType(TypeName = "Operadora")]
public class RPI_Operadora
{
    public string RegistroANS { get; set; } = null!;
    public string CnpjOperadora { get; set; } = null!;
    public RPI_Solicitacao Solicitacao { get; set; } = null!;
}
