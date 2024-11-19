using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbContaspagaritenFinanceiro
{
    public int CPI_CODIGO { get; set; }

    public int? CTP_CODIGO { get; set; }

    public decimal? CPI_JUROS { get; set; }

    public decimal? CPI_MULTA { get; set; }

    public decimal? CPI_DESCONTO { get; set; }

    public decimal? CPI_VALORPAGO { get; set; }

    public string? CPI_DATAPAGO { get; set; }

    public string? CPI_TIPOPAG { get; set; }

    public string? CPI_CONCILIADO { get; set; }

    public string? CPI_HORAPAGO { get; set; }
}
