using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbBancoFinanceiro
{
    public int BAN_CODIGO { get; set; }

    public int? BAN_NUMERO { get; set; }

    public string? BAN_DESCRICAO { get; set; }

    public string? BAN_LOGO { get; set; }

    public string? BAN_DIGITO { get; set; }
}
