using JobWeb.Infra.Data.Repositories;
using OmegaCloudAPI.Models.OmegaAgendaComercial;
using OmegaCloudAPI.Models.OmegaCloud.Login;
using OmegaCloudAPI.Models.OmegaCloud.Pessoa;
using OmegaCloudAPI.Models.OmegaCloud.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWeb.Core.Interfaces.Services.Entities;

public interface IUsuarioService : IGenericService<TbUsuario>
{
    //GET
    Task<IEnumerable<UsuarioNome>> GetUsuarios(int codigoEmpresa);
    Task<IEnumerable<PessoaUsuario>> GetPessoas(int codigoEmpresa);
    Task<TbUsuario> GetUsuario(int codigoEmpresa);
    Task<UsuarioDados> GetUsuarioDados(int codigoUsuario);
    Task<TbUsuarioPessoa> GetUsuarioPessoa(int codigoUsuario);
    Task<LoginDados> GetDadosUsuario(int codigoUsuario);
    //POST
    Task AddUsuario(TbUsuario usuario);
    Task AddUsuarioEmpresa(TbUsuarioPessoa usuarios);
    Task<string> AddImagemUsuario(PessoaImagem pessoaImagem);
    //PUT
    Task UpdateUsuario(TbUsuario usuario);
    Task UpdateUsuarioPessoa(TbUsuarioPessoa usuario);
    //DELETE
    Task DeleteUsuario(TbUsuario usuario);
}
