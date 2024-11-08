using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbRateiocontasreceber
{
    public int RcrCodigo { get; set; }

    public int? RatCodigo { get; set; }

    public int? CtrCodigo { get; set; }

    public decimal? RcrPercentual { get; set; }

    public virtual TbContasreceber? CtrCodigoNavigation { get; set; }

    public virtual TbRateio? RatCodigoNavigation { get; set; }
}
