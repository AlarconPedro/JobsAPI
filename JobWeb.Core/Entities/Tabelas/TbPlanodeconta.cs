using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbPlanodeconta
{
    public int PlcCodigo { get; set; }

    public string? PlcId { get; set; }

    public string? PlcContamae { get; set; }

    public string? PlcDescricao { get; set; }

    public string? PlcTipo { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbCarteiracobranca> TbCarteiracobrancas { get; set; } = new List<TbCarteiracobranca>();

    public virtual ICollection<TbCheque> TbCheques { get; set; } = new List<TbCheque>();

    public virtual ICollection<TbConfiguracaoempresa> TbConfiguracaoempresaPlcCodigoComissaoNavigations { get; set; } = new List<TbConfiguracaoempresa>();

    public virtual ICollection<TbConfiguracaoempresa> TbConfiguracaoempresaPlcCodigoFaturamentoNavigations { get; set; } = new List<TbConfiguracaoempresa>();

    public virtual ICollection<TbConfiguracaoempresa> TbConfiguracaoempresaPlcCodigoRendimentoAplicacaoNavigations { get; set; } = new List<TbConfiguracaoempresa>();

    public virtual ICollection<TbContainvestimento> TbContainvestimentos { get; set; } = new List<TbContainvestimento>();

    public virtual ICollection<TbContamensalcontrato> TbContamensalcontratos { get; set; } = new List<TbContamensalcontrato>();

    public virtual ICollection<TbContamensal> TbContamensals { get; set; } = new List<TbContamensal>();

    public virtual ICollection<TbContaspagar> TbContaspagars { get; set; } = new List<TbContaspagar>();

    public virtual ICollection<TbContasreceber> TbContasrecebers { get; set; } = new List<TbContasreceber>();
}
