using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContacorrente
{
    public int CtcCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? BanCodigo { get; set; }

    public string? CtcAgencia { get; set; }

    public string? CtcNomeagencia { get; set; }

    public string? CtcConta { get; set; }

    public string? CtcTitular { get; set; }

    public string? CtcAgenciadigito { get; set; }

    public string? CtcContadigito { get; set; }

    public string? CtcGeraboleto { get; set; }

    public string? CtcTipoconta { get; set; }

    public string? CtcAtiva { get; set; }

    public virtual TbBanco? BanCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbCarteiracobranca> TbCarteiracobrancas { get; set; } = new List<TbCarteiracobranca>();

    public virtual ICollection<TbContacorrentelanc> TbContacorrentelancs { get; set; } = new List<TbContacorrentelanc>();

    public virtual ICollection<TbContainvestimento> TbContainvestimentos { get; set; } = new List<TbContainvestimento>();
}
