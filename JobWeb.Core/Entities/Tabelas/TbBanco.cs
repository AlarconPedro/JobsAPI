using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbBanco
{
    public int BanCodigo { get; set; }

    public int? BanNumero { get; set; }

    public string? BanDescricao { get; set; }

    public string? BanLogo { get; set; }

    public string? BanDigito { get; set; }

    public virtual ICollection<TbCheque> TbCheques { get; set; } = new List<TbCheque>();

    public virtual ICollection<TbContacorrente> TbContacorrentes { get; set; } = new List<TbContacorrente>();
}
