using System;
using System.Collections.Generic;

namespace ApiReplicaDados;

public partial class TbAtividadeFinanceiro
{
    public int AtiId { get; set; }
    
    public int ATI_CODIGO { get; set; }

    public string ATI_NOME { get; set; } = null!;

    public int? ATI_CODIGOCOM { get; set; }

    public int? EMP_CODIGO { get; set; }

    public virtual TbEmpresaFinanceiro? EmpCodigoNavigation { get; set; }
}
