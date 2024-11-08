using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbProdutoCliente
{
    public int ProcliCodigo { get; set; }

    public int ProCodigo { get; set; }

    public int PesCodigo { get; set; }

    public string? ProcliVersao { get; set; }

    public string? ProcliTipoAquisicao { get; set; }

    public int? PesCodigoFilial { get; set; }

    public DateTime? ProcliData { get; set; }

    public virtual TbPessoa PesCodigoNavigation { get; set; } = null!;

    public virtual TbProduto ProCodigoNavigation { get; set; } = null!;

    public virtual ICollection<TbCongelamento> TbCongelamentos { get; set; } = new List<TbCongelamento>();

    public virtual ICollection<TbProdutoChave> TbProdutoChaves { get; set; } = new List<TbProdutoChave>();
}
