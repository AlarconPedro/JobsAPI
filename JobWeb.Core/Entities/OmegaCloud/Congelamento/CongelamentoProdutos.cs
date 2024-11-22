namespace JobWeb.Core.Entities.OmegaCloud.Congelamento;

public class CongelamentoProdutos
{
    public int ProcliCodigo { get; set; }
    public int ProCodigo { get; set; }
    public string? ProNome { get; set; }
    public int PesCodigo { get; set; }
    public string? ProcliVersao { get; set; }
    public string? ProcliTipoAquisicao { get; set; }
    public int? PesCodigoFilial { get; set; }
    public DateTime? ProcliData { get; set; }
}
