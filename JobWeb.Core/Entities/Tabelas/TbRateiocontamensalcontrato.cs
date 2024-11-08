using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbRateiocontamensalcontrato
{
    public int RcmCodigo { get; set; }

    public int? RatCodigo { get; set; }

    public int? CmcCodigo { get; set; }

    public decimal? RcmPercentual { get; set; }

    public virtual TbContamensalcontrato? CmcCodigoNavigation { get; set; }

    public virtual TbRateio? RatCodigoNavigation { get; set; }
}
