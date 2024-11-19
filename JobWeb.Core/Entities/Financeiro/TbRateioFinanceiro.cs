using System;
using System.Collections.Generic;

namespace OmegaCloudAPI;

public partial class TbRateioFinanceiro
{
    public int RAT_CODIGO { get; set; }

    public string? RAT_DESCRICAO { get; set; }

    public int? EMP_CODIGO { get; set; }

    public string? RAT_ALIAS { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbRateiocontamensalcontrato> TbRateiocontamensalcontratos { get; set; } = new List<TbRateiocontamensalcontrato>();

    public virtual ICollection<TbRateiocontasreceber> TbRateiocontasrecebers { get; set; } = new List<TbRateiocontasreceber>();
}
