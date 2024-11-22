using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContrato
{
    public int CntCodigo { get; set; }

    public int? CntTipo { get; set; }

    public int? PesCodigo { get; set; }

    public string? CntFaturado { get; set; }

    public string? CntNumero { get; set; }

    public string? CntPi { get; set; }

    public DateTime? CntData { get; set; }

    public DateTime? CntInicio { get; set; }

    public DateTime? CntTermino { get; set; }

    public int? CntQtdinsercao { get; set; }

    public decimal? CntValorinsercao { get; set; }

    public int? CntQtdinsercaototal { get; set; }

    public string? CntDomingo { get; set; }

    public string? CntSegunda { get; set; }

    public string? CntTerca { get; set; }

    public string? CntQuarta { get; set; }

    public string? CntQuinta { get; set; }

    public string? CntSexta { get; set; }

    public string? CntSabado { get; set; }

    public string? CntTipoveiculacao { get; set; }

    public int? CntProposto { get; set; }

    public int? CntRealizado { get; set; }

    public decimal? CntValorcontrato { get; set; }

    public int? EmpCodigo { get; set; }

    public string? CntBoleto { get; set; }

    public string? CntRecibo { get; set; }

    public string? CntDuplicata { get; set; }

    public string? CntObservacao { get; set; }

    public string? CntOculto { get; set; }

    public string? CntSemregistro { get; set; }

    public int? CntCodigocom { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual ICollection<TbComissionadoscontrato> TbComissionadoscontratos { get; set; } = new List<TbComissionadoscontrato>();

    public virtual ICollection<TbContamensalcontrato> TbContamensalcontratos { get; set; } = new List<TbContamensalcontrato>();

    public virtual ICollection<TbContasreceber> TbContasrecebers { get; set; } = new List<TbContasreceber>();
}
