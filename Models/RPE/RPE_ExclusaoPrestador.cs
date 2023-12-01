using System.Xml.Serialization;

namespace RegistroANS.Models.RPE;

[XmlType(TypeName = "ExclusaoPrestador")]
public class RPE_ExclusaoPrestador
{
    public RPE_ExclusaoPrestador()
    {
        Identificacao = new List<RPE_Identificacao>();
    }

    [XmlElement(ElementName = "identificacao", Type = typeof(RPE_Identificacao))]
    public List<RPE_Identificacao> Identificacao { get; set; } = null!;
}
