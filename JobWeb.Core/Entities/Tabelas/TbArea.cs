using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbArea
{
    public int AreCodigo { get; set; }

    public string? AreNome { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbOrdemServicoIten> TbOrdemServicoItens { get; set; } = new List<TbOrdemServicoIten>();
}
