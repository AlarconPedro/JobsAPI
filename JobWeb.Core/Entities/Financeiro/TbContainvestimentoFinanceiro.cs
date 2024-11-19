using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbContainvestimentoFinanceiro
{
    public int CIN_CODIGO { get; set; }

    public int? EMP_CODIGO { get; set; }

    public int? CTC_CODIGO { get; set; }

    public int? PLC_CODIGO { get; set; }

    public string? CIN_DATA { get; set; }

    public decimal? CIN_VALOR { get; set; }

    public string? CIN_TIPO { get; set; }

    public string? CIN_TIPOMOVIMENTO { get; set; }

    public int? CIN_CODIGOMOVIMENTO { get; set; }

    public string? CIN_DESCRICAO { get; set; }

    public string? CIN_TIPOOPERACAO { get; set; }
}
