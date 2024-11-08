using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContamensal
{
    public int CmeCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public int? CmeDiavencimento { get; set; }

    public double? CmeValor { get; set; }

    public string? CmeHistorico { get; set; }

    public int? CcoCodigo { get; set; }

    public string? CmeHistoricoconta { get; set; }

    public string? CmeTipoperiodo { get; set; }

    public int? CmeDiasperiodo { get; set; }

    public virtual TbCentroconta? CcoCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbPlanodeconta? PlcCodigoNavigation { get; set; }
}
