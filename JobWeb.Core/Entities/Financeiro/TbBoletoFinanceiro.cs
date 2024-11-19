using System;
using System.Collections.Generic;

namespace OmegaCloudAPI;

public partial class TbBoletoFinanceiro
{
    public int BOL_CODIGO { get; set; }

    public int? EMP_CODIGO { get; set; }

    public int? PES_CODIGO { get; set; }

    public string? BOL_DATAPROCESSAMENTO { get; set; }

    public int? BOL_NOSSONUMERO { get; set; }

    public int? BOL_CARTEIRA { get; set; }

    public decimal? BOL_VALORDOCUMENTO { get; set; }

    public string? BOL_DATADOCUMENTO { get; set; }

    public string? BOL_DATAABATIMENTO { get; set; }

    public decimal? BOL_VALORABATIMENTO { get; set; }

    public string? BOL_DATAMORAJUROS { get; set; }

    public decimal? BOL_VALORMORAJUROS { get; set; }

    public string? BOL_DATADESCONTO { get; set; }

    public decimal? BOL_VALORDESCONTO { get; set; }

    public decimal? BOL_PERCENTUALMULTA { get; set; }

    public string? BOL_DATAVENDIMENTO { get; set; }

    public string? BOL_DATAPROTESTO { get; set; }

    public string? BOL_GEROUREMESSA { get; set; }

    public string? BOL_DATAREMESSA { get; set; }

    public string? BOL_RETORNO { get; set; }

    public string? BOL_DATARETORNO { get; set; }

    public string? BOL_STATUS { get; set; }

    public string? BOL_DATASTATUS { get; set; }

    public string? BOL_OBS { get; set; }

    public int? BOL_NUMERODOC { get; set; }

    public decimal? BOL_VALORRECEBIDO { get; set; }

    public string? BOL_DATARECEBIMENTO { get; set; }

    public int? CTC_CODIGO { get; set; }

    public int? CCB_CODIGO { get; set; }

    public string? BOL_TIPOMOVIMENTO { get; set; }

    public int? BOL_CODIGOMOVIMENTO { get; set; }

    public string? BOL_STATUSVENCIMENTO { get; set; }
}
