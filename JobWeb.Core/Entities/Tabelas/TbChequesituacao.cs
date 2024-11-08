using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbChequesituacao
{
    public int CqsCodigo { get; set; }

    public int? CheCodigo { get; set; }

    public DateOnly? CqsData { get; set; }

    public string? CqsHora { get; set; }

    public string? CqsSituacao { get; set; }

    public string? CqsHistorico { get; set; }

    public virtual TbCheque? CheCodigoNavigation { get; set; }
}
