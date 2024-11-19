using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbUsuarioFinanceiro
{
    public int USU_CODIGO { get; set; }

    public string? USU_NOME { get; set; }

    public string? USU_SENHA { get; set; }

    public string? USU_FUNCAO { get; set; }

    public string? USU_ENDERECO { get; set; }

    public string? USU_BAIRRO { get; set; }

    public string? USU_CIDADE { get; set; }

    public string? USU_UF { get; set; }

    public string? USU_CEP { get; set; }

    public string? USU_FONE { get; set; }

    public string? USU_CELULAR { get; set; }

    public string? USU_EMAIL { get; set; }

    public int? USU_DIAANIVERSARIO { get; set; }

    public int? USU_MESANIVERSARIO { get; set; }

    public string? USU_OBS { get; set; }

    public string? USU_LOGIN { get; set; }

    public int? USU_TIPO { get; set; }

    public int? USU_PERFILACESSO { get; set; }

    public string? USU_ACESSO_COMERCIAL { get; set; }

    public string? USU_ACESSO_MUSICAL { get; set; }

    public string? USU_ACESSO_LOCUCAO { get; set; }

    public int? USU_AUTORIZACAOACESSO { get; set; }
}
