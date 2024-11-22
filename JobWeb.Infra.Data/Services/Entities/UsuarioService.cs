using ApiJob.Enumerations;
using ApiJob.Interfaces;
using JobWeb.Core.Interfaces.Services.Entities;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using JobWeb.Infra.Data.Services.Data;
using Microsoft.EntityFrameworkCore;
using OmegaCloudAPI.Models.OmegaAgendaComercial;
using OmegaCloudAPI.Models.OmegaCloud.Login;
using OmegaCloudAPI.Models.OmegaCloud.Pessoa;
using OmegaCloudAPI.Models.OmegaCloud.Usuario;

namespace JobWeb.Infra.Data.Services.Entities;

public class UsuarioService : GenericService<TbUsuario>, IUsuarioService
{
    private readonly DbSet<TbUsuario> _usuario;
    private readonly DbSet<TbUsuarioPessoa> _usuarioPessoa;
    private readonly DbSet<TbPessoa> _pessoa;

    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _context = context;
    }

    public async Task<IEnumerable<UsuarioNome>> GetUsuarios(int codigoEmpresa)
    {
        return await _usuario
            .Join(_usuarioPessoa, u => u.UsuCodigo, up => up.UsuCodigo, (u, up) => new { u, up })
            .Where(x => x.up.EmpCodigo == codigoEmpresa)
            .Select(z => new UsuarioNome
            {
                UsuCodigo = z.u.UsuCodigo,
                UsuLogin = z.u.UsuLogin,
                UsuNome = z.u.UsuNome,
                UsuImagem = z.u.UsuImagem
            }).ToListAsync();
    }

    public async Task<IEnumerable<PessoaUsuario>> GetPessoas(int codigoEmpresa)
    {
        return await _pessoa
            .Where(p => !p.TbUsuarioPessoas.Any()
                && p.EmpCodigo == codigoEmpresa
                && p.PesFuncionario == "S"
                && p.PesStatus == "C")
            .Select(x => new PessoaUsuario
            {
                PesCodigo = x.PesCodigo,
                PesNome = x.PesNome,
                PesEmail = x.PesEmail,
                PesCelular = x.PesCelular,
                PesFone = x.PesFone,
            })
            .ToListAsync();
    }

    public async Task<TbUsuario> GetUsuario(int codigoUsuario)
    {
        return await _usuario.FindAsync(codigoUsuario);
    }

    public async Task<UsuarioDados> GetUsuarioDados(int codigoUsuario)
    {
        return await _usuario.Where(u => u.UsuCodigo == codigoUsuario).Select(x => new UsuarioDados
        {
            UsuCodigo = x.UsuCodigo,
            UsuNome = x.UsuNome,
            UsuLogin = x.UsuLogin,
            UsuEmail = x.UsuEmail,
            UsuSenha = x.UsuSenha,
            UsuFone = x.UsuFone,
            UsuCelular = x.UsuCelular,
            UsuPesCodigo = x.UsuPesCodigo,
            UsuAcessoAgendaComercial = x.UsuAcessoAgendaComercial,
            UsuAcessoCloud = x.UsuAcessoCloud,
            UsuAcessoComercial = x.UsuAcessoComercial,
            UsuAcessoFinanceiro = x.UsuAcessoFinanceiro,
            UsuAcessoLocucao = x.UsuAcessoLocucao,
            UsuAcessoMusical = x.UsuAcessoMusical,
            UsuAcessoTask = x.UsuAcessoTask,
            UsuIdFirebase = x.UsuIdFirebase,
            UsuImagem = x.UsuImagem,
        }).FirstOrDefaultAsync();
    }

    public async Task<TbUsuarioPessoa> GetUsuarioPessoa(int codigoUsuario)
    {
        return await _usuarioPessoa.FindAsync(codigoUsuario);
    }

    public async Task<LoginDados> GetDadosUsuario(int codigoUsuario)
    {
        return await _usuario
            .Where(u => u.UsuCodigo == codigoUsuario)
            .Select(x => new LoginDados
            {
                PesCodigo = x.UsuPesCodigo,
                UsuCodigo = x.UsuCodigo,
                usuEmail = x.UsuEmail,
                UsuNome = x.UsuNome,
                usuImagem = x.UsuImagem,
            }).FirstOrDefaultAsync();
    }

    public async Task AddUsuario(TbUsuario usuario)
    {
        if (usuario.UsuCodigo == 0)
        {
            var lastUsuario = await _usuario.FirstOrDefaultAsync();
            if (lastUsuario != null)
            {
                usuario.UsuCodigo = await _usuario.MaxAsync(up => up.UsuCodigo) + 1;
            }
            else
            {
                usuario.UsuCodigo = 1;
            }
        }
        else
        {
            await UpdateUsuario(usuario);
        }
        Add(usuario);
        //await _context.SaveChangesAsync();
    }

    public async Task AddUsuarioEmpresa(TbUsuarioPessoa usuario)
    {
        if (usuario.UspCodigo == 0)
        {
            var lastUsuario = await _usuarioPessoa.FirstOrDefaultAsync();
            if (lastUsuario != null)
            {
                usuario.UspCodigo = await _usuarioPessoa.MaxAsync(up => up.UspCodigo) + 1;
            }
            else
            {
                usuario.UspCodigo = 1;
            }
        }
        else
        {
            await UpdateUsuarioPessoa(usuario);
        }
        _usuarioPessoa.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<string> AddImagemUsuario(PessoaImagem imagem)
    {
        if (imagem == null)
            return "Arquivo inválido ou inexistente !";

        //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagens");
        //var filePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Imagens\\Usuario", Guid.NewGuid() + imagem.Imagem.FileName);
        var FileName = Guid.NewGuid() + imagem.Imagem.FileName;
        var filePath = Path.Combine("..\\..\\PainelOmegaCloud\\imagens\\usuario", FileName);
        //var filePath = Path.Combine("imagens\\usuario", FileName);
        using (var fileStrem = new FileStream(filePath, FileMode.Create))
        {
            await imagem.Imagem.CopyToAsync(fileStrem);
        }
        filePath = Path.Combine("..\\..\\OmegaTask2\\imagens\\usuario", FileName);
        //var filePath = Path.Combine("imagens\\usuario", FileName);
        using (var fileStrem = new FileStream(filePath, FileMode.Create))
        {
            await imagem.Imagem.CopyToAsync(fileStrem);
        }
        return FileName;
    }

    public async Task UpdateUsuario(TbUsuario usuario)
    {
        _usuario.Update(usuario);
        /*_context.TbUsuarios.Entry(usuario).State = EntityState.Modified;*/
        //await _context.SaveChangesAsync();
    }

    public async Task UpdateUsuarioPessoa(TbUsuarioPessoa usuario)
    {
        _usuarioPessoa.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUsuario(TbUsuario usuario)
    {
        var retorno = await _usuarioPessoa.Where(up => up.UsuCodigo == usuario.UsuCodigo).FirstOrDefaultAsync();
        if (retorno != null)
        {
            _usuarioPessoa.Remove(retorno);
            await _context.SaveChangesAsync();
        }
        _usuario.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}
