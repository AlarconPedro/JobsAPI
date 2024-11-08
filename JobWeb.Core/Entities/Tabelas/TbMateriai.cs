using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbMateriai
{
    public int MatCodigo { get; set; }

    public string? MatArquivo { get; set; }

    public string? MatTempo { get; set; }

    public string? MatTipo { get; set; }

    public string MatDiario { get; set; } = null!;

    public int? MatSegundos { get; set; }

    public string? MatNome { get; set; }

    public string? MatBloqueado { get; set; }

    public DateOnly? MatTerminorabicho { get; set; }

    public string? MatRabicho { get; set; }

    public string? MatTrilharabicho { get; set; }

    public string? MatTrilha { get; set; }

    public int? MatProposto { get; set; }

    public int? MatRealizado { get; set; }

    public string? MatVigencia { get; set; }

    public int? AtiCodigo { get; set; }

    public int? CliCodigo { get; set; }

    public DateOnly? MatInicio { get; set; }

    public DateOnly? MatTermino { get; set; }

    public int? VinCodigochamada { get; set; }

    public int? VinCodigopatrocinio { get; set; }

    public string? MatPosicaopatrocinio { get; set; }

    public int? MatSegundoschamada { get; set; }

    public int? MatSegundospatrocinio { get; set; }

    public int? ConCodigo { get; set; }

    public string? MatRodizio { get; set; }
}
