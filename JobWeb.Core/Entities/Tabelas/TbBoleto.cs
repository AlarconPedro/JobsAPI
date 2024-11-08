using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbBoleto
{
    public int BolCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public DateTime? BolDataprocessamento { get; set; }

    public int? BolNossonumero { get; set; }

    public int? BolCarteira { get; set; }

    public decimal? BolValordocumento { get; set; }

    public DateTime? BolDatadocumento { get; set; }

    public DateTime? BolDataabatimento { get; set; }

    public decimal? BolValorabatimento { get; set; }

    public DateTime? BolDatamorajuros { get; set; }

    public decimal? BolValormorajuros { get; set; }

    public DateTime? BolDatadesconto { get; set; }

    public decimal? BolValordesconto { get; set; }

    public decimal? BolPercentualmulta { get; set; }

    public DateTime? BolDatavendimento { get; set; }

    public DateTime? BolDataprotesto { get; set; }

    public string? BolGerouremessa { get; set; }

    public DateTime? BolDataremessa { get; set; }

    public string? BolRetorno { get; set; }

    public DateTime? BolDataretorno { get; set; }

    public string? BolStatus { get; set; }

    public DateTime? BolDatastatus { get; set; }

    public string? BolObs { get; set; }

    public int? BolNumerodoc { get; set; }

    public decimal? BolValorrecebido { get; set; }

    public DateOnly? BolDatarecebimento { get; set; }

    public int? CtcCodigo { get; set; }

    public int? CcbCodigo { get; set; }

    public string? BolTipomovimento { get; set; }

    public int? BolCodigomovimento { get; set; }

    public string? BolStatusvencimento { get; set; }
}
