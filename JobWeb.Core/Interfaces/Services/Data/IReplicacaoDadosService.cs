using ApiReplicaDados;
using JobWeb.Infra.Data.Repositories;
using OmegaCloudAPI;
using OmegaCloudAPI.Models.Replicacao;
using OmegaCloudAPI.Models.Replicacao.OmegaPlay;

namespace JobWeb.Core.Interfaces.Services.Data;

public interface IReplicacaoDadosService : IGenericService<TbReplicacao>
{
    //GET
    Task<TbReplicacao> GetReplicacaoItens(int codigoAlias);
    Task<TbReplicacao> GetItemReplicacao(int codigoItem);
    Task<IEnumerable<TbReplicacao>> GetReplicacoes();

    //SINCRONIZAR => GET
    Task<TbEmpresa> GetRetornoEmpresaFinanceiro(int codigoEmpresa);
    //SINCRONIZAR => POST
    Task<int> ReplicarDados(List<Replicacao> comandoSql);
    Task SincronizarDadosEmpresa(TbEmpresaFinanceiro empresa);
    Task SincronizarDadosUsuario(List<TbUsuarioFinanceiro> usuario);
    Task SincronizarDadosPessoa(List<TbPessoaFinanceiro> pessoa);
    Task SincronizarDadosAtividade(List<TbAtividadeFinanceiro> atividade);
    Task SincronizarDadosContrato(List<TbContratoFinanceiro> contrato);
    Task SincronizarDadosContasReceber(List<TbContasreceberFinanceiro> contasReceber);
    Task SincronizarDadosContasReceberIten(List<TbContasreceberitenFinanceiro> contasReceberIten);
    Task SincronizarDadosContasPagar(List<TbContaspagarFinanceiro> contasPagar);
    Task SincronizarDadosContasPagarIten(List<TbContaspagaritenFinanceiro> contasPagarIten);
    Task SincronizarDadosPlanoContas(List<TbPlanodecontaFinanceiro> planodeconta);
    Task SincronizarDadosCentroContas(List<TbCentrocontaFinanceiro> centroconta);
    Task SincronizarDadosContasInvestimento(List<TbContainvestimentoFinanceiro> contaInvestimento);
    Task SincronizarDadosContaCorrente(List<TbContacorrenteFinanceiro> contaCorrente);
    Task SincronizarDadosBancos(List<TbBancoFinanceiro> banco);
    Task SincronizarECAD(List<TbEcadOmegaPlay> ecad, int codigoEmpresa);
    Task SincronizarGravadora(List<TbGravadoraOmegaPlay> gravadora, int codigoEmpresa);
    Task SincronizarMusicas(List<TbMusicaOmegaPlay> musicas, int codigoEmpresa);
    Task SincronizarRateio(List<TbRateioFinanceiro> rateio);
    Task SincronizarRateioContasReceber(List<TbRateiocontasreceberFinanceiro> rateioContasReceber);
    Task SincronizarBoleto(List<TbBoletoFinanceiro> boleto);

    //UPDATE
    Task UpdateItensReplicacao(TbReplicacao itemReplicacao);

    //DELETE
    Task DeleteItensReplicacao(int codigoExclusao);
}
