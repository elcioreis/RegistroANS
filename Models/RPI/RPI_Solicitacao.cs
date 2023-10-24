using System.Xml.Serialization;

namespace RegistroANS.Models.RPI;
public class RPI_Solicitacao
{
    [XmlIgnore]
    private string isencaoOnus { get; set; } = null!;
    public RPI_Solicitacao()
    {
        InclusaoPrestador = new List<RPI_InclusaoPrestador>();
    }

    public string NossoNumero { get; set; } = null!;
    public string IsencaoOnus
    {
        get
        {
            return this.isencaoOnus;
        }
        set
        {
            if ((value == "S") || (value == "N"))
                this.isencaoOnus = value;
            else
                this.isencaoOnus = "X";
        }
    }

    [XmlElement(ElementName = "InclusaoPrestador", Type = typeof(RPI_InclusaoPrestador))]
    public List<RPI_InclusaoPrestador> InclusaoPrestador { get; set; } = null!;
}
