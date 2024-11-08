using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbProgcomercial
{
    public int PrcCodigo { get; set; }

    public string? PrcTipo { get; set; }

    public int? PrcOrdem { get; set; }

    public DateOnly? PrcDatainicial { get; set; }

    public DateOnly? PrcDatafinal { get; set; }

    public string? PrcHorainicial { get; set; }

    public string? PrcHorafinal { get; set; }

    public int? PrcInsdiarias { get; set; }

    public int? PrcTotalins { get; set; }

    public string? PrcSegunda { get; set; }

    public string? PrcTerca { get; set; }

    public string? PrcQuarta { get; set; }

    public string? PrcQuinta { get; set; }

    public string? PrcSexta { get; set; }

    public string? PrcSabado { get; set; }

    public string? PrcDomingo { get; set; }

    public string? PrcPo { get; set; }

    public string? PrcPares { get; set; }

    public string? PrcImpares { get; set; }

    public string? PrcOcultablocoinvalido { get; set; }

    public int? PrcCodigodispositivo { get; set; }

    public string? PrcTipodispositivo { get; set; }

    public int? PrcOrdemsugerida { get; set; }

    public string? PrcSugeriuordem { get; set; }

    public string? PrcRenauto { get; set; }

    public virtual ICollection<TbHorario> TbHorarios { get; set; } = new List<TbHorario>();
}
