using OmegaCloudAPI.Models;
using System;
using System.Collections.Generic;

namespace OmegaCloudAPI;

public partial class TbEcadOmegaPlay
{
    public int ECA_CODIGO { get; set; }

    public DateTime? ECA_DATA { get; set; }

    public string? ECA_HORA { get; set; }

    public int? MUS_CODIGO { get; set; }

    public string? ECA_MUSNOMECOMPLETO { get; set; }

    public string? MUS_INTERPRETE { get; set; }

    public string? MUS_COMPOSITOR { get; set; }

    public string? MUS_GRAVADORA { get; set; }

    public string? MUS_DURACAO { get; set; }
	
    public int? EMP_CODIGO { get; set; }

	public virtual TbMusica? MusCodigoNavigation { get; set; }
}
