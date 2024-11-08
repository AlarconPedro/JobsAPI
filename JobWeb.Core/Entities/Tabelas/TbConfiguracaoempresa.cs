using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbConfiguracaoempresa
{
    public int CfeCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? PlcCodigoFaturamento { get; set; }

    public int? PlcCodigoComissao { get; set; }

    public int? PlcCodigoRendimentoAplicacao { get; set; }

    public string? CfeHistoricoFaturamento { get; set; }

    public string? CfeHistoricoRecDinheiro { get; set; }

    public string? CfeHistoricoRecCheque { get; set; }

    public string? CfeHistoricoRecCarteira { get; set; }

    public string? CfeHistoricoRecCartao { get; set; }

    public string? CfeHistoricoRecBoleto { get; set; }

    public string? CfeHistoricoRecTransfdep { get; set; }

    public string? CfeHistoricoPagDinheiro { get; set; }

    public string? CfeHistoricoPagCheque { get; set; }

    public string? CfeHistoricoPagCarteira { get; set; }

    public string? CfeHistoricoPagCartao { get; set; }

    public string? CfeHistoricoPagBoleto { get; set; }

    public string? CfeHistoricoPagTransfdep { get; set; }

    public string? CfeEmailenvio { get; set; }

    public string? CfeSenhaemail { get; set; }

    public string? CfeHostemail { get; set; }

    public string? CfePortaemail { get; set; }

    public string? CfeTextocontrato { get; set; }

    public string? CfeIntegracaocomercial { get; set; }

    public string? CfeEnderecocomercial { get; set; }

    public string? CfeMostracalendario { get; set; }

    public string? CfeMostralembretecr { get; set; }

    public int? CfeDiaslembretecr { get; set; }

    public int? CfeDiaslembretecp { get; set; }

    public int? CfeDiaslembretecontrato { get; set; }

    public string? CfeMostralembretecp { get; set; }

    public string? CfeMostralembretecontrato { get; set; }

    public string? CfeDescricaoemailboleto { get; set; }

    public string? CfeEmailtipoenvio { get; set; }

    public int? CfeTempolembrete { get; set; }

    public decimal? CfeJuros { get; set; }

    public decimal? CfeMulta { get; set; }

    public string? CfeNumerocontratoauto { get; set; }

    public int? CfeEmissorchequepadrao { get; set; }

    public int? CfeUltimorecibo { get; set; }

    public string? CfeDescricaoemailnf21 { get; set; }

    public string? CfeOnesignalAppId { get; set; }

    public string? CfeOnesignalRestApiKey { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPlanodeconta? PlcCodigoComissaoNavigation { get; set; }

    public virtual TbPlanodeconta? PlcCodigoFaturamentoNavigation { get; set; }

    public virtual TbPlanodeconta? PlcCodigoRendimentoAplicacaoNavigation { get; set; }
}
