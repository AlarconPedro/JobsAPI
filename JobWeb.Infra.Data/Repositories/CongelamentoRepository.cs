using ApiJob.Enumerations;
using ApiJob.Interfaces;
using ApiJob.Servicos;
using JobWeb.Core.Interfaces;
using JobWeb.Core.Interfaces.Services;
using JobWeb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWeb.Infra.Data.Repositories;

public class CongelamentoRepository<T> : GenericRepository<TbCongelamento>, ICongelamentoRespository<TbCongelamento>
{
    private readonly DbSet<TbCongelamento> _dbCongelamento;
    private readonly DbSet<TbProdutoCliente> _dbProdutoCliente;
    private readonly DbSet<TbContasreceber> _dbContasReceber;
    private readonly DbSet<TbProdutoChave> _dbProdutoChave;

    public CongelamentoRepository(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _dbCongelamento = context.Set<TbCongelamento>();
        _dbProdutoCliente = context.Set<TbProdutoCliente>();
        _dbContasReceber = context.Set<TbContasreceber>();
        _dbProdutoChave = context.Set<TbProdutoChave>();
    }

    public async Task<(int, TbCongelamento?)> BuscarCodigoChave(int cngCodigo)
    {
        TbCongelamento congelamento = await _dbCongelamento
                        .Where(c => c.CngCodigo.Equals(cngCodigo)).FirstOrDefaultAsync();
        int codigoChave = await _dbProdutoCliente
             .Where(pc => pc.ProCodigoNavigation.ProCodigo.Equals(congelamento.ProcliCodigoNavigation.ProCodigo)
                 && pc.TbProdutoChaves.Any(pc => pc.ChaCodigo.Equals(congelamento.ChaCodigo)))
             .Select(x => x.TbProdutoChaves.Where(pc => pc.ChaCodigo.Equals(congelamento.ChaCodigo)).FirstOrDefault().ChaCodigo)
             .FirstOrDefaultAsync();

        return (codigoChave, congelamento);
    }

    public async Task LiberarChaves(int cngCodigo)
    {
        (int, TbCongelamento?) dados = await BuscarCodigoChave(cngCodigo);
        if (dados.Item1 != 0)
        {
            TbProdutoChave chave = await _dbProdutoChave.Where(pc => pc.ChaCodigo.Equals(dados.Item1)).FirstOrDefaultAsync();
            chave.ChaAtivo = true;
            await Update(dados.Item2);
        }
    }

    public async Task CongelarChaves(int cngCodigo)
    {
        (int, TbCongelamento?) dados = await BuscarCodigoChave(cngCodigo);
        if (dados.Item1 != 0)
        {
            TbProdutoChave chave = await _dbProdutoChave.Where(pc => pc.ChaCodigo.Equals(dados.Item1)).FirstOrDefaultAsync();
            chave.ChaAtivo = false;
            await Update(dados.Item2);
        }
    }

