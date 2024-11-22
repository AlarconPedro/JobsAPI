namespace JobWeb.Core.Entities.OmegaCloud.OS;

public class OSItens
{
    public int OrditeCodigo { get; set; }
    public string? OrditeTitulo { get; set; }
    public string? nomeCliente { get; set; }
    public int UsuCodigo { get; set; }
    public string? usuNome { get; set; }
    public string? UsuImagem { get; set; }
    public bool? OrditeFinalizada { get; set; }
    public int? OrditePrioridade { get; set; }
    public DateTime? OrditeDataVence { get; set; }
}
