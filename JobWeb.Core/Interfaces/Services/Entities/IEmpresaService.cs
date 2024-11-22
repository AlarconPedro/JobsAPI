using JobWeb.Infra.Data.Repositories;
using OmegaCloudAPI.Models.OmegaCloud.Empresa;

namespace JobWeb.Core.Interfaces.Services.Entities;

public interface IEmpresaService :IGenericService<TbEmpresa>
{
    //GET
    Task<IEnumerable<EmpresaDadosBasicos>> GetEmpresasLogin(int codigoPessoa);
    Task<IEnumerable<EmpresaDadosBasicos>> GetEmpresas();
}
