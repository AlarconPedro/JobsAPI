using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbDireito
{
    public int DirCodigo { get; set; }

    public int? TelModulo { get; set; }

    public int? UsuCodigo { get; set; }

    public int? TelCodigo { get; set; }

    public int? DirAcesso { get; set; }

    public int? DirIncluir { get; set; }

    public int? DirAlterar { get; set; }

    public int? DirExcluir { get; set; }

    public int? DirRelatorio { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbTela? TbTela { get; set; }

    public virtual TbUsuario? UsuCodigoNavigation { get; set; }
}
