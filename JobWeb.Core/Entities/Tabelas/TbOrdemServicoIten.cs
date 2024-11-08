using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbOrdemServicoIten
{
    public int OrditeCodigo { get; set; }

    public int? OrdCodigo { get; set; }

    public int? AreCodigo { get; set; }

    public DateTime? OrditeDataInicio { get; set; }

    public DateTime? OrditeDataVence { get; set; }

    public DateTime? OrditeDataConclusao { get; set; }

    public int? OrditePrioridade { get; set; }

    public string? OrditeDescricao { get; set; }

    public int? UsuCodigo { get; set; }

    public bool? OrditeFinalizada { get; set; }

    public string? OrditeTitulo { get; set; }

    public virtual TbArea? AreCodigoNavigation { get; set; }

    public virtual TbOrdemServico? OrdCodigoNavigation { get; set; }

    public virtual TbUsuario? UsuCodigoNavigation { get; set; }
}
