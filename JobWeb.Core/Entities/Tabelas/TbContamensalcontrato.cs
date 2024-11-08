using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContamensalcontrato
{
    public int CmcCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public int? CcoCodigo { get; set; }

    public int? CntCodigo { get; set; }

    public string? CmcTipoperiodo { get; set; }

    public int? CmcDiasperiodo { get; set; }

    public string? CmcTipofaturamento { get; set; }

    public int? CmcDiavencimento { get; set; }

    public int? CmcDiainiciovigencia { get; set; }

    public string? CmcTipovalor { get; set; }

    public decimal? CmcValor { get; set; }

    public decimal? CmcPercentual { get; set; }

    public string? CmcHistorico { get; set; }

    public virtual TbCentroconta? CcoCodigoNavigation { get; set; }

    public virtual TbContrato? CntCodigoNavigation { get; set; }

    public virtual TbPlanodeconta? PlcCodigoNavigation { get; set; }

    public virtual ICollection<TbRateiocontamensalcontrato> TbRateiocontamensalcontratos { get; set; } = new List<TbRateiocontamensalcontrato>();
}
