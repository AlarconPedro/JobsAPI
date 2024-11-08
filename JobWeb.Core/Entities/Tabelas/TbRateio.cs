using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbRateio
{
    public int RatCodigo { get; set; }

    public string? RatDescricao { get; set; }

    public int? EmpCodigo { get; set; }

    public string? RatAlias { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbRateiocontamensalcontrato> TbRateiocontamensalcontratos { get; set; } = new List<TbRateiocontamensalcontrato>();

    public virtual ICollection<TbRateiocontasreceber> TbRateiocontasrecebers { get; set; } = new List<TbRateiocontasreceber>();
}
