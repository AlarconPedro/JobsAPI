using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbProdutoChave
{
    public int ChaCodigo { get; set; }

    public string? ChaKey { get; set; }

    public bool? ChaAtivo { get; set; }

    public string? ChaObersvacao { get; set; }

    public int? ProcliCodigo { get; set; }

    public virtual TbProdutoCliente? ProcliCodigoNavigation { get; set; }

    public virtual ICollection<TbCongelamento> TbCongelamentos { get; set; } = new List<TbCongelamento>();
}
