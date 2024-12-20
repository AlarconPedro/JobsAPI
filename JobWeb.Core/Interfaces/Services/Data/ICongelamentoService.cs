﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWeb.Core.Interfaces.Services.Data;

public interface ICongelamentoService<T> : IGenericService<T> where T : class
{
    Task<T?> BuscarCodigoChave(int cngCodigo);
    Task LiberarChaves(int cngCodigo);
    Task CongelarChaves(int cngCodigo);
    Task InserirCongelamento(T congelamento);
    Task InativarCongelamento(int cngCodigo);
    Task AtivarCongelamento(int cngCodigo);
    Task EnviaAvisos();
    Task<string> VerificaCongelados();
    Task<string> VerificaDevedores();
}
