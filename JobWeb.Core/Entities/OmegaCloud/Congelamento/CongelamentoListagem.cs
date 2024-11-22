namespace JobWeb.Core.Entities.OmegaCloud.Congelamento;

public class CongelamentoListagem
{
    public int? PesCodigo { get; set; }
    public int? ProCodigo { get; set; }
    public int? ProcliCodigo { get; set; }
    public int? ChaCodigo { get; set; }
    public int CngCodigo { get; set; }
    public string? NomeCliente { get; set; }
    public string? NomeProduto { get; set; }
    public string? Chave { get; set; }
    public string? CngStatus { get; set; }
    public bool? CngCongelado { get; set; }
    public DateTime? CngDatacongelamento { get; set; }
    public bool? CngAvisocobranca { get; set; }
    public DateTime? CngDataavisocobranca { get; set; }
    public bool? CngAvisocongelamento { get; set; }
    public DateTime? CngDataavisocongelamento { get; set; }
    public bool? CngAvisoprotesto { get; set; }
    public DateTime? CngDataavisoprotesto { get; set; }
}
