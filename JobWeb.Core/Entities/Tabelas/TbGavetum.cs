using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbGavetum
{
    public int GavCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public DateOnly? GavData { get; set; }

    public decimal? GavValor { get; set; }

    public string? GavObservacao { get; set; }

    public string? GavConciliado { get; set; }

    public string? GavTipomovimento { get; set; }

    public int? GavCodigomovimento { get; set; }

    public string? GavDescricao { get; set; }

    public string? GavTipo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }
}
