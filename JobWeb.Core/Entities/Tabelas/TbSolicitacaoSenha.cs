using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbSolicitacaoSenha
{
    public int? SsCodigo { get; set; }

    public DateTime? SsData { get; set; }

    public int? SsDias { get; set; }

    public int? PesCodigo { get; set; }

    public int? ProCodigo { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbProduto? ProCodigoNavigation { get; set; }
}
