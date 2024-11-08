using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContainvestimento
{
    public int CinCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? CtcCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public DateOnly? CinData { get; set; }

    public decimal? CinValor { get; set; }

    public string? CinTipo { get; set; }

    public string? CinTipomovimento { get; set; }

    public int? CinCodigomovimento { get; set; }

    public string? CinDescricao { get; set; }

    public string? CinTipooperacao { get; set; }

    public virtual TbContacorrente? CtcCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPlanodeconta? PlcCodigoNavigation { get; set; }
}
