using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbOrdemServico
{
    public int OrdCodigo { get; set; }

    public string? OrdAssunto { get; set; }

    public string? OrdSolicitante { get; set; }

    public int? PesCodigo { get; set; }

    public string? OrdDescricao { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual ICollection<TbOrdemServicoIten> TbOrdemServicoItens { get; set; } = new List<TbOrdemServicoIten>();
}
