using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbPlanodecontaFinanceiro
{
    public int PLC_CODIGO { get; set; }

    public string? PLC_ID { get; set; }

    public string? PLC_CONTAMAE { get; set; }

    public string? PLC_DESCRICAO { get; set; }

    public string? PLC_TIPO { get; set; }

    public int? EMP_CODIGO { get; set; }
}
