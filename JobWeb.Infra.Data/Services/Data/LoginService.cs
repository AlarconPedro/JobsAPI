using ApiJob.Enumerations;
using ApiJob.Interfaces;
using JobWeb.Core.Interfaces.Services.Data;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using OmegaCloudAPI.Models.OmegaCloud.Login;

namespace JobWeb.Infra.Data.Services.Data;

public class LoginService : GenericService<TbUsuario>, ILoginService
{
    private readonly DbSet<TbUsuario> _usuario;
    private readonly DbSet<TbUsuarioPessoa> _usuarioPessoa;

    public LoginService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _usuario = context.Set<TbUsuario>();
        _usuarioPessoa = context.Set<TbUsuarioPessoa>();
    }

    public async Task<LoginDados> Login(string codigoFirebase)
    {
        return await _usuario
            .Where(x => x.UsuIdFirebase == codigoFirebase)
            .Select(x => new LoginDados
            {
                EmpCodigo = _usuarioPessoa.FirstOrDefault(up => up.UsuCodigo == x.UsuCodigo).EmpCodigo,
                EmpNome = _usuarioPessoa.FirstOrDefault(up => up.UsuCodigo == x.UsuCodigo).EmpCodigoNavigation.EmpNome,
                PesCodigo = _usuarioPessoa.FirstOrDefault(up => up.UsuCodigo == x.UsuCodigo).PesCodigo,
                PesNome = _usuarioPessoa.FirstOrDefault(up => up.UsuCodigo == x.UsuCodigo).PesCodigoNavigation.PesNome,
                UsuCodigo = x.UsuCodigo,
                UsuNome = x.UsuNome,
                usuEmail = x.UsuEmail,
                usuImagem = x.UsuImagem,
                UsuAcessoComercial = x.UsuAcessoComercial,
                UsuAcessoMusical = x.UsuAcessoMusical,
                UsuAcessoLocucao = x.UsuAcessoLocucao,
                UsuAcessoAgendaComercial = x.UsuAcessoAgendaComercial,
                UsuAcessoTask = x.UsuAcessoTask,
                UsuAcessoFinanceiro = x.UsuAcessoFinanceiro,
                UsuAcessoCloud = x.UsuAcessoCloud
            }).FirstOrDefaultAsync();
    }
}
