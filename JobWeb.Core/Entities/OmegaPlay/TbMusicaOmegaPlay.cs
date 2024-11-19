using System;
using System.Collections.Generic;

namespace OmegaCloudAPI.Models.Replicacao.OmegaPlay;

public partial class TbMusicaOmegaPlay
{
    public int MUS_CODIGO { get; set; }

    public string? MUS_NOME { get; set; }

    public string? MUS_INTERPRETE { get; set; }

    public string? MUS_TEMPO { get; set; }

    public string? MUS_TIPO { get; set; }

    public string? MUS_ALBUM { get; set; }

    public int? MUS_ANO { get; set; }

    public int? MUS_FAIXA { get; set; }

    public string? MUS_NOMECOMPLETO { get; set; }

    public int? SUB_CODIGO { get; set; }

    public int? RIT_CODIGO { get; set; }

    public int? VOC_CODIGO { get; set; }

    public int? GRA_CODIGO { get; set; }

    public int? IDI_CODIGO { get; set; }

    public int? PAS_CODIGO { get; set; }

    public string? MUS_ARQUIVO { get; set; }

    public string? MUS_COMPOSITOR { get; set; }

    public string? MUS_TIPOPERIODO { get; set; }

    public string? MUS_PERIODOINICIO { get; set; }

    public string? MUS_PERIODOFIM { get; set; }

    public int? MUS_SEGUNDOS { get; set; }

    public int? MUS_AVALIACAO { get; set; }
}
