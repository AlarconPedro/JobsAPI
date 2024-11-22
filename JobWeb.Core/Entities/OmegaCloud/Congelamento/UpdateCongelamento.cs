namespace JobWeb.Core.Entities.OmegaCloud.Congelamento;

public class UpdateCongelamento
{
    public int CngCodigo { get; set; }
    public string? CngStatus { get; set; }
    public bool? CngCongelado { get; set; }
    public DateTime? CngDatacongelamento { get; set; }
}
