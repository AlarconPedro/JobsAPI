using ApiJob.Enumerations;
using ApiJob.Interfaces;
using JobWeb.Core.Interfaces.Services.Data;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using JobWeb.Infra.Data.Services.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobWeb.Infra.Data.Services.Data;

public class ValidacaoService<T> : GenericService<T>, IValidacaoService<T> where T : class
{
    private readonly DbSet<TbPessoa> _pessoa;
    private readonly DbSet<TbProduto> _produto;
    private readonly DbSet<TbCongelamento> _congelamento;
    private readonly DbSet<TbProdutoChave> _produtoChave;
    private readonly DbSet<TbProdutoCliente> _produtoCliente;
    private readonly DbSet<TbSolicitacaoSenha> _solicitacaoSenha;
    private readonly DbSet<TbVersaoProduto> _versaoProduto;
    private readonly DbSet<TbContasreceber> _contasReceber;

    private readonly Func<CacheTech, ICacheService> _cacheService;
    private readonly AppDbContext _context;

    public ValidacaoService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _pessoa = context.Set<TbPessoa>();
        _produto = context.Set<TbProduto>();
        _congelamento = context.Set<TbCongelamento>();
        _produtoChave = context.Set<TbProdutoChave>();
        _produtoCliente = context.Set<TbProdutoCliente>();
        _solicitacaoSenha = context.Set<TbSolicitacaoSenha>();
        _versaoProduto = context.Set<TbVersaoProduto>();
        _contasReceber = context.Set<TbContasreceber>();

