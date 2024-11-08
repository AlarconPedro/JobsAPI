using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbMusica
{
    public int MusCodigo { get; set; }

    public string? MusNome { get; set; }

    public string? MusInterprete { get; set; }

    public string? MusTempo { get; set; }

    public string? MusTipo { get; set; }

    public string? MusAlbum { get; set; }

    public int? MusAno { get; set; }

    public int? MusFaixa { get; set; }

    public string? MusNomecompleto { get; set; }

    public int? SubCodigo { get; set; }

    public int? RitCodigo { get; set; }

    public int? VocCodigo { get; set; }

    public int? GraCodigo { get; set; }

    public int? IdiCodigo { get; set; }

    public int? PasCodigo { get; set; }

    public string? MusArquivo { get; set; }

    public string? MusCompositor { get; set; }

    public string? MusTipoperiodo { get; set; }

    public string? MusPeriodoinicio { get; set; }

    public string? MusPeriodofim { get; set; }

    public int? MusSegundos { get; set; }

    public int? MusAvaliacao { get; set; }

    public int? EmpCodigo { get; set; }

    public int? IdFilial { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbEcad> TbEcads { get; set; } = new List<TbEcad>();
}
