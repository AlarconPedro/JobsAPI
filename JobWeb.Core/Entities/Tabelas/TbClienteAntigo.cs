using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbClienteAntigo
{
    public int CliAntCodigo { get; set; }

    public string? CliAntNome { get; set; }

    public string? CliAntTipoRadio { get; set; }

    public string? CliAntTipoPessoa { get; set; }

    public string? CliAntCpfCnpj { get; set; }

    public string? CliAntRgIe { get; set; }

    public string? CliAntStatus { get; set; }

    public string? CliAntEndereco { get; set; }

    public string? CliAntBairro { get; set; }

    public string? CliAntCep { get; set; }

    public string? CliAntFone { get; set; }

    public string? CliAntCelular { get; set; }

    public bool? CliAntWhats { get; set; }

    public string? CliAntEmail { get; set; }

    public string? CliAntSite { get; set; }

    public string? CliAntContatoNome { get; set; }

    public string? CliAntContatoFone { get; set; }

    public string? CliAntContatoFuncao { get; set; }

    public string? CliAntObservacao { get; set; }

    public int? EmpCodigo { get; set; }

    public string? CliAntGuid { get; set; }

    public DateOnly? CliAntClienteDesde { get; set; }

    public DateOnly? CliAntVigenciaPlano { get; set; }

    public double? CliAntValorPercentual { get; set; }

    public int? CidAntCodigo { get; set; }

    public string? CliAntRazaoSocial { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }
}
