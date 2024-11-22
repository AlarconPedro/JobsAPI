namespace JobWeb.Core.Entities.OmegaCloud.Relatorio;

public class RelatorioCliente
{
    //CLIENTE
    public int PesCodigo { get; set; }
    public string? PesNome { get; set; }
    public string? PesEmail { get; set; }
    public string? PesCelular { get; set; }
    public string? PesFone { get; set; }
    //PRODUTO
    public int ProCodigo { get; set; }
    public string? ProNome { get; set; }
    public List<string>? ProNomeProduto { get; set; }
    public double? ProPercentualLocucao { get; set; }
    public string? ProcliVersao { get; set; }
    public string? ProcliTipoAquisicao { get; set; }
}
