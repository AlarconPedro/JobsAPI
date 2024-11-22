using OmegaCloudAPI.Models.OmegaFinanceiro.ContasReceber;

namespace OmegaCloudAPI.Models.OmegaFinanceiro;

public class ContasReceberDados
{
	public int CtrCodigo { get; set; }

	public int? EmpCodigo { get; set; }

	public int? PesCodigo { get; set; }

	public string? PesNome { get; set; }

	public int? PlcCodigo { get; set; }

	public int? CntCodigo { get; set; }

	public DateTime? CtrData { get; set; }

	public DateTime? CtrDatavencimento { get; set; }

	public decimal? CtrValor { get; set; }

	public string? CtrSituacao { get; set; }

	public int? CtrParcela { get; set; }

	public string? CtrBoleto { get; set; }

	public string? CtrRecibo { get; set; }

	public string? CtrDuplicata { get; set; }

	public int? UsuCodigo { get; set; }

	public DateTime? CtrDatavencimentobase { get; set; }

	public List<ContasReceberItens>? itens { get; set; }

	public decimal? ValorTotal { get; set; }

	public decimal? JurosTotal { get; set; }

	public decimal? MultaTotal { get; set; }

	public decimal? ValorPagoTotal { get; set; }

	public decimal? ValorReceberTotal { get; set; }

	public int? Paginas { get; set; }

	//public decimal? valorPago { get; set; }
}
