using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbContasreceberitenFinanceiro
{
    public int CRI_CODIGO { get; set; }

    public int? CTR_CODIGO { get; set; }

    public decimal? CRI_JUROS { get; set; }

    public decimal? CRI_MULTA { get; set; }

    public decimal? CRI_DESCONTO { get; set; }

    public decimal? CRI_VALORPAGO { get; set; }

    public string? CRI_DATAPAGO { get; set; }

    public string? CRI_TIPOPAG { get; set; }

    public string? CRI_CONCILIADO { get; set; }

    public string? CRI_HORAPAGO { get; set; }
}