    public async Task InserirCongelamento(TbCongelamento congelamento)
    {
        congelamento.CngCodigo = await _dbCongelamento.FirstOrDefaultAsync() != null ? 1 : await _dbCongelamento.MaxAsync(c => c.CngCodigo) + 1;
        await Add(congelamento);
        await CongelarChaves(congelamento.CngCodigo);
    }

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
        await LiberarChaves(cngCodigo);
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
                && !cr.CtrSituacao.Equals("P")
                && cr.TbRateiocontasrecebers
                    .Any(rcr => rcr.CtrCodigoNavigation.PesCodigo.Equals(cr.PesCodigo)
                        && rcr.RatCodigoNavigation.RatAlias
                            .Equals(cr.PesCodigoNavigation.TbProdutoClientes
                                .Select(pc => pc.ProCodigoNavigation.ProAlias).FirstOrDefault()))
                        && !_dbCongelamento
                            .Any(c => c.CtrCodigo.Equals(cr.CtrCodigo)
                                && c.CngStatus.Equals("A"))).ToListAsync();

        List<TbContasreceber> inserirCongelamento = [];
        if (!devedores.IsNullOrEmpty())
            foreach (var devedor in devedores)
            {
                switch (devedor.CtrDatavencimento.Value.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        inserirCongelamento.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(2) <= dataHoje));
                        break;
                    case DayOfWeek.Tuesday:
                        inserirCongelamento.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(2) <= dataHoje));
                        break;
                    case DayOfWeek.Wednesday:
                        inserirCongelamento.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(2) <= dataHoje));
                        break;
                    case DayOfWeek.Thursday:
                        inserirCongelamento.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(2) <= dataHoje));
                        break;
                    case DayOfWeek.Friday:
                        inserirCongelamento.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(4) <= dataHoje));
                        break;
                    case DayOfWeek.Saturday:
                        inserirCongelamento.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(4) <= dataHoje));
                        break;
                    case DayOfWeek.Sunday:
                        inserirCongelamento.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(3) <= dataHoje));
                        break;
                }
            }

        if (!inserirCongelamento.IsNullOrEmpty())
        {
            EnviarEmails email = new EnviarEmails();
            string nomes = "";
            foreach (var congelar in inserirCongelamento)
            {
                try
                {
                    //await congelamentoService.CongelarChaves(congelar.CtrCodigo);
                    DateTime dataAtual = DateTime.Now;
                    TbCongelamento congelamento = new TbCongelamento();
                    congelamento.ChaCodigo = _dbProdutoChave
                            .Where(pc => pc.ProcliCodigoNavigation.PesCodigo
                            .Equals(congelar.PesCodigo)).Select(pc => pc.ChaCodigo).FirstOrDefault();
                    congelamento.CngStatus = "A";
                    congelamento.CngCongelado = false;
                    congelamento.CngAvisocobranca = false;
                    congelamento.CngAvisocongelamento = false;
                    congelamento.CngAvisoprotesto = false;
                    congelamento.CngDataavisocobranca = dataAtual.AddDays(5);
                    congelamento.CngDataavisocongelamento = dataAtual.AddDays(10);
                    congelamento.CngDataavisoprotesto = dataAtual.AddDays(30);
                    congelamento.CngDatacongelamento = dataAtual.AddDays(15);
                    congelamento.CngDescricao = "Devedor adicionado via Job.";
                    congelamento.PesCodigo = congelar.PesCodigo;
                    congelamento.ProcliCodigo = _dbProdutoChave
                            .Where(pc => pc.ProcliCodigoNavigation.PesCodigo
                            .Equals(congelar.PesCodigo)).Select(pc => pc.ProcliCodigo).FirstOrDefault();
                    await InserirCongelamento(congelamento);

                    //{
                    //    CngCodigo = _dbCongelamento.FirstOrDefault() != null ? 1 : (_dbCongelamento.Max(c => c.CngCodigo) + 1),
                    //    ChaCodigo = _dbProdutoChave
                    //            .Where(pc => pc.ProcliCodigoNavigation.PesCodigo
                    //            .Equals(congelar.PesCodigo)).Select(pc => pc.ChaCodigo).FirstOrDefault(),
                    //    CngStatus = "A",
                    //    CngCongelado = false,
                    //    CngAvisocobranca = false,
                    //    CngAvisocongelamento = false,
                    //    CngAvisoprotesto = false,
                    //    CngDataavisocobranca = dataAtual.AddDays(5),
                    //    CngDataavisocongelamento = dataAtual.AddDays(10),
                    //    CngDataavisoprotesto = dataAtual.AddDays(30),
                    //    CngDatacongelamento = dataAtual.AddDays(15),
                    //    CngDescricao = "Devedor adicionado via Job.",
                    //    PesCodigo = congelar.PesCodigo,
                    //    ProcliCodigo = _dbProdutoChave
                    //            .Where(pc => pc.ProcliCodigoNavigation.PesCodigo
                    //            .Equals(congelar.PesCodigo)).Select(pc => pc.ProcliCodigo).FirstOrDefault()
                    //};
                    //await InserirCongelamento(congelamento);
                    //Enviar Email de Aviso de Cobrança
                    //email.enviaEmail(congelar.PesCodigoNavigation.PesNome);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                nomes += congelar.PesCodigoNavigation.PesNome + ", ";
                //nomes.Add(congelar.PesCodigoNavigation.PesNome);
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
}
