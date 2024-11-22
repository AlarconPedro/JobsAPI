using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContaspagar
{
    public int CtpCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public DateTime? CtpData { get; set; }

    public DateTime? CtpDatavencimento { get; set; }

    public decimal? CtpValor { get; set; }

    public string? CtpSituacao { get; set; }

    public string? CtpHistorico { get; set; }

    public string? CtpTipomovimento { get; set; }

    public int? CtpCodigomovimento { get; set; }

    public int? CtpParcela { get; set; }

    public string? CtpPrevisao { get; set; }

    public string? CtpObservacao { get; set; }

    public int? CcoCodigo { get; set; }

    public int? CtpTotalparcela { get; set; }

    public string? CtpSituacaoautorizacao { get; set; }

    public int? UsuCodigo { get; set; }

    public string? CtpNumdoc { get; set; }

    public virtual TbCentroconta? CcoCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbPlanodeconta? PlcCodigoNavigation { get; set; }

    public virtual ICollection<TbContaspagariten> TbContaspagaritens { get; set; } = new List<TbContaspagariten>();
}
