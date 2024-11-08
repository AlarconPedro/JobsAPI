using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbEcad
{
    public int EcaCodigo { get; set; }

    public DateOnly? EcaData { get; set; }

    public string? EcaHora { get; set; }

    public int? MusCodigo { get; set; }

    public string? EcaMusnomecompleto { get; set; }

    public string? MusInterprete { get; set; }

    public string? MusCompositor { get; set; }

    public string? MusGravadora { get; set; }

    public string? MusDuracao { get; set; }

    public int? EmpCodigo { get; set; }

    public int? IdFilial { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbMusica? MusCodigoNavigation { get; set; }
}
