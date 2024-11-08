using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbMovimentodecaixa
{
    public int McxCodigo { get; set; }

    public int? CaiCodigo { get; set; }

    public DateOnly? McxData { get; set; }

    public string? McxHora { get; set; }

    public decimal? McxEntrada { get; set; }

    public decimal? McxSaida { get; set; }

    public string? McxHistorico { get; set; }

    public decimal? McxValor { get; set; }

    public string? McxTipo { get; set; }

    public string? McxFormapagamento { get; set; }

    public string? McxTipomovimento { get; set; }

    public int? McxCodigomovimento { get; set; }

    public virtual TbCaixa? CaiCodigoNavigation { get; set; }
}
