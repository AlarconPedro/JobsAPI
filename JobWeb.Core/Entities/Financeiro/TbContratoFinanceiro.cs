using OmegaCloudAPI.Models.Replicacao;
using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbContratoFinanceiro
{
    public int CNT_CODIGO { get; set; }

    public int? CNT_TIPO { get; set; }

    public int? PES_CODIGO { get; set; }

    public string? CNT_FATURADO { get; set; }

    public string? CNT_NUMERO { get; set; }

    public string? CNT_PI { get; set; }

    public string? CNT_DATA { get; set; }

    public string? CNT_INICIO { get; set; }

    public string? CNT_TERMINO { get; set; }

    public int? CNT_QTDINSERCAO { get; set; }

    public decimal? CNT_VALORINSERCAO { get; set; }

    public int? CNT_QTDINSERCAOTOTAL { get; set; }

    public string? CNT_DOMINGO { get; set; }

    public string? CNT_SEGUNDA { get; set; }

    public string? CNT_TERCA { get; set; }

    public string? CNT_QUARTA { get; set; }

    public string? CNT_QUINTA { get; set; }

    public string? CNT_SEXTA { get; set; }

    public string? CNT_SABADO { get; set; }

    public string? CNT_TIPOVEICULACAO { get; set; }

    public int? CNT_PROPOSTO { get; set; }

    public int? CNT_REALIZADO { get; set; }

    public decimal? CNT_VALORCONTRATO { get; set; }

    public int? EMP_CODIGO { get; set; }

    public string? CNT_BOLETO { get; set; }

    public string? CNT_RECIBO { get; set; }

    public string? CNT_DUPLICATA { get; set; }

    public string? CNT_OBSERVACAO { get; set; }

    public string? CNT_OCULTO { get; set; }

    public string? CNT_SEMREGISTRO { get; set; }

    public int? CNT_CODIGOCOM { get; set; }
}
