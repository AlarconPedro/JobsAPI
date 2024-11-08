using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbVersaoProduto
{
    public int VprodCodigo { get; set; }

    public string? VprodNomeArquivo { get; set; }

    public int? ProCodigo { get; set; }

    public string? VprodVersao { get; set; }

    public string? VprodVersaoAtual { get; set; }

    public string? VprodDescricao { get; set; }

    public virtual TbProduto? ProCodigoNavigation { get; set; }
}
