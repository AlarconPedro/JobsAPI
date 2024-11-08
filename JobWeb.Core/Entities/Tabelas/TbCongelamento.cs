using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbCongelamento
{
    public int CngCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public int? ProcliCodigo { get; set; }

    public int? ChaCodigo { get; set; }

    public string? CngStatus { get; set; }

    public bool? CngCongelado { get; set; }

    public DateTime? CngDatacongelamento { get; set; }

    public string? CngDescricao { get; set; }

    public bool? CngAvisocobranca { get; set; }

    public DateTime? CngDataavisocobranca { get; set; }

    public bool? CngAvisocongelamento { get; set; }

    public DateTime? CngDataavisocongelamento { get; set; }

    public bool? CngAvisoprotesto { get; set; }

    public DateTime? CngDataavisoprotesto { get; set; }

    public int? CtrCodigo { get; set; }

    public virtual TbProdutoChave? ChaCodigoNavigation { get; set; }

    public virtual TbContasreceber? CtrCodigoNavigation { get; set; }

    public virtual TbProdutoCliente? ProcliCodigoNavigation { get; set; }
}
