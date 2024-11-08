using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbChequesmovimentacao
{
    public int CqmCodigo { get; set; }

    public int? CheCodigo { get; set; }

    public DateOnly? CqmData { get; set; }

    public string? CqmObservacao { get; set; }

    public string? CqmConciliado { get; set; }

    public string? CqmTipomovimento { get; set; }

    public int? CqmCodigomovimento { get; set; }

    public int? EmpCodigo { get; set; }

    public string? CqmDescricao { get; set; }

    public string? CqmTipo { get; set; }

    public virtual TbCheque? CheCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }
}
