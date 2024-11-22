using JobWeb.Infra.Data.Repositories;
using System;
using System.Collections.Generic;

namespace OmegaCloudAPI;

public partial class TbRateiocontasreceberFinanceiro
{
    public int RCR_CODIGO { get; set; }

    public int? RAT_CODIGO { get; set; }

    public int? CTR_CODIGO { get; set; }

    public decimal? RCR_PERCENTUAL { get; set; }

    public virtual TbContasreceber? CtrCodigoNavigation { get; set; }

    public virtual TbRateio? RatCodigoNavigation { get; set; }
}
