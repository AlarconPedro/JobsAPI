using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbCentroconta
{
    public int CcoCodigo { get; set; }

    public string? CcoDescricao { get; set; }

    public int? EmpCodigo { get; set; }

    public string? CcoId { get; set; }

    public string? CcoContamae { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbContamensalcontrato> TbContamensalcontratos { get; set; } = new List<TbContamensalcontrato>();

    public virtual ICollection<TbContamensal> TbContamensals { get; set; } = new List<TbContamensal>();

    public virtual ICollection<TbContaspagar> TbContaspagars { get; set; } = new List<TbContaspagar>();

    public virtual ICollection<TbContasreceber> TbContasrecebers { get; set; } = new List<TbContasreceber>();
}
