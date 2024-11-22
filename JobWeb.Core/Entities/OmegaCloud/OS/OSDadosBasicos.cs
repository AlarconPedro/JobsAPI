namespace JobWeb.Core.Entities.OmegaCloud.OS;

public class OSDadosBasicos
{
    public int OrdCodigo { get; set; }
    public string? OrdAssunto { get; set; }
    public string? NomeCliente { get; set; }
    public bool? Status { get; set; }
    public List<OSItens>? Usuario { get; set; }
}
