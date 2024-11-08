using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class AggregatedCounter
{
    public string Key { get; set; } = null!;

    public long Value { get; set; }

    public DateTime? ExpireAt { get; set; }
}
