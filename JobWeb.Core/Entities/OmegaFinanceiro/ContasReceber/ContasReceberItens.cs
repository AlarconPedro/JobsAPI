namespace OmegaCloudAPI.Models.OmegaFinanceiro.ContasReceber;

public class ContasReceberItens
{
	public int CriCodigo { get; set; }

	public int? CtrCodigo { get; set; }

	public decimal? CriJuros { get; set; }

	public decimal? CriMulta { get; set; }

	public decimal? CriDesconto { get; set; }

	public decimal? CriValorpago { get; set; }

	public DateTime? CriDatapago { get; set; }

	public string? CriTipopag { get; set; }
}
