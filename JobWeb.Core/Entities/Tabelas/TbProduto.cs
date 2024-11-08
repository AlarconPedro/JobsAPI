using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbProduto
{
    public int ProCodigo { get; set; }

    public string? ProNome { get; set; }

    public double? ProPercentualVenda { get; set; }

    public int? EmpCodigo { get; set; }

    public string? ProAlias { get; set; }

    public string? ProNomeProduto { get; set; }

    public double? ProPercentualLocucao { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbFaq> TbFaqs { get; set; } = new List<TbFaq>();

    public virtual ICollection<TbProdutoCliente> TbProdutoClientes { get; set; } = new List<TbProdutoCliente>();

    public virtual ICollection<TbVersaoProduto> TbVersaoProdutos { get; set; } = new List<TbVersaoProduto>();
}
