using System.Xml.Serialization;

namespace RegistroANS.Models.RPE;

[XmlType(TypeName = "identificacao")]
public class RPE_Identificacao
{
    [XmlElement(ElementName = "cnpjCpf")]
    public string CnpjCpf { get; set; } = null!;

    [XmlElement(ElementName = "cnes")]
    public string Cnes { get; set; } = null!;

    [XmlElement(ElementName = "codigoMunicipioIBGE")]
    public string CodigoMunicipioIBGE { get; set; } = null!;
}
