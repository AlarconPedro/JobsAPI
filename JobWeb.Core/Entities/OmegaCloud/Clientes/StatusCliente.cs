using JobWeb.Core.Entities.OmegaCloud.Produtos;

namespace JobWeb.Core.Entities.OmegaCloud.Clientes;

public class StatusCliente
{
    public string Status { get; set; }
    public List<ProdutosBasico> Produtos { get; set; }
}
