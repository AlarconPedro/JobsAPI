using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbContaspagarFinanceiro
{
    public int CTP_CODIGO { get; set; }

    public int? EMP_CODIGO { get; set; }

    public int? PES_CODIGO { get; set; }

    public int? PLC_CODIGO { get; set; }

    public string? CTP_DATA { get; set; }

    public string? CTP_DATAVENCIMENTO { get; set; }

    public decimal? CTP_VALOR { get; set; }

    public string? CTP_SITUACAO { get; set; }

    public string? CTP_HISTORICO { get; set; }

    public string? CTP_TIPOMOVIMENTO { get; set; }

    public int? CTP_CODIGOMOVIMENTO { get; set; }

    public int? CTP_PARCELA { get; set; }

    public string? CTP_PREVISAO { get; set; }

    public string? CTP_OBSERVACAO { get; set; }

    public int? CCO_CODIGO { get; set; }

    public int? CTP_TOTALPARCELA { get; set; }

    public string? CTP_SITUACAOAUTORIZACAO{ get; set; }

    public int? USU_CODIGO { get; set; }

    public string? CTP_NUMDOC { get; set; }
}
