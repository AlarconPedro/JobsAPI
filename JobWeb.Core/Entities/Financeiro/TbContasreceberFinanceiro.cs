using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbContasreceberFinanceiro
{
    public int CTR_CODIGO { get; set; }

    public int? EMP_CODIGO { get; set; }

    public int? PES_CODIGO { get; set; }

    public int? PLC_CODIGO { get; set; }

    public int? CNT_CODIGO { get; set; }

    public string? CTR_DATA { get; set; }

    public string? CTR_DATAVENCIMENTO { get; set; }

    public decimal? CTR_VALOR { get; set; }

    public string? CTR_SITUACAO { get; set; }

    public string? CTR_HISTORICO { get; set; }

    public string? CTR_NOSSONUMERO { get; set; }

    public string? CTR_BOLETOIMPRESSO { get; set; }

    public string? CTR_NUMERONF { get; set; }

    public int? CTR_PARCELA { get; set; }

    public string? CTR_PREVISAO { get; set; }

    public string? CTR_OBSERVACAO { get; set; }

    public string? CTR_PERIODOINICIO { get; set; }

    public string? CTR_PERIODOFIM { get; set; }

    public string? CTR_BOLETO { get; set; }

    public string? CTR_RECIBO { get; set; }

    public string? CTR_DUPLICATA { get; set; }

    public int? CCO_CODIGO { get; set; }

    public string? CTR_TIPOMOVIMENTO { get; set; }

    public int? CTR_CODIGOMOVIMENTO { get; set; }

    public string? CTR_SITUACAOAUTORIZACAO { get; set; }

    public int? USU_CODIGO { get; set; }

    public string? CTR_SEMREGISTRO { get; set; }

    public string? CTR_DATAVENCIMENTOBASE { get; set; }

    public string? CTR_NUMDOC { get; set; }

    public int? CTR_NUMRECIBO { get; set; }
}
