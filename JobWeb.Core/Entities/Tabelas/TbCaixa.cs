using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbCaixa
{
    public int CaiCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public string? CaiStatus { get; set; }

    public DateOnly? CaiDataabertura { get; set; }

    public string? CaiHoraabertura { get; set; }

    public decimal? CaiSaldoinicial { get; set; }

    public DateOnly? CaiDatafechamento { get; set; }

    public string? CaiHorafechamento { get; set; }

    public decimal? CaiSaldofechamento { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbMovimentodecaixa> TbMovimentodecaixas { get; set; } = new List<TbMovimentodecaixa>();
}
