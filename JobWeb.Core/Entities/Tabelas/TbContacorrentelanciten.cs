using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContacorrentelanciten
{
    public int CliCodigo { get; set; }

    public int? CclCodigo { get; set; }

    public DateOnly? CliData { get; set; }

    public decimal? CliValor { get; set; }

    public string? CliDocumento { get; set; }

    public int? CliCodigomovimento { get; set; }

    public string? CliTipomovimento { get; set; }

    public virtual TbContacorrentelanc? CclCodigoNavigation { get; set; }
}
