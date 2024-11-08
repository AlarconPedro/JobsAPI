using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbCarteiracobranca
{
    public int CcbCodigo { get; set; }

    public int? CtcCodigo { get; set; }

    public string? CcbCarteira { get; set; }

    public string? CcbConvenio { get; set; }

    public int? CcbDiasprotesto { get; set; }

    public int? CcbDiasbaixa { get; set; }

    public decimal? CcbMultaaposvencimento { get; set; }

    public decimal? CcbJurosdia { get; set; }

    public string? CcbEspeciedocumento { get; set; }

    public string? CcbInstrucao1 { get; set; }

    public string? CcbInstrucao2 { get; set; }

    public string? CcbInstrucao3 { get; set; }

    public string? CcbDescricao { get; set; }

    public string? CcbGeraremessa { get; set; }

    public int? CcbContadorremessa { get; set; }

    public string? CcbAceite { get; set; }

    public string? CcbContrato { get; set; }

    public string? CcbLocalpagamento { get; set; }

    public int? EmpCodigo { get; set; }

    public string? CcbModalidade { get; set; }

    public int? PesCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public string? CcbUltimoarquivo { get; set; }

    public string? CcbLayoutremessa { get; set; }

    public string? CcbStatus { get; set; }

    public int? CcbDiasdevolucaobaixa { get; set; }

    public virtual TbContacorrente? CtcCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbPlanodeconta? PlcCodigoNavigation { get; set; }
}
