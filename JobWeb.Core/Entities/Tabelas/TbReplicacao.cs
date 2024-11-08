using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbReplicacao
{
    public int RepCodigo { get; set; }

    public string? RepScript { get; set; }

    public int? RepAlias { get; set; }

    public string? RepAliasPro { get; set; }

    public int? RepIdFilial { get; set; }
}
