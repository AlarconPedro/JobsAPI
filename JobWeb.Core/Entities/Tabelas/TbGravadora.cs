using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbGravadora
{
    public int GraCodigo { get; set; }

    public string? GraNome { get; set; }

    public int? EmpCodigo { get; set; }

    public int? IdFilial { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }
}
