using System.Xml.Serialization;

namespace RegistroANS.Models.RPI;

[XmlType(TypeName = "InclusaoPrestador")]
public class RPI_InclusaoPrestador
{
    [XmlIgnore]
    public DateTime dataContratualizacao { get; set; }
    [XmlIgnore]
    public DateTime dataInicioPrestacaoServico { get; set; }

    public RPI_InclusaoPrestador()
    {
        Vinculacao = new RPI_Vinculacao();
    }

    public string Classificacao { get; set; } = null!;
    public string CnpjCpf { get; set; } = null!;
    public string Cnes { get; set; } = null!;
    public string Uf { get; set; } = null!;
    public string CodigoMunicipioIBGE { get; set; } = null!;
    public string RazaoSocial { get; set; } = null!;
    public string RelacaoOperadora { get; set; } = null!;
    public string TipoContratualizacao { get; set; } = null!;
    public string RegistroANSOperadoraIntermediaria { get; set; } = null!;
    public string DataContratualizacao
    {
        get { return this.dataContratualizacao.ToString("dd/MM/yyyy"); }
        set { this.dataContratualizacao = DateTime.Parse(value); }
    }
    public string DataInicioPrestacaoServico
    {
        get { return this.dataInicioPrestacaoServico.ToString("dd/MM/yyyy"); }
        set { this.dataInicioPrestacaoServico = DateTime.Parse(value); }
    }
    public string DisponibilidadeServico { get; set; } = null!;
    public string UrgenciaEmergencia { get; set; } = null!;
    public RPI_Vinculacao Vinculacao { get; set; } = null!;
}
