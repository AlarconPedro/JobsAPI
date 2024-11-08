using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbEmpresa
{
    public int EmpCodigo { get; set; }

    public string? EmpNome { get; set; }

    public string? EmpDenominacao { get; set; }

    public string? EmpEndereco { get; set; }

    public string? EmpBairro { get; set; }

    public string? EmpCidade { get; set; }

    public string? EmpUf { get; set; }

    public string? EmpCnpj { get; set; }

    public string? EmpInscricao { get; set; }

    public string? EmpFone { get; set; }

    public string? EmpFax { get; set; }

    public string? EmpRazaosocial { get; set; }

    public string EmpEmail { get; set; } = null!;

    public string? EmpWeb { get; set; }

    public string? EmpCep { get; set; }

    public string? EmpLogomarca { get; set; }

    public string? EmpLinha1 { get; set; }

    public string? EmpLinha2 { get; set; }

    public string? EmpLinha3 { get; set; }

    public string? EmpLinha4 { get; set; }

    public string? EmpLinha5 { get; set; }

    public string? EmpStatus { get; set; }

    public string? EmpContadornome { get; set; }

    public string? EmpContadorcargo { get; set; }

    public string? EmpContadorfone { get; set; }

    public string? EmpContadoremail { get; set; }

    public string? EmpNumero { get; set; }

    public string? EmpContadorcpf { get; set; }

    public string? EmpContadorcrc { get; set; }

    public string? EmpContadorcep { get; set; }

    public string? EmpContadorendereco { get; set; }

    public string? EmpContadornumero { get; set; }

    public string? EmpContadorbairro { get; set; }

    public string? EmpContadorcidade { get; set; }

    public string? EmpContadoruf { get; set; }

    public int? EmpAliasCodigo { get; set; }

    public int? EmpQtdFiliais { get; set; }

    public virtual ICollection<TbArea> TbAreas { get; set; } = new List<TbArea>();

    public virtual ICollection<TbAtividade> TbAtividades { get; set; } = new List<TbAtividade>();

    public virtual ICollection<TbCaixa> TbCaixas { get; set; } = new List<TbCaixa>();

    public virtual ICollection<TbCarteiracobranca> TbCarteiracobrancas { get; set; } = new List<TbCarteiracobranca>();

    public virtual ICollection<TbCedentecheque> TbCedentecheques { get; set; } = new List<TbCedentecheque>();

    public virtual ICollection<TbCentroconta> TbCentroconta { get; set; } = new List<TbCentroconta>();

    public virtual ICollection<TbCheque> TbCheques { get; set; } = new List<TbCheque>();

    public virtual ICollection<TbChequesmovimentacao> TbChequesmovimentacaos { get; set; } = new List<TbChequesmovimentacao>();

    public virtual ICollection<TbClienteAntigo> TbClienteAntigos { get; set; } = new List<TbClienteAntigo>();

    public virtual ICollection<TbConfiguracaoempresa> TbConfiguracaoempresas { get; set; } = new List<TbConfiguracaoempresa>();

    public virtual ICollection<TbContacorrentelanc> TbContacorrentelancs { get; set; } = new List<TbContacorrentelanc>();

    public virtual ICollection<TbContacorrente> TbContacorrentes { get; set; } = new List<TbContacorrente>();

    public virtual ICollection<TbContainvestimento> TbContainvestimentos { get; set; } = new List<TbContainvestimento>();

    public virtual ICollection<TbContamensal> TbContamensals { get; set; } = new List<TbContamensal>();

    public virtual ICollection<TbContaspagar> TbContaspagars { get; set; } = new List<TbContaspagar>();

    public virtual ICollection<TbContasreceber> TbContasrecebers { get; set; } = new List<TbContasreceber>();

    public virtual ICollection<TbContrato> TbContratos { get; set; } = new List<TbContrato>();

    public virtual ICollection<TbDireito> TbDireitos { get; set; } = new List<TbDireito>();

    public virtual ICollection<TbEcad> TbEcads { get; set; } = new List<TbEcad>();

    public virtual ICollection<TbEmail> TbEmails { get; set; } = new List<TbEmail>();

    public virtual ICollection<TbFaq> TbFaqs { get; set; } = new List<TbFaq>();

    public virtual ICollection<TbGavetum> TbGaveta { get; set; } = new List<TbGavetum>();

    public virtual ICollection<TbGravadora> TbGravadoras { get; set; } = new List<TbGravadora>();

    public virtual ICollection<TbMusica> TbMusicas { get; set; } = new List<TbMusica>();

    public virtual ICollection<TbNotafiscal21> TbNotafiscal21s { get; set; } = new List<TbNotafiscal21>();

    public virtual ICollection<TbPessoa> TbPessoas { get; set; } = new List<TbPessoa>();

    public virtual ICollection<TbPlanodeconta> TbPlanodeconta { get; set; } = new List<TbPlanodeconta>();

    public virtual ICollection<TbProduto> TbProdutos { get; set; } = new List<TbProduto>();

    public virtual ICollection<TbRateio> TbRateios { get; set; } = new List<TbRateio>();

    public virtual ICollection<TbUsuarioPessoa> TbUsuarioPessoas { get; set; } = new List<TbUsuarioPessoa>();
}
