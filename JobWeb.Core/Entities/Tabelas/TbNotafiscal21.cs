using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbNotafiscal21
{
    public int NfiCodigo { get; set; }

    public int? NfiNumero { get; set; }

    public string? NfiMd5 { get; set; }

    public string? NfiStatus { get; set; }

    public DateOnly? NfiData { get; set; }

    public int? CtrCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public string? NfiCfop { get; set; }

    public virtual TbContasreceber? CtrCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }
}
