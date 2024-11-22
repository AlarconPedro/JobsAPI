namespace OmegaCloudAPI.Models.OmegaFinanceiro.Relatorios;

public class ContasReceberDadosFinanceiro
{
	public int CtrCodigo { get; set; }
	public string? PesNome { get; set; }
	public string? Situacao { get; set; }
	public DateTime? CtrDatavencimento { get; set; }
	public decimal CtrValor { get; set; }
	public DateTime? CriDatapago { get; set; }
	public decimal CriValorpago { get; set; }
	public decimal CriValorReceber { get; set; }
}
