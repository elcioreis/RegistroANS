using System.Xml.Serialization;

namespace RegistroANS.Models.RPI;
public class RPI_Solicitacao
{
    public RPI_Solicitacao()
    {
        InclusaoPrestador = new List<RPI_InclusaoPrestador>();
    }

    public string NossoNumero { get; set; } = null!;
    public string IsencaoOnus { get; set; } = null!;

    [XmlElement(ElementName = "InclusaoPrestador", Type = typeof(RPI_InclusaoPrestador))]
    public List<RPI_InclusaoPrestador> InclusaoPrestador { get; set; } = null!;
}
