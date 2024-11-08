using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbAtividade
{
    public int AtiCodigo { get; set; }

    public string AtiNome { get; set; } = null!;

    public int? EmpCodigo { get; set; }

    public int? AtiCodigocom { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }
}
