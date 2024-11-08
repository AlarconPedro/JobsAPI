using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbConfiguracao
{
    public int CfgCodigo { get; set; }

    public string? CfgLembretebackup { get; set; }

    public string? CfgGuid { get; set; }

    public string? CfgDatasistema { get; set; }

    public string? CfgSenhavezes { get; set; }

    public string? CfgSenhastatus { get; set; }

    public string? CfgVersao { get; set; }

    public decimal? CfgSalariominimo { get; set; }

    public string? CfgPathvalidador { get; set; }

    public string? CfgPathgerated { get; set; }

    public string? CfgPathted { get; set; }

    public string? CfgModulos { get; set; }

    public int? CfgIdCloud { get; set; }
}
