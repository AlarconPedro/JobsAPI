using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbRespostaEmail
{
    public int ResCodigo { get; set; }

    public string? ResTitulo { get; set; }

    public string? ResTexto { get; set; }

    public int? ResQtdDiasDepois { get; set; }

    public int? EmaCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? TemEmaCodigo { get; set; }

    public int? ResTipoEnvio { get; set; }
}
