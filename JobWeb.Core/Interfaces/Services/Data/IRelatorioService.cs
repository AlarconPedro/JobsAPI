using OmegaCloudAPI.Models.Relatorios.ECAD;

namespace JobWeb.Core.Interfaces.Services.Data;

public interface IRelatorioService
{
    //RELATORIO ECAD
    Task<IEnumerable<RelatorioECAD>> GerarRelatorioECAD(string de, string ate, string horaDe, string horaAte, int codigoMusica);
    Task<IEnumerable<DadosArquivoEXP>> GetDadosArquivoEXP(string de, string ate);
    Task<DadosEmpresa> GetDadosEmpresa(int empCodigo);
    Task<NomeMusicas> GetMusicas(string busca, int codigoEmpresa);
}
