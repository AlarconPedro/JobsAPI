using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbHorario
{
    public int HorCodigo { get; set; }

    public string? HorBreak { get; set; }

    public int PrcCodigo { get; set; }

    public DateOnly? HorData { get; set; }

    public int? HorOrdem { get; set; }

    public string? HorStatus { get; set; }

    public string? HorHortocado { get; set; }

    public string? HorDataeditado { get; set; }

    public virtual TbProgcomercial PrcCodigoNavigation { get; set; } = null!;
}
