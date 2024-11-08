using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbTela
{
    public int TelCodigo { get; set; }

    public int TelModulo { get; set; }

    public string? TelDescricao { get; set; }

    public string? TelTipo { get; set; }

    public string? TelClass { get; set; }

    public virtual ICollection<TbDireito> TbDireitos { get; set; } = new List<TbDireito>();
}
