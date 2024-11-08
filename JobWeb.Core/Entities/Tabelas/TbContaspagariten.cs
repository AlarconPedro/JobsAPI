using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContaspagariten
{
    public int CpiCodigo { get; set; }

    public int? CtpCodigo { get; set; }

    public decimal? CpiJuros { get; set; }

    public decimal? CpiMulta { get; set; }

    public decimal? CpiDesconto { get; set; }

    public decimal? CpiValorpago { get; set; }

    public DateOnly? CpiDatapago { get; set; }

    public string? CpiTipopag { get; set; }

    public string? CpiConciliado { get; set; }

    public string? CpiHorapago { get; set; }

    public virtual TbContaspagar? CtpCodigoNavigation { get; set; }
}
