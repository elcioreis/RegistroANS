using System.Xml.Serialization;

namespace RegistroANS.Models.RPI;

[XmlType(TypeName = "InclusaoPrestador")]
public class RPI_InclusaoPrestador
{
    [XmlIgnore]
    private string? cnes { get; set; }
    [XmlIgnore]
    private DateTime? dataContratualizacao { get; set; }
    [XmlIgnore]
    public DateTime? dataInicioPrestacaoServico { get; set; }
    [XmlIgnore]
    private string classificacao { get; set; } = null!;

    public RPI_InclusaoPrestador()
    {
        Vinculacao = new RPI_Vinculacao();
    }

    [XmlElement(ElementName = "classificacao")]
    public string Classificacao
    {
        get
        {
            return this.classificacao;
        }
        set
        {
            if (new[] { "1", "2", "3" }.Contains(value))
                this.classificacao = value;
            else
                this.classificacao = "#";
        }
    }

    [XmlElement(ElementName = "cnpjCpf")]
    public string CnpjCpf { get; set; } = null!;

    [XmlElement(ElementName = "cnes")]
    public string Cnes
    {
        get
        {
            if (!string.IsNullOrEmpty(this.cnes))
            {
                return this.cnes.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        set
        {
            this.cnes = value;
        }
    }

    [XmlElement(ElementName = "uf")]
    public string Uf { get; set; } = null!;

    [XmlElement(ElementName = "codigoMunicipioIBGE")]
    public string CodigoMunicipioIBGE { get; set; } = null!;

    [XmlElement(ElementName = "razaoSocial")]
    public string RazaoSocial { get; set; } = null!;

    [XmlElement(ElementName = "relacaoOperadora")]
    public string RelacaoOperadora { get; set; } = null!;

    [XmlElement(ElementName = "tipoContratualizacao")]
    public string TipoContratualizacao { get; set; } = null!;

    [XmlElement(ElementName = "registroANSOperadoraIntermediaria")]
    public string RegistroANSOperadoraIntermediaria { get; set; } = null!;

    [XmlElement(ElementName = "dataContratualizacao")]
    public string DataContratualizacao
    {
        get
        {
            if (this.dataContratualizacao != null)
            {
#pragma warning disable CS8603 // Possível retorno de referência nula.
                return this.dataContratualizacao?.ToString("dd/MM/yyyy");
#pragma warning restore CS8603 // Possível retorno de referência nula.
            }
            else
            {
                return "";
            }
        }
        set { this.dataContratualizacao = DateTime.Parse(value); }
    }

    [XmlElement(ElementName = "dataInicioPrestacaoServico")]
    public string DataInicioPrestacaoServico
    {
        get
        {
            if (this.dataInicioPrestacaoServico != null)
            {
#pragma warning disable CS8603 // Possível retorno de referência nula.
                return this.dataInicioPrestacaoServico?.ToString("dd/MM/yyyy");
#pragma warning restore CS8603 // Possível retorno de referência nula.
            }
            else
            {
                return "";
            }

        }
        set { this.dataInicioPrestacaoServico = DateTime.Parse(value); }
    }

    [XmlElement(ElementName = "disponibilidadeServico")]
    public string DisponibilidadeServico { get; set; } = null!;

    [XmlElement(ElementName = "urgenciaEmergencia")]
    public string UrgenciaEmergencia { get; set; } = null!;

    [XmlElement(ElementName = "vinculacao")]
    public RPI_Vinculacao Vinculacao { get; set; } = null!;
}
