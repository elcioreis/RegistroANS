using System.Xml.Serialization;

namespace RegistroANS.Models.RPI;
public class RPI_Vinculacao
{
    [XmlElement(ElementName = "numeroRegistroPlanoVinculacao")]
    public string NumeroRegistroPlanoVinculacao { get; set; } = null!;

    [XmlElement(ElementName = "codigoPlanoOperadoraVinculacao")]
    public string CodigoPlanoOperadoraVinculacao { get; set; } = null!;
}
