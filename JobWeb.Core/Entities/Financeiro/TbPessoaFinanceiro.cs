using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbPessoaFinanceiro
{
    public int PES_CODIGO { get; set; }

    public int? ATI_CODIGO { get; set; }

    public string? PES_NOME { get; set; }

    public string? PES_ENDERECO { get; set; }

    public string? PES_BAIRRO { get; set; }

    public string? PES_CIDADE { get; set; }

    public string? PES_ESTADO { get; set; }

    public string? PES_CGCCPF { get; set; }

    public string? PES_INSCRICAO { get; set; }

    public string? PES_CEP { get; set; }

    public string? PES_FONE { get; set; }

    public string? PES_FAX { get; set; }

    public string? PES_RAZAOSOCIAL { get; set; }

    public string? PES_EMAIL { get; set; }

    public string? PES_WEB { get; set; }

    public string? PES_PESSOA { get; set; }

    public string? PES_CELULAR { get; set; }

    public string? PES_ANIVDIA { get; set; }

    public string? PES_ANIVMES { get; set; }

    public string? PES_STATUS { get; set; }

    public string? PES_CLIENTE { get; set; }

    public string? PES_FORNECEDOR { get; set; }

    public string? PES_VENDEDOR { get; set; }

    public string? PES_FUNCIONARIO { get; set; }

    public decimal? PES_COMISSAO { get; set; }

    public int? EMP_CODIGO { get; set; }

    public string? PES_NUMERO { get; set; }

    public string? PES_OBSERVACAO { get; set; }

    public string? PES_CONTATO { get; set; }

    public string? PES_CLIENTEDESDE { get; set; }

    public string? PES_GUID { get; set; }

	public string? PES_CONTATO_FONE { get; set; }

	public string? PES_CONTATO_FUNCAO { get; set; }

	public virtual TbEmpresaFinanceiro? EmpCodigoNavigation { get; set; }
}
