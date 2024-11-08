using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbAgendacomercial
{
    public int AgcCodigo { get; set; }

    public string? AgcTitulo { get; set; }

    public string? AgcTipo { get; set; }

    public DateTime? AgcDatainicio { get; set; }

    public DateTime? AgcDatafim { get; set; }

    public int? AgcTempoalerta { get; set; }

    public string? AgcDescricao { get; set; }

    public int PesCodigo { get; set; }

    public int EmpCodigo { get; set; }

    public int? CntCodigo { get; set; }

    public virtual TbPessoa PesCodigoNavigation { get; set; } = null!;
}
