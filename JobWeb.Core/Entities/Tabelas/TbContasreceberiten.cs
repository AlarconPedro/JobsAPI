using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContasreceberiten
{
    public int CriCodigo { get; set; }

    public int? CtrCodigo { get; set; }

    public decimal? CriJuros { get; set; }

    public decimal? CriMulta { get; set; }

    public decimal? CriDesconto { get; set; }

    public decimal? CriValorpago { get; set; }

    public DateTime? CriDatapago { get; set; }

    public string? CriTipopag { get; set; }

    public string? CriConciliado { get; set; }

    public string? CriHorapago { get; set; }

    public virtual TbContasreceber? CtrCodigoNavigation { get; set; }
}
