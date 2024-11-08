using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContacorrentelanc
{
    public int CclCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? CtcCodigo { get; set; }

    public string? CclHistorico { get; set; }

    public DateOnly? CclData { get; set; }

    public decimal? CclValor { get; set; }

    public string? CclTipo { get; set; }

    public string? CclDocumento { get; set; }

    public string? CclConciliado { get; set; }

    public string? CclTipomovimento { get; set; }

    public int? CclCodigomovimento { get; set; }

    public string? CclDescricao { get; set; }

    public string? CclPendente { get; set; }

    public virtual TbContacorrente? CtcCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbContacorrentelanciten> TbContacorrentelancitens { get; set; } = new List<TbContacorrentelanciten>();
}
