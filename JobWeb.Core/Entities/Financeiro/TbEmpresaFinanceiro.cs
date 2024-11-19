using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbEmpresaFinanceiro
{
    public int EMP_CODIGO { get; set; }

    public string? EMP_NOME { get; set; }

    public string? EMP_DENOMINACAO { get; set; }

    public string? EMP_ENDERECO { get; set; }

    public string? EMP_BAIRRO { get; set; }

    public string? EMP_CIDADE { get; set; }

    public string? EMP_UF { get; set; }

    public string? EMP_CNPJ { get; set; }

    public string? EMP_INSCRICAO { get; set; }

    public string? EMP_FONE { get; set; }

    public string? EMP_FAX { get; set; }

    public string? EMP_RAZAOSOCIAL { get; set; }

    public string? EMP_EMAIL { get; set; }

    public string? EMP_WEB { get; set; }

    public string? EMP_CEP { get; set; }

    public string? EMP_LOGOMARCA { get; set; }

    public string? EMP_LINHA1 { get; set; }

    public string? EMP_LINHA2 { get; set; }

    public string? EMP_LINHA3 { get; set; }

    public string? EMP_LINHA4 { get; set; }

    public string? EMP_LINHA5 { get; set; }

    public string? EMP_STATUS { get; set; }

    public string? EMP_CONTADORNOME { get; set; }

    public string? EMP_CONTADORCARGO { get; set; }

    public string? EMP_CONTADORFONE { get; set; }

    public string? EMP_CONTADOREMAIL { get; set; }

    public string? EMP_NUMERO { get; set; }

    public string? EMP_CONTADORCPF { get; set; }

    public string? EMP_CONTADORCRC { get; set; }

    public string? EMP_CONTADORCEP { get; set; }

    public string? EMP_CONTADORENDERECO { get; set; }

    public string? EMP_CONTADORNUMERO { get; set; }

    public string? EMP_CONTADORBAIRRO { get; set; }

    public string? EMP_CONTADORCIDADE { get; set; }

    public string? EMP_CONTADORUF { get; set; }

	public int? EMP_ALIAS_CODIGO { get; set; }

	public virtual ICollection<TbAtividadeFinanceiro>? TbAtividades { get; set; } = new List<TbAtividadeFinanceiro>();

    public virtual ICollection<TbPessoaFinanceiro>? TbPessoas { get; set; } = new List<TbPessoaFinanceiro>();
}