        _context = context;
        _cacheService = cacheService;
    }

    public async Task<string> GetGUID(string cpfcnpj, string aliasProduto, string chave)
    {
        //1° SE O CLIENTE ESTÁ ATIVO ? OK - RETURN GUID : NOTFOUND
        //2° SE O CLIENTE TEM O PRODUTO ? OK - RETURN GUID : NOTFOUND
        //3° SE O CLIENTE TEM A CHAVE
        //	? OK - RETURN GUID
        //		: EXISTE OUTRA CHAVE ATIVA
        //			? NOTFOUND
        //				: CADASTRAR NOVA CHAVE - RETURN GUID
        //4° SE A CHAVE ESTÁ ATIVA ? OK : NOTFOUND

        string cpfcnpjFormatado = cpfcnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
        var retornoPessoaAtivaProduto = await _pessoa
            .Where(p => p.PesCgccpf == cpfcnpjFormatado && p.PesStatus == "C"
            && p.PesCliente == "S"
                        && p.TbProdutoClientes.Any(pc => pc.ProCodigo == _produto
                            .Where(p => p.ProAlias == aliasProduto).FirstOrDefault().ProCodigo))
            .Select(z => new {
                z.PesGuid,
                z.TbProdutoClientes.Where(pc => pc.ProCodigo == _produto
                                    .Where(p => p.ProAlias == aliasProduto).FirstOrDefault().ProCodigo).FirstOrDefault().ProcliCodigo
            }).FirstOrDefaultAsync();

        if (retornoPessoaAtivaProduto != null)
        {
            var retornoChave = await _produtoChave
                .Where(p => p.ChaKey == chave && p.ProcliCodigoNavigation.ProCodigoNavigation.ProAlias == aliasProduto)
                .FirstOrDefaultAsync();

            if (retornoChave != null)
            {
                if (retornoChave.ChaAtivo ?? false)
                    return retornoPessoaAtivaProduto.PesGuid;
                else
                    return null;
            }
            else
            {
                var retornoChavesAtivas = await _produtoChave
                    .Where(p => p.ProcliCodigoNavigation.PesCodigoNavigation.PesGuid == retornoPessoaAtivaProduto.PesGuid
                                        && p.ProcliCodigoNavigation.ProCodigoNavigation.ProAlias == aliasProduto)
                    .Select(z => z.ChaKey)
                    .FirstOrDefaultAsync();

                if (retornoChavesAtivas != null)
                {
                    return null;
                }
                else
                {
                    var produtoCliente = await _produtoCliente
                        .Where(p => p.PesCodigoNavigation.PesGuid == retornoPessoaAtivaProduto.PesGuid
                                 && p.ProCodigoNavigation.ProAlias == aliasProduto)
                        .FirstOrDefaultAsync();

                    var chaveNova = new TbProdutoChave
                    {
                        ProcliCodigo = retornoPessoaAtivaProduto.ProcliCodigo,
                        ChaKey = chave,
                        ChaAtivo = true,
                        ChaObersvacao = "Chave gerada automaticamente",
                    };

                    //ProdutosService produtosService = new ProdutosService();
                    //await produtosService.AdicionarProdutoChave(chaveNova);

                    _context.Set<TbProdutoChave>().Add(chaveNova);
                    await _context.SaveChangesAsync();

                    return retornoPessoaAtivaProduto.PesGuid ?? "GUID Não encontrado";
                }
            }
        }
        else
        {
            return null;
        }

        /*string cpfcnpjFormatado = cpfcnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
		return await _context.TbPessoas.Where(p => p.TbProdutoClientes.Any(pc => pc.ProCodigo == _context.TbProdutos
										.Where(p => p.ProAlias == aliasProduto).FirstOrDefault().ProCodigo 
										&& pc.TbProdutoChaves.Any(pcc => pcc.ProcliCodigo == pc.ProcliCodigo 
										&& pcc.ChaAtivo == true)) 
									&& p.PesCgccpf == cpfcnpjFormatado 
									&& p.PesCliente == "S"
									&& p.PesStatus == "C")
			.Select(z => z.PesGuid)
			.FirstOrDefaultAsync();*/
    }

    public async Task<string> GetAtualizacaoCliente(string versaoAtual, string aliasProduto, string guid)
    {
        //1° SE O CLIENTE ESTÁ ATIVO OU NÃO ESTÁ NA TABELA DE CONGELAMENTO ? OK : NOTFOUND
        //2° SE O CLIENTE TEM O PRODUTO ? OK : NOTFOUND
        //3° BUSCAR DADOS PELO GUID
        //4° RETORNAR O NOME DO ARQUIVO
        var retornoPessoaAtiva = await _pessoa
                .Where(p => p.PesGuid == guid
                    && p.PesStatus == "C"
                    && p.PesCliente == "S").FirstOrDefaultAsync();

        if (retornoPessoaAtiva != null)
        {
            var temVersao = await _versaoProduto
                .Where(vp => vp.ProCodigo == _produto
                    .Where(p => p.ProAlias == aliasProduto)
                    .FirstOrDefault().ProCodigo)
                .Select(z => z.VprodVersaoAtual)
                .FirstOrDefaultAsync();
            if (temVersao == versaoAtual)
            {
                return "NADA";
            }
            else
            {
                return temVersao;
            }
        }
        else
        {
            return "SEMPERMISSAO";
        }
    }

    public async Task<IEnumerable<TbVersaoProduto>> GetHistoricoAtualizacaoProduto(string nomeProduto)
    {
        return await _versaoProduto
            .Where(vp => vp.ProCodigoNavigation.ProNome == nomeProduto
                      //&& vp.VprodVersaoAtual == versaoAtual
                      ).ToListAsync();
    }

    public async Task<int> GetStatus(string guid, string aliasProduto, int dias)
    {
        //1° SE O CLIENTE ESTÁ ATIVO ? OK : NÃO PODE ACESSAR
        //2° SE O CLIENTE TEM O PRODUTO ? OK : NÃO TEM O PRODUTO
        //3° SE O CLIENTE ESTÁ NA TABELA DE CONGELAMENTO && O PRODUTO ESTÁ NA TABELA DE CONGELAMENTO
        //		? DATA DE CONGELAMENTO > HOJE
        //			? OK - RETURN - QTD DIAS ATÉ CONGELAMENTO : NÃO PODE ACESSAR
        //		: BUSCAR TABELA CONTAS RECEBER (PRIMEIRO VENCIMENTO QUE A DATA SEJA MAIOR DO QUE HOJE)
        //			? OK - RETURN - QTD DIAS ATÉ VENCIMENTO
        //				: OK - RETURN - 30 DIAS
        //4° INSERIR NA TABELA DE FORNECIMENTO DE SENHA SEMPRE QUE O NUMERO DE DIAS > NUMERO DO PARÂMETRO && RETORNO DIAS != 30 

        int retorno = 0;

        var retornoPessoaAtivaProduto = await _pessoa
            .Where(p => p.PesGuid == guid && p.PesStatus == "C"
            && p.PesCliente == "S"
                                          && p.TbProdutoClientes.Any(pc => pc.ProCodigo == _produto
            .Where(p => p.ProAlias == aliasProduto).FirstOrDefault().ProCodigo)).Select(x => new
            {
                x.PesCodigo,
                x.TbProdutoClientes.Where(pc => pc.ProCodigo == _produto
                                    .Where(p => p.ProAlias == aliasProduto).FirstOrDefault().ProCodigo).FirstOrDefault().ProcliCodigo
            }).FirstOrDefaultAsync();

        if (retornoPessoaAtivaProduto != null)
        {
            var estaCongelado = await _congelamento
                .Where(p => p.PesCodigo == retornoPessoaAtivaProduto.PesCodigo
                            && p.ProcliCodigo == retornoPessoaAtivaProduto.ProcliCodigo).FirstOrDefaultAsync();

            if (estaCongelado != null)
            {
                if (estaCongelado.CngDatacongelamento > DateTime.Today)
                {
                    retorno = (int)(estaCongelado.CngDatacongelamento - DateTime.Today).Value.TotalDays;
                    return await AddSolicitacaoSenha(retorno, dias, aliasProduto, retornoPessoaAtivaProduto);
                }

                return 0;
            }
            else
            {
                var primeiroVencimento = await _contasReceber
                    .Where(p => p.PesCodigo == retornoPessoaAtivaProduto.PesCodigo && p.CtrDatavencimento > DateTime.Parse(DateTime.Today.ToString()))
                    .OrderBy(p => p.CtrDatavencimento)
                    .Select(z => z.CtrDatavencimento)
                    .FirstOrDefaultAsync() ?? DateTime.MinValue;

                if (primeiroVencimento != null)
                {
                    var data = DateOnly.Parse(DateTime.Today.ToString());
                    retorno = (int)primeiroVencimento.CompareTo(data);
                    // = (int)(primeiroVencimento - DateTime.Today).Value.TotalDays;
                    return await AddSolicitacaoSenha(retorno, dias, aliasProduto, retornoPessoaAtivaProduto);
                }
                else
                {
                    return 30;
                }
            }
        }

        return retorno;

        /*if ((retorno > dias) && retorno != 30)
		{
			TbSolicitacaoSenha solicitacaoSenha = new TbSolicitacaoSenha
			{
				SsData = DateTime.Now,
				SsDias = dias,
				PesCodigo = retornoPessoaAtivaProduto.PesCodigo,
				ProCodigo = _context.TbProdutos.Where(p => p.ProAlias == aliasProduto).FirstOrDefault().ProCodigo
			};
			var retornoSenhas = await _context.TbSolicitacaoSenhas.FirstOrDefaultAsync();
			if (retornoSenhas != null)
			{
				solicitacaoSenha.SsCodigo = await _context.TbSolicitacaoSenhas.MaxAsync(ss => ss.SsCodigo) + 1;
			} else
			{
				solicitacaoSenha.SsCodigo = 1;
			}

			_context.TbSolicitacaoSenhas.Add(solicitacaoSenha);
			await _context.SaveChangesAsync();
		} else
		{
			retorno = 30;
		}

		return retorno;*/
    }

    public async Task<bool> GetStatusChave(string chave, string aliasProduto)
    {
        //1° SE A CHAVE EXISTE ? OK : NOTFOUND
        //2° SE A CHAVE ESTÁ ATIVA ? OK : BADREQUEST
        return await _produtoChave
                .AnyAsync(p => p.ChaKey == chave
                        && p.ProcliCodigoNavigation.ProCodigoNavigation.ProAlias == aliasProduto
                        && p.ChaAtivo == true);
    }
    private async Task<int> AddSolicitacaoSenha(int retorno, int dias, string alias, dynamic pessoa)
    {
        if ((retorno > dias) && retorno != 30)
        {
            TbSolicitacaoSenha solicitacaoSenha = new TbSolicitacaoSenha
            {
                SsData = DateTime.Now,
                SsDias = dias,
                PesCodigo = pessoa.PesCodigo,
                ProCodigo = _produto.Where(p => p.ProAlias == alias).FirstOrDefault().ProCodigo
            };
            var retornoSenhas = await _solicitacaoSenha.FirstOrDefaultAsync();
            if (retornoSenhas != null)
            {
                solicitacaoSenha.SsCodigo = await _solicitacaoSenha.MaxAsync(ss => ss.SsCodigo) + 1;
            }
            else
            {
                solicitacaoSenha.SsCodigo = 1;
            }

            //_solicitacaoSenha.Add(solicitacaoSenha);
            //await Add(solicitacaoSenha);

            _context.Set<TbSolicitacaoSenha>().Add(solicitacaoSenha);
            await _context.SaveChangesAsync();

            return retorno;

        }
        else
        {
            return retorno;
        }
    }
}
