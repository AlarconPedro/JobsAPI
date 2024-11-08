using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbCedentecheque
{
    public int CedCodigo { get; set; }

    public string? CedNome { get; set; }

    public string? CedTipopessoa { get; set; }

    public string? CedCpfcnpj { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbCheque> TbCheques { get; set; } = new List<TbCheque>();
}
