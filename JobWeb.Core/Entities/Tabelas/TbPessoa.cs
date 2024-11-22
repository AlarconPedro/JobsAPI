using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbPessoa
{
    public int PesCodigo { get; set; }

    public int? AtiCodigo { get; set; }

    public string? PesNome { get; set; }

    public string? PesEndereco { get; set; }

    public string? PesBairro { get; set; }

    public string? PesCidade { get; set; }

    public string? PesEstado { get; set; }

    public string? PesCgccpf { get; set; }

    public string? PesInscricao { get; set; }

    public string? PesCep { get; set; }

    public string? PesFone { get; set; }

    public string? PesFax { get; set; }

    public string? PesRazaosocial { get; set; }

    public string? PesEmail { get; set; }

    public string? PesWeb { get; set; }

    public string? PesPessoa { get; set; }

    public string? PesCelular { get; set; }

    public string? PesAnivdia { get; set; }

    public string? PesAnivmes { get; set; }

    public string? PesStatus { get; set; }

    public string? PesCliente { get; set; }

    public string? PesFornecedor { get; set; }

    public string? PesVendedor { get; set; }

    public string? PesFuncionario { get; set; }

    public decimal? PesComissao { get; set; }

    public int? EmpCodigo { get; set; }

    public string? PesNumero { get; set; }

    public string? PesObservacao { get; set; }

    public string? PesContato { get; set; }

    public DateTime? PesClientedesde { get; set; }

    public string? PesGuid { get; set; }

    public string? PesIdFirebase { get; set; }

    public string? PesContatoFone { get; set; }

    public string? PesContatoFuncao { get; set; }

    public int? PesCodigocom { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbAgendacomercial> TbAgendacomercials { get; set; } = new List<TbAgendacomercial>();

    public virtual ICollection<TbCarteiracobranca> TbCarteiracobrancas { get; set; } = new List<TbCarteiracobranca>();

    public virtual ICollection<TbCheque> TbCheques { get; set; } = new List<TbCheque>();

    public virtual ICollection<TbComissionadoscontrato> TbComissionadoscontratos { get; set; } = new List<TbComissionadoscontrato>();

    public virtual ICollection<TbContamensal> TbContamensals { get; set; } = new List<TbContamensal>();

    public virtual ICollection<TbContaspagar> TbContaspagars { get; set; } = new List<TbContaspagar>();

    public virtual ICollection<TbContasreceber> TbContasrecebers { get; set; } = new List<TbContasreceber>();

    public virtual ICollection<TbContrato> TbContratos { get; set; } = new List<TbContrato>();

    public virtual ICollection<TbOrdemServico> TbOrdemServicos { get; set; } = new List<TbOrdemServico>();

    public virtual ICollection<TbProdutoCliente> TbProdutoClientes { get; set; } = new List<TbProdutoCliente>();

    public virtual ICollection<TbUsuarioPessoa> TbUsuarioPessoas { get; set; } = new List<TbUsuarioPessoa>();
}
