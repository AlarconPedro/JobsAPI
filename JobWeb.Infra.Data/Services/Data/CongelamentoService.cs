using ApiJob.Enumerations;
using ApiJob.Interfaces;
using ApiJob.Servicos;
using JobWeb.Core.Interfaces.Services.Data;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace JobWeb.Infra.Data.Services.Data;

public class CongelamentoService<T> : GenericService<TbCongelamento>, ICongelamentoService<TbCongelamento>
{
    private readonly DbSet<TbCongelamento> _dbCongelamento;
    private readonly DbSet<TbProdutoCliente> _dbProdutoCliente;
    private readonly DbSet<TbContasreceber> _dbContasReceber;
    private readonly DbSet<TbProdutoChave> _dbProdutoChave;
    private readonly DbSet<TbRateiocontasreceber> _dbRateioContasReceber;

    public CongelamentoService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _dbCongelamento = context.Set<TbCongelamento>();
        _dbProdutoCliente = context.Set<TbProdutoCliente>();
        _dbContasReceber = context.Set<TbContasreceber>();
        _dbProdutoChave = context.Set<TbProdutoChave>();
        _dbRateioContasReceber = context.Set<TbRateiocontasreceber>();
    }

    public async Task<TbCongelamento> BuscarCodigoChave(int cngCodigo) => await _dbCongelamento.Where(c => c.CngCodigo.Equals(cngCodigo)).FirstOrDefaultAsync();

    public async Task LiberarChaves(int cngCodigo)
    {
        TbCongelamento dados = await BuscarCodigoChave(cngCodigo);
        if (dados != null)
        {
            TbProdutoChave chave = await _dbProdutoChave.Where(pc => pc.ChaCodigo.Equals(dados.ChaCodigo)).FirstOrDefaultAsync();
            chave.ChaAtivo = true;
            await Update(dados);
            dados.CngCongelado = false;
            await Update(dados);
        }
    }

    public async Task CongelarChaves(int cngCodigo)
    {
        TbCongelamento dados = await BuscarCodigoChave(cngCodigo);
        if (dados != null)
        {
            TbProdutoChave chave = await _dbProdutoChave.Where(pc => pc.ChaCodigo.Equals(dados.ChaCodigo)).FirstOrDefaultAsync();
            chave.ChaAtivo = false;
            await Update(dados);
            dados.CngCongelado = true;
            await Update(dados);
        }
    }

    public async Task InserirCongelamento(TbCongelamento congelamento) => await Add(congelamento);
    
    public async Task InativarCongelamento(int cngCodigo)
    {
        TbCongelamento congelamento = await _dbCongelamento
                        .Where(c => c.CngCodigo.Equals(cngCodigo)).FirstOrDefaultAsync();
        congelamento.CngStatus = "I";
        await Update(congelamento);
        await LiberarChaves(cngCodigo);
    }

    public async Task AtivarCongelamento(int cngCodigo)
    {
        TbCongelamento congelamento = await _dbCongelamento
                        .Where(c => c.CngCodigo.Equals(cngCodigo)).FirstOrDefaultAsync();
        congelamento.CngStatus = "A";
        await Update(congelamento);
        //await CongelarChaves(cngCodigo);
    }

    public async Task EnviaAvisos()
    {
        DateTime dataAtual = DateTime.Now;
        EnviarEmails email = new EnviarEmails();
        IEnumerable<TbCongelamento> congelamentos = await _dbCongelamento
            .Where(c => c.CngStatus.Equals("A") && c.CngCongelado.Equals(false))
            .ToListAsync();
        foreach (var congelamento in congelamentos)
        {
            //Enviar email de avisos
            switch (dataAtual)
            {
                case var d when d.Equals(congelamento.CngDataavisocobranca):
                    email.enviaEmail(congelamento.ProcliCodigoNavigation.PesCodigoNavigation.PesNome, "AvisoCobranca");
                    congelamento.CngAvisocobranca = true;
                    await Update(congelamento);
                    break;
                case var d when d.Equals(congelamento.CngDataavisocongelamento):
                    email.enviaEmail(congelamento.ProcliCodigoNavigation.PesCodigoNavigation.PesNome, "AvisoCongelamento");
                    congelamento.CngAvisocongelamento = true;
                    await Update(congelamento);
                    break;
                case var d when d.Equals(congelamento.CngDataavisoprotesto):
                    email.enviaEmail(congelamento.ProcliCodigoNavigation.PesCodigoNavigation.PesNome, "AvisoProtesto");
                    congelamento.CngAvisoprotesto = true;
                    await Update(congelamento);
                    break;
                case var d when d.Equals(congelamento.CngDatacongelamento):
                    email.enviaEmail(congelamento.ProcliCodigoNavigation.PesCodigoNavigation.PesNome, "Congelamento");
                    await CongelarChaves(congelamento.CngCodigo);
                    congelamento.CngCongelado = true;
                    await Update(congelamento);
                    break;
            }
        }
    }

    public async Task<string> VerificaDevedores()
    {
        //System.Diagnostics.Process.Start("notepad.exe", "/p C:\\Omega\\teste.txt");
        //return "Foi";
        DateOnly dataHoje = DateOnly.FromDateTime(DateTime.Now);

        IEnumerable<TbContasreceber> devedores =
                await _dbContasReceber
            .Where(cr => cr.CtrDatavencimento <= dataHoje
                && (!cr.CtrSituacao.Equals("P") && !cr.CtrSituacao.Equals("I"))
                && (cr.PesCodigoNavigation.PesStatus.Equals("C") && cr.PesCodigoNavigation.PesCliente.Equals("S"))
                && cr.TbRateiocontasrecebers
                    .Any(rcr => rcr.CtrCodigoNavigation.PesCodigo.Equals(cr.PesCodigo)
                        && rcr.RatCodigoNavigation.RatAlias
                            .Equals(cr.PesCodigoNavigation.TbProdutoClientes
                                .Select(pc => pc.ProCodigoNavigation.ProAlias).FirstOrDefault()))
                        && !_dbCongelamento
                            .Any(c => c.CtrCodigo.Equals(cr.CtrCodigo)
                                && c.CngStatus.Equals("A"))).ToListAsync();

        List<TbContasreceber> contasReceber = [];
        if (!devedores.IsNullOrEmpty())
            foreach (var devedor in devedores)
            {
                switch (devedor.CtrDatavencimento.Value.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        contasReceber.Add(devedor.CtrDatavencimento.Value.AddDays(2) <= dataHoje ? devedor : null);
                        break;
                    case DayOfWeek.Tuesday:
                        contasReceber.Add(devedor.CtrDatavencimento.Value.AddDays(2) <= dataHoje ? devedor : null);
                        break;
                    case DayOfWeek.Wednesday:
                        contasReceber.Add(devedor.CtrDatavencimento.Value.AddDays(2) <= dataHoje ? devedor : null);
                        break;
                    case DayOfWeek.Thursday:
                        contasReceber.Add(devedor.CtrDatavencimento.Value.AddDays(2) <= dataHoje ? devedor : null);
                        break;
                    case DayOfWeek.Friday:
                        contasReceber.Add(devedor.CtrDatavencimento.Value.AddDays(4) <= dataHoje ? devedor : null);
                        break;
                    case DayOfWeek.Saturday:
                        contasReceber.Add(devedor.CtrDatavencimento.Value.AddDays(4) <= dataHoje ? devedor : null);
                        break;
                    case DayOfWeek.Sunday:
                        contasReceber.Add(devedor.CtrDatavencimento.Value.AddDays(3) <= dataHoje ? devedor : null);
                        break;
                }
            }

        if (!contasReceber.IsNullOrEmpty())
        {
            EnviarEmails email = new EnviarEmails();
            string nomes = "";

            if (contasReceber != null)
            foreach (var itemContasReceber in contasReceber)
            {
                    //buscar chaves dos produtos do cliente
                    //var produtosCliente = await _dbProdutoCliente
                    //    .Where(pc => pc.ProCodigoNavigation.ProAlias
                    //        .Equals(_dbRateioContasReceber.Where(rcr => rcr.CtrCodigo.Equals(itemContasReceber.CtrCodigo))
                    //            .Select(rcr => rcr.RatCodigoNavigation.RatAlias).Any())
                    //        && (pc.PesCodigoNavigation.PesStatus.Equals("C") && pc.PesCodigoNavigation.PesCliente.Equals("S"))
                    //        && (pc.TbProdutoChaves.Any(x => x.ChaAtivo.Equals(true))))
                    //    .Select(pc => pc.ProCodigoNavigation.ProAlias).ToListAsync();
                    List<string> produtosCliente = [];
                    if (itemContasReceber != null)
                        produtosCliente = await _dbRateioContasReceber
                            .Where(rcr => rcr.CtrCodigo.Equals(itemContasReceber.CtrCodigo))
                            .Select(rcr => rcr.RatCodigoNavigation.RatAlias).ToListAsync();
                    else
                        continue;

                if (!produtosCliente.IsNullOrEmpty())
                foreach (var produto in produtosCliente)
                {
                    List<TbProdutoChave> chavesCongelamento = await _dbProdutoCliente
                        .Where(pc => pc.ProCodigoNavigation.ProAlias.Equals(produto)
                            && (pc.PesCodigoNavigation.PesStatus.Equals("C") && pc.PesCodigoNavigation.PesCliente.Equals("S"))
                            && (pc.TbProdutoChaves.Any(x => x.ChaAtivo.Equals(true))))
                        .SelectMany(pc => pc.TbProdutoChaves).ToListAsync();

                    foreach (var congelar in chavesCongelamento)
                    {
                        try
                        {
                            TbCongelamento congelamentos = new TbCongelamento {
                                ChaCodigo = congelar.ChaCodigo,
                                ChaCodigoNavigation = congelar,
                                CngAvisocobranca = false,
                                CngAvisocongelamento = false,
                                CngAvisoprotesto = false,
                                CngCongelado = false,
                                CngDataavisocobranca = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(5).ToString()),
                                CngDataavisocongelamento = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(10).ToString()),
                                CngDataavisoprotesto = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(30).ToString()),
                                CngDatacongelamento = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(15).ToString()),
                                CngDescricao = "Devedor adicionado via Job.",
                                PesCodigo = itemContasReceber.PesCodigo,
                                CtrCodigo = itemContasReceber.CtrCodigo,
                                CtrCodigoNavigation = itemContasReceber,
                                ProcliCodigo = congelar.ProcliCodigo,
                                CngStatus = "A"
                            };
                            var congelamentoExistente = await _dbCongelamento.FirstOrDefaultAsync();
                            if (congelamentoExistente != null)
                            {
                                congelamentos.CngCodigo = await _dbCongelamento.MaxAsync(c => c.CngCodigo) + 1;
                            }
                            else
                            {
                                congelamentos.CngCodigo = 1;
                            }
                            await InserirCongelamento(congelamentos);
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                        nomes +=  _dbProdutoCliente.Where(pc => pc.PesCodigoNavigation.PesCodigo.Equals(itemContasReceber.PesCodigo)).Select(x => x.PesCodigoNavigation.PesNome) + ", ";
                    }
                }
            }
            email.enviaEmail(nomes, "AvisoCobranca");
            return $"{devedores.Count().ToString()} Devedores Encontrados !";
        }
        return "Nenhum Devedor Encontrado !";
    }

    public async Task<string> VerificaCongelados()
    {
        IEnumerable<int> congeladosPagos = await _dbCongelamento
             .Where(c => c.CtrCodigoNavigation.CtrSituacao.Equals("P"))
             .Select(x => x.CngCodigo).ToListAsync();

        if (!congeladosPagos.IsNullOrEmpty())
        {
            foreach (var congelado in congeladosPagos)
            {
                try
                {
                    await InativarCongelamento(congelado);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return $"{congeladosPagos.Count().ToString()} Congelamentos Pagos Encontrados !";
        }
        else
        {
            return "Nenhum Congelamento Pago Encontrado !";
        }
    }

    public async Task<int> InserirChavesGenericas()
    {
        var listaProdutosSemChave = await _dbProdutoCliente.Where(pc => !pc.TbProdutoChaves.Any()).ToListAsync();
        int qtdProdutos = listaProdutosSemChave.Count();
        foreach (var produto in listaProdutosSemChave)
        {
            var chave = new TbProdutoChave
            {
                ChaAtivo = true,
                ChaCodigo = _dbProdutoChave.Max(pc => pc.ChaCodigo) + 1,
                ChaKey = "GENÉRICA",
                ChaObersvacao = "Chave adicionada automaticamente para funcionamento do novo modo de validação",
                ProcliCodigo = produto.ProcliCodigo,
            };
            await _dbProdutoChave.AddAsync(chave);
        }
        return qtdProdutos;
    }
}
