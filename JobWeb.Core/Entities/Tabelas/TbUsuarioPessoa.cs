using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbUsuarioPessoa
{
    public int UspCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public int? UsuCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbUsuario? UsuCodigoNavigation { get; set; }
}
