using ApiJob.Enumerations;
using ApiJob.Interfaces;
using ApiJob.Servicos;
using JobWeb.Core.Interfaces;
using JobWeb.Core.Interfaces.Services.Data;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //congelamento.CngCodigo = await _dbCongelamento.FirstOrDefaultAsync() != null ? 1 : await _dbCongelamento.MaxAsync(c => c.CngCodigo) + 1;
        var congelamentoExistente = await _dbCongelamento.FirstOrDefaultAsync();
        if (congelamentoExistente != null)
        {
            congelamento.CngCodigo = await _dbCongelamento.MaxAsync(c => c.CngCodigo) + 1;
        }
        else
        {
            congelamento.CngCodigo = 1;
        }
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

        List<TbContasreceber> contasReceber = [];
        if (!devedores.IsNullOrEmpty())
            foreach (var devedor in devedores)
            {
                switch (devedor.CtrDatavencimento.Value.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        contasReceber.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(2) <= dataHoje));
                        break;
                    case DayOfWeek.Tuesday:
                        contasReceber.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(2) <= dataHoje));
                        break;
                    case DayOfWeek.Wednesday:
                        contasReceber.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(2) <= dataHoje));
                        break;
                    case DayOfWeek.Thursday:
                        contasReceber.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(2) <= dataHoje));
                        break;
                    case DayOfWeek.Friday:
                        contasReceber.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(4) <= dataHoje));
                        break;
                    case DayOfWeek.Saturday:
                        contasReceber.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(4) <= dataHoje));
                        break;
                    case DayOfWeek.Sunday:
                        contasReceber.Add(devedores.FirstOrDefault(d => d.CtrDatavencimento.Value.AddDays(3) <= dataHoje));
                        break;
                }
            }

        if (!contasReceber.IsNullOrEmpty())
        {
            EnviarEmails email = new EnviarEmails();
            string nomes = "";
            foreach (var itemContasReceber in contasReceber)
            {
                var produtosCliente = await _dbRateioContasReceber
                    .Where(rcr => rcr.CtrCodigo.Equals(itemContasReceber.CtrCodigo))
                    .Select(rcr => rcr.RatCodigoNavigation.RatAlias).ToListAsync();

                foreach (var produto in produtosCliente)
                {
                    IEnumerable<TbProdutoChave> chavesCongelamento = await _dbProdutoCliente
                        .Where(pc => pc.ProCodigoNavigation.ProAlias.Equals(produto)
                            && (pc.PesCodigoNavigation.PesStatus.Equals("A") && pc.PesCodigoNavigation.PesCliente.Equals("S")))
                        .SelectMany(pc => pc.TbProdutoChaves).ToListAsync();

                    foreach (var congelar in chavesCongelamento)
                    {
                        try
                        {
                            TbCongelamento congelamentos = new TbCongelamento();
                            congelamentos.ChaCodigo = congelar.ChaCodigo;
                            congelamentos.CngStatus = "A";
                            congelamentos.CngCongelado = false;
                            congelamentos.CngAvisocobranca = false;
                            congelamentos.CngAvisocongelamento = false;
                            congelamentos.CngAvisoprotesto = false;
                            congelamentos.CngDataavisocobranca = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(5).ToString());
                            congelamentos.CngDataavisocongelamento = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(10).ToString());
                            congelamentos.CngDataavisoprotesto = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(30).ToString());
                            congelamentos.CngDatacongelamento = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(15).ToString());
                            congelamentos.CngDescricao = "Devedor adicionado via Job.";
                            congelamentos.PesCodigo = itemContasReceber.PesCodigo;
                            congelamentos.CtrCodigo = itemContasReceber.CtrCodigo;
                            congelamentos.CtrCodigoNavigation = itemContasReceber;
                            congelamentos.ProcliCodigo = congelar.ProcliCodigo;
                            await InserirCongelamento(congelamentos);

                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                        nomes += itemContasReceber.PesCodigoNavigation.PesNome + ", ";
                    }
                }

                //IEnumerable<TbRateiocontasreceber> produtoRateio = await _dbRateioContasReceber
                //    .Where(rcr => rcr.CtrCodigo.Equals(itemContasReceber.CtrCodigo)
                //        && rcr.RatCodigoNavigation.RatAlias
                //            .Equals(itemContasReceber.PesCodigoNavigation.TbProdutoClientes
                //                .Select(pc => pc.ProCodigoNavigation.ProAlias).FirstOrDefault()))
                //    .ToListAsync();

                //foreach (var rateio in produtoRateio)
                //{
                //    IEnumerable<TbProdutoChave> chavesCongelamento = await _dbProdutoCliente
                //        .Where(pc => pc.ProCodigoNavigation.ProAlias.Equals(rateio)
                //            && (pc.PesCodigoNavigation.PesStatus.Equals("A") && pc.PesCodigoNavigation.PesCliente.Equals("S")))
                //        .SelectMany(pc => pc.TbProdutoChaves).ToListAsync();

                //    foreach (var congelar in chavesCongelamento)
                //    {
                //        try
                //        {
                //            TbCongelamento congelamentos = new TbCongelamento();
                //            congelamentos.ChaCodigo = congelar.ChaCodigo;
                //            congelamentos.CngStatus = "A";
                //            congelamentos.CngCongelado = false;
                //            congelamentos.CngAvisocobranca = false;
                //            congelamentos.CngAvisocongelamento = false;
                //            congelamentos.CngAvisoprotesto = false;
                //            congelamentos.CngDataavisocobranca = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(5).ToString());
                //            congelamentos.CngDataavisocongelamento = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(10).ToString());
                //            congelamentos.CngDataavisoprotesto = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(30).ToString());
                //            congelamentos.CngDatacongelamento = DateTime.Parse(itemContasReceber.CtrDatavencimento.Value.AddDays(15).ToString());
                //            congelamentos.CngDescricao = "Devedor adicionado via Job.";
                //            congelamentos.PesCodigo = itemContasReceber.PesCodigo;
                //            congelamentos.CtrCodigo = itemContasReceber.CtrCodigo;
                //            congelamentos.CtrCodigoNavigation = itemContasReceber;
                //            congelamentos.ProcliCodigo = congelar.ProcliCodigo;
                //            await InserirCongelamento(congelamentos);

                //        }
                //        catch (Exception e)
                //        {
                //            throw new Exception(e.Message);
                //        }
                //        nomes += itemContasReceber.PesCodigoNavigation.PesNome + ", ";
                //    }
                //}
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
