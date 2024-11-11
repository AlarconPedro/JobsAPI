using JobWeb.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWeb.Core.Interfaces.Services.Data;

public interface IValidacaoService<T> : IGenericService<T> where T : class
{
    Task<string> GetGUID(string cpfcnpj, string aliasProduto, string chave);
    Task<int> GetStatus(string guid, string aliasProduto, int dias);
    Task<bool> GetStatusChave(string chave, string aliasProduto);
    Task<string> GetAtualizacaoCliente(string versaoAtual, string aliasProduto, string guid);
    Task<IEnumerable<TbVersaoProduto>> GetHistoricoAtualizacaoProduto(string nomeProduto);
}
