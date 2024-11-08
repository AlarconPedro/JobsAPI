using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbContasreceber
{
    public int CtrCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public int? CntCodigo { get; set; }

    public DateOnly? CtrData { get; set; }

    public DateOnly? CtrDatavencimento { get; set; }

    public decimal? CtrValor { get; set; }

    public string? CtrSituacao { get; set; }

    public string? CtrHistorico { get; set; }

    public string? CtrNossonumero { get; set; }

    public string? CtrBoletoimpresso { get; set; }

    public string? CtrNumeronf { get; set; }

    public int? CtrParcela { get; set; }

    public string? CtrPrevisao { get; set; }

    public string? CtrObservacao { get; set; }

    public DateOnly? CtrPeriodoinicio { get; set; }

    public DateOnly? CtrPeriodofim { get; set; }

    public string? CtrBoleto { get; set; }

    public string? CtrRecibo { get; set; }

    public string? CtrDuplicata { get; set; }

    public int? CcoCodigo { get; set; }

    public string? CtrTipomovimento { get; set; }

    public int? CtrCodigomovimento { get; set; }

    public string? CtrSituacaoautorizacao { get; set; }

    public int? UsuCodigo { get; set; }

    public string? CtrSemregistro { get; set; }

    public DateOnly? CtrDatavencimentobase { get; set; }

    public string? CtrNumdoc { get; set; }

    public int? CtrNumrecibo { get; set; }

    public virtual TbCentroconta? CcoCodigoNavigation { get; set; }

    public virtual TbContrato? CntCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbPlanodeconta? PlcCodigoNavigation { get; set; }

    public virtual ICollection<TbCongelamento> TbCongelamentos { get; set; } = new List<TbCongelamento>();

    public virtual ICollection<TbContasreceberiten> TbContasreceberitens { get; set; } = new List<TbContasreceberiten>();

    public virtual ICollection<TbNotafiscal21> TbNotafiscal21s { get; set; } = new List<TbNotafiscal21>();

    public virtual ICollection<TbRateiocontasreceber> TbRateiocontasrecebers { get; set; } = new List<TbRateiocontasreceber>();
}
