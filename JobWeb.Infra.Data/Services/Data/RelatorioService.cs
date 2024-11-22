using ApiJob.Enumerations;
using ApiJob.Interfaces;
using JobWeb.Core.Interfaces.Services.Data;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using OmegaCloudAPI.Models.Relatorios.ECAD;

namespace JobWeb.Infra.Data.Services.Data;

public class RelatorioService : GenericService<TbEcad>, IRelatorioService
{
    private readonly DbSet<TbEcad> _ecad;
    private readonly DbSet<TbGravadora> _gravadora;
    private readonly DbSet<TbEmpresa> _empresa;
    private readonly DbSet<TbConfiguracao> _configuracao;
    private readonly DbSet<TbMusica> _musica;
    private readonly DbSet<TbConfiguracaoempresa> _configuraEmpresa;

    public RelatorioService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _ecad = context.Set<TbEcad>();
        _gravadora = context.Set<TbGravadora>();
        _empresa = context.Set<TbEmpresa>();
        _configuracao = context.Set<TbConfiguracao>();
        _musica = context.Set<TbMusica>();
        _configuraEmpresa = context.Set<TbConfiguracaoempresa>();
    }

    public async Task<IEnumerable<RelatorioECAD>> GerarRelatorioECAD(string de, string ate, string horaDe, string horaAte, int codigoMusica)
    {
        bool periodoTodos = de == "Todos" || ate == "Todos" ? true : false;
        bool todasMusicas = codigoMusica == 0 ? true : false;
        //bool horarioTodos = horarioDas == "Todos" || horarioAte == "Todos" ? true : false;

        //DateTime horarioDeConvetido = DateTime.ParseExact(de, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        //DateTime horarioAteConvetido = DateTime.ParseExact(ate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        DateTime horarioDeConvetido = DateTime.Parse(de);
        DateTime horarioAteConvetido = DateTime.Parse(ate);

        TimeSpan horarioDe = DateTime.Parse(horaDe).TimeOfDay;
        TimeSpan horarioAte = DateTime.Parse(horaAte).TimeOfDay;

        Console.WriteLine("horarioDeConvetido: " + horarioDeConvetido);

        var retorno = await _ecad.Where(e => (periodoTodos ? true : e.EcaData >= horarioDeConvetido
                                                 && e.EcaData <= horarioAteConvetido)
                                                 && (todasMusicas ? true : e.MusCodigo == codigoMusica)
                                                 /* && TimeSpan.Parse(e.EcaHora).CompareTo(horarioDe) > 1
                                                  && TimeSpan.Parse(e.EcaHora).CompareTo(horarioAte) < 1*/)
            .Select(e => new RelatorioECAD
            {
                Compositor = e.MusCodigoNavigation.MusCompositor,
                Nome = e.MusCodigoNavigation.MusNome,
                Interprete = e.MusCodigoNavigation.MusInterprete,
                Duracao = e.MusCodigoNavigation.MusTempo,
                Data = e.EcaData,
                Hora = e.EcaHora,
            }).ToListAsync();
        return retorno.Where(r => TimeSpan.Parse(r.Hora) >= horarioDe && TimeSpan.Parse(r.Hora) <= horarioAte);
    }

    public async Task<IEnumerable<DadosArquivoEXP>> GetDadosArquivoEXP(string de, string ate)
    {
        return await _ecad
                .Where(e => e.EcaData >= DateTime.Parse(de)
                         && e.EcaData <= DateTime.Parse(ate))
                .Select(x => new DadosArquivoEXP
                {
                    EcaCodigo = x.EcaCodigo,
                    MusNome = x.EcaMusnomecompleto ?? x.MusCodigoNavigation.MusNome,
                    MusInterprete = x.MusInterprete ?? x.MusCodigoNavigation.MusInterprete,
                    MusCompositor = x.MusCompositor ?? x.MusCodigoNavigation.MusCompositor,
                    MusGravadora = x.MusGravadora ?? (_gravadora
                                                .Where(g => g.GraCodigo == x.MusCodigoNavigation.GraCodigo)
                                                .Select(g => g.GraNome).FirstOrDefault()
                                                    ?? _gravadora.Select(g => g.GraNome)
                                                                            .FirstOrDefault()),
                    MusCodigo = x.MusCodigo ?? 0,
                    Ano = x.MusCodigoNavigation.MusAno ?? 0,
                    Data = x.EcaData,
                    Hora = x.EcaHora
                }).OrderBy(x => x.Data)
          .ThenBy(x => x.Hora)
          .ToListAsync();
    }

    public async Task<DadosEmpresa> GetDadosEmpresa(int empCodigo)
    {
        return await _empresa
            .Where(e => e.EmpCodigo == empCodigo)
            .Select(x => new DadosEmpresa
            {
                Cnpj = x.EmpCnpj,
                Email = x.EmpEmail,
                RazaoSocial = x.EmpRazaosocial,
                CodigoECAD = _configuraEmpresa
                    .Where(c => c.EmpCodigo == empCodigo)
                    .Select(c => c.CfeCodigoEcad)
                    .FirstOrDefault(),
                Versao = _configuracao
                    .Select(c => c.CfgVersao)
                    .FirstOrDefault()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<NomeMusicas> GetMusicas(string busca, int codigoEmpresa)
    {
        return await _musica
            .Where(m => m.EmpCodigo == codigoEmpresa && (busca != "" ? m.MusNome == busca : true))
            .Select(m => new NomeMusicas
            {
                MusCodigo = m.MusCodigo,
                MusNome = m.MusNome,
                MusInterprete = m.MusInterprete,
                MusTempo = m.MusTempo
            })
            .FirstOrDefaultAsync();
    }
}
