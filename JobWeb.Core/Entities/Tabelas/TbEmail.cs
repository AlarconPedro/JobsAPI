using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbEmail
{
    public int EmaCodigo { get; set; }

    public string? EmaEmailEnvio { get; set; }

    public string? EmaSenha { get; set; }

    public string? EmaSmtp { get; set; }

    public string? EmaPorta { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }
}
