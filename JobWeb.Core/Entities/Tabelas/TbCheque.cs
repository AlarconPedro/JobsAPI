using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbCheque
{
    public int CheCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public int? BanCodigo { get; set; }

    public int? CedCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public string? CheAgencia { get; set; }

    public string? CheConta { get; set; }

    public decimal? CheValor { get; set; }

    public string? ChePredatado { get; set; }

    public DateOnly? CheDataemissao { get; set; }

    public DateOnly? CheBompara { get; set; }

    public string? CheNumero { get; set; }

    public string? CheTipo { get; set; }

    public virtual TbBanco? BanCodigoNavigation { get; set; }

    public virtual TbCedentecheque? CedCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbPlanodeconta? PlcCodigoNavigation { get; set; }

    public virtual ICollection<TbChequesituacao> TbChequesituacaos { get; set; } = new List<TbChequesituacao>();

    public virtual ICollection<TbChequesmovimentacao> TbChequesmovimentacaos { get; set; } = new List<TbChequesmovimentacao>();
}
