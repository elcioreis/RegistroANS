using RegistroANS.Models.RPE;
using System.Xml.Serialization;

namespace RegistroANS.Models.RPI;
public class RPE_Solicitacao
{
    public RPE_Solicitacao()
    {
        ExclusaoPrestador = new List<RPE_ExclusaoPrestador>();
    }

    [XmlElement(ElementName = "inclusaoPrestador", Type = typeof(RPE_ExclusaoPrestador))]
    public List<RPE_ExclusaoPrestador> ExclusaoPrestador { get; set; } = null!;
}
