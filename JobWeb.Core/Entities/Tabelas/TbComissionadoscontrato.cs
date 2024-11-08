using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbComissionadoscontrato
{
    public int CmcCodigo { get; set; }

    public int PesCodigo { get; set; }

    public int CntCodigo { get; set; }

    public decimal? CmcComissao { get; set; }

    public virtual TbContrato CntCodigoNavigation { get; set; } = null!;

    public virtual TbPessoa PesCodigoNavigation { get; set; } = null!;
}
