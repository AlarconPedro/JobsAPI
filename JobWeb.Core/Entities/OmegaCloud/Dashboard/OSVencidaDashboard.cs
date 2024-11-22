namespace JobWeb.Core.Entities.OmegaCloud.Dashboard;

public class OSVencidaDashboard
{
    public int CodigoItem { get; set; }
    public int CodigoOS { get; set; }
    public string? TituloItem { get; set; }
    public string? TituloOS { get; set; }
    public string? NomeCliente { get; set; }
    public DateTime? DataVencimento { get; set; }
}
