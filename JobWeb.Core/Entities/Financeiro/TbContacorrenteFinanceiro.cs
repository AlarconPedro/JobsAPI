using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbContacorrenteFinanceiro
{
    public int CTC_CODIGO { get; set; }

    public int? EMP_CODIGO { get; set; }

    public int? BAN_CODIGO { get; set; }

    public string? CTC_AGENCIA { get; set; }

    public string? CTC_NOMEAGENCIA { get; set; }

    public string? CTC_CONTA { get; set; }

    public string? CTC_TITULAR { get; set; }

    public string? CTC_AGENCIADIGITO { get; set; }

    public string? CTC_CONTADIGITO { get; set; }

    public string? CTC_GERABOLETO { get; set; }

    public string? CTC_TIPOCONTA { get; set; }

    public string? CTC_ATIVA { get; set; }
}
