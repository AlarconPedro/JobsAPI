using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbFaq
{
    public int FaqCodigo { get; set; }

    public string? FaqPergunta { get; set; }

    public string? FaqResposta { get; set; }

    public int? ProCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbProduto? ProCodigoNavigation { get; set; }
}
