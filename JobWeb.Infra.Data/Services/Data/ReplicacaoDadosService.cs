using ApiJob.Enumerations;
using ApiJob.Interfaces;
using ApiReplicaDados;
using JobWeb.Core.Interfaces.Services.Data;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OmegaCloudAPI;
using OmegaCloudAPI.Models.Replicacao;
using OmegaCloudAPI.Models.Replicacao.OmegaPlay;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWeb.Infra.Data.Services.Data;

public class ReplicacaoDadosServcice : GenericService<TbReplicacao>, IReplicacaoDadosService
{
    private readonly AppDbContext _context;

    public ReplicacaoDadosServcice(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _context = context;
    }

    private async Task DisableEnableTrigger(string comandoSql, string tipo)
    {
        var tipoComando = comandoSql.Substring(0, 6).ToUpper();
        var tabela = comandoSql.ToUpper().Contains("TB_EMPRESA") ? "TB_EMPRESA"
                        : comandoSql.ToUpper().Contains("TB_PESSOAS") ? "TB_PESSOAS"
                        : comandoSql.ToUpper().Contains("TB_USUARIO") ? "TB_USUARIO"
                        : comandoSql.ToUpper().Contains("TB_CONTRATOS") ? "TB_CONTRATOS"
                        : comandoSql.ToUpper().Contains("TB_CONTASRECEBER") ? "TB_CONTASRECEBER"
                        : comandoSql.ToUpper().Contains("TB_ATIVIDADE") ? "TB_ATIVIDADE"
                        : "";

        switch (tipoComando)
        {
            case "INSERT":
                if (tabela == "TB_EMPRESA")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER ReplicaEmpresa ON {tabela}");
                    await _context.SaveChangesAsync();

                }
                else if (tabela == "TB_PESSOAS")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER ReplicaPessoas ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_USUARIOS")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER ReplicaUsuario ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_ATIVIDADE")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER ReplicaAtividade ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_CONTRATOS")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER ReplicaContratos ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_CONTASRECEBER")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER ReplicaContasReceber ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                break;
            case "UPDATE":
                if (tabela == "TB_EMPRESA")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER UpdateEmpresa ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_PESSOAS")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER UpdatePessoas ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_USUARIOS")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER UpdateUsuario ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_ATIVIDADE")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER UpdateAtividade ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_CONTRATOS")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER UpdateContratos ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_CONTASRECEBER")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER UpdateContasReceber ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                break;
            case "DELETE":
                if (tabela == "TB_EMPRESA")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER DeleteEmpresa ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_PESSOAS")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER DeletePessoas ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_USUARIOS")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER DeleteUsuario ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_ATIVIDADE")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER DeleteAtividade ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_CONTRATOS")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER DeleteContratos ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                else if (tabela == "TB_CONTASRECEBER")
                {
                    _context.Database.ExecuteSqlRaw($"{tipo} TRIGGER DeleteContasReceber ON {tabela}");
                    await _context.SaveChangesAsync();
                }
                break;
        }
    }

    //POST
    public async Task<TbEmpresa> GetRetornoEmpresaFinanceiro(int codigoEmpresa)
    {
        return await _context.TbEmpresas.FindAsync(codigoEmpresa);
    }
    public async Task<TbPessoa> GetRetornoPessoaFinanceiro(int codigoPessoa)
    {
        return await _context.TbPessoas.FindAsync(codigoPessoa);
    }

    public async Task<TbUsuario> GetRetornoUsuarioFinanceiro(int codigoUsuario)
    {
        return await _context.TbUsuarios.FindAsync(codigoUsuario);
    }

    public async Task<TbAtividade> GetRetornoAtividadeFinanceiro(int codigoAtividade)
    {
        return await _context.TbAtividades.FindAsync(codigoAtividade);
    }


    public async Task SincronizarDadosEmpresa(TbEmpresaFinanceiro empresa)
    {
        if (empresa.EMP_ALIAS_CODIGO == null)
            empresa.EMP_ALIAS_CODIGO = 0;

        if (empresa.EMP_ALIAS_CODIGO != 0)
        {
            //int codigoEmpresa = empresa.EMP_CODIGO;
            //var codigoAlias = empresa.EmpAliasCodigo;
            var empresaEncontrada = await _context.TbEmpresas.AsNoTracking()
                .FirstOrDefaultAsync(e => e.EmpCodigo == empresa.EMP_CODIGO);
            if (empresaEncontrada != null)
            {
                await DisableEnableTrigger("UPDATE TB_EMPRESA", "DISABLE");
                _context.TbEmpresas.Update(new TbEmpresa
                {
                    EmpCodigo = empresa.EMP_CODIGO,
                    EmpNome = empresa.EMP_NOME,
                    EmpCidade = empresa.EMP_CIDADE,
                    EmpCnpj = empresa.EMP_CNPJ,
                    EmpBairro = empresa.EMP_BAIRRO,
                    EmpEmail = empresa.EMP_EMAIL,
                    EmpCep = empresa.EMP_CEP,
                    EmpFone = empresa.EMP_FONE,
                    EmpEndereco = empresa.EMP_ENDERECO,
                    EmpInscricao = empresa.EMP_INSCRICAO,
                    EmpFax = empresa.EMP_FAX,
                    EmpNumero = empresa.EMP_NUMERO,
                    EmpStatus = empresa.EMP_STATUS,
                    EmpUf = empresa.EMP_UF,
                    EmpWeb = empresa.EMP_WEB,
                    EmpRazaosocial = empresa.EMP_RAZAOSOCIAL,
                    EmpLogomarca = empresa.EMP_LOGOMARCA,
                    EmpDenominacao = empresa.EMP_DENOMINACAO,
                    EmpLinha1 = empresa.EMP_LINHA1,
                    EmpLinha2 = empresa.EMP_LINHA2,
                    EmpLinha3 = empresa.EMP_LINHA3,
                    EmpLinha4 = empresa.EMP_LINHA4,
                    EmpLinha5 = empresa.EMP_LINHA5,
                    EmpContadoruf = empresa.EMP_CONTADORUF,
                    EmpContadorbairro = empresa.EMP_CONTADORBAIRRO,
                    EmpContadorcargo = empresa.EMP_CONTADORCARGO,
                    EmpContadorcep = empresa.EMP_CONTADORCARGO,
                    EmpContadorcidade = empresa.EMP_CONTADORCIDADE,
                    EmpContadorcpf = empresa.EMP_CONTADORCPF,
                    EmpContadorcrc = empresa.EMP_CONTADORCRC,
                    EmpContadoremail = empresa.EMP_CONTADOREMAIL,
                    EmpContadorendereco = empresa.EMP_CONTADORENDERECO,
                    EmpContadorfone = empresa.EMP_CONTADORFONE,
                    EmpContadornome = empresa.EMP_CONTADORNOME,
                    EmpContadornumero = empresa.EMP_CONTADORNUMERO,
                    EmpAliasCodigo = empresa.EMP_ALIAS_CODIGO,
                });
                await _context.SaveChangesAsync();
                await DisableEnableTrigger("UPDATE TB_EMPRESA", "ENABLE");
            }
        }
        else
        {
            var containEmpresa = await _context.TbEmpresas.FirstOrDefaultAsync();
            if (containEmpresa != null)
            {
                var codigoMax = await _context.TbEmpresas.MaxAsync(e => e.EmpAliasCodigo) + 1;
                empresa.EMP_CODIGO = int.Parse($"{codigoMax}{empresa.EMP_CODIGO}");
                empresa.EMP_ALIAS_CODIGO = codigoMax;
            }
            else
            {
                int codigoEmpresa = int.Parse($"{1000}{empresa.EMP_CODIGO}");
                empresa.EMP_CODIGO = codigoEmpresa;
                empresa.EMP_ALIAS_CODIGO = 1000;
            }

            await DisableEnableTrigger("INSERT TB_EMPRESA", "DISABLE");
            _context.TbEmpresas.Add(new TbEmpresa
            {
                EmpCodigo = empresa.EMP_CODIGO,
                EmpNome = empresa.EMP_NOME,
                EmpCidade = empresa.EMP_CIDADE,
                EmpCnpj = empresa.EMP_CNPJ,
                EmpBairro = empresa.EMP_BAIRRO,
                EmpEmail = empresa.EMP_EMAIL,
                EmpCep = empresa.EMP_CEP,
                EmpFone = empresa.EMP_FONE,
                EmpEndereco = empresa.EMP_ENDERECO,
                EmpInscricao = empresa.EMP_INSCRICAO,
                EmpFax = empresa.EMP_FAX,
                EmpNumero = empresa.EMP_NUMERO,
                EmpStatus = empresa.EMP_STATUS,
                EmpUf = empresa.EMP_UF,
                EmpWeb = empresa.EMP_WEB,
                EmpRazaosocial = empresa.EMP_RAZAOSOCIAL,
                EmpLogomarca = empresa.EMP_LOGOMARCA,
                EmpDenominacao = empresa.EMP_DENOMINACAO,
                EmpLinha1 = empresa.EMP_LINHA1,
                EmpLinha2 = empresa.EMP_LINHA2,
                EmpLinha3 = empresa.EMP_LINHA3,
                EmpLinha4 = empresa.EMP_LINHA4,
                EmpLinha5 = empresa.EMP_LINHA5,
                EmpContadoruf = empresa.EMP_CONTADORUF,
                EmpContadorbairro = empresa.EMP_CONTADORBAIRRO,
                EmpContadorcargo = empresa.EMP_CONTADORCARGO,
                EmpContadorcep = empresa.EMP_CONTADORCARGO,
                EmpContadorcidade = empresa.EMP_CONTADORCIDADE,
                EmpContadorcpf = empresa.EMP_CONTADORCPF,
                EmpContadorcrc = empresa.EMP_CONTADORCRC,
                EmpContadoremail = empresa.EMP_CONTADOREMAIL,
                EmpContadorendereco = empresa.EMP_CONTADORENDERECO,
                EmpContadorfone = empresa.EMP_CONTADORFONE,
                EmpContadornome = empresa.EMP_CONTADORNOME,
                EmpContadornumero = empresa.EMP_CONTADORNUMERO,
                EmpAliasCodigo = empresa.EMP_ALIAS_CODIGO,
            });
            await _context.SaveChangesAsync();
            await DisableEnableTrigger("INSERT TB_EMPRESA", "ENABLE");
        }
    }

    public async Task SincronizarDadosPessoa(List<TbPessoaFinanceiro> pessoas)
    {
        DisableEnableTrigger("INSERT TB_PESSOAS", "DISABLE");
        DisableEnableTrigger("UPDATE TB_PESSOAS", "DISABLE");
        foreach (var pessoa in pessoas)
        {

            var pessoaEncontrada = await _context.TbPessoas.AsNoTracking().FirstOrDefaultAsync(p => p.PesCodigo == pessoa.PES_CODIGO);
            if (pessoaEncontrada == null)
            {
                DateTime? dataAtualizada;
                if (pessoa.PES_CLIENTEDESDE != null)
                {
                    dataAtualizada = DateTime.ParseExact(s: pessoa.PES_CLIENTEDESDE, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
                }
                else
                {
                    dataAtualizada = null;
                }

                _context.TbPessoas.Add(new TbPessoa
                {
                    PesCodigo = pessoa.PES_CODIGO,
                    EmpCodigo = pessoa.EMP_CODIGO,
                    AtiCodigo = pessoa.ATI_CODIGO,
                    PesNome = pessoa.PES_NOME,
                    PesCelular = pessoa.PES_CELULAR,
                    PesFone = pessoa.PES_FONE,
                    PesBairro = pessoa.PES_BAIRRO,
                    PesCidade = pessoa.PES_CIDADE,
                    PesCliente = pessoa.PES_CLIENTE,
                    PesAnivdia = pessoa.PES_ANIVDIA,
                    PesAnivmes = pessoa.PES_ANIVMES,
                    PesCep = pessoa.PES_CEP,
                    PesCgccpf = pessoa.PES_CGCCPF,
                    PesEmail = pessoa.PES_EMAIL,
                    PesEndereco = pessoa.PES_ENDERECO,
                    PesClientedesde = dataAtualizada,
                    PesComissao = pessoa.PES_COMISSAO,
                    PesContato = pessoa.PES_CONTATO,
                    PesEstado = pessoa.PES_ESTADO,
                    PesFax = pessoa.PES_FAX,
                    PesFornecedor = pessoa.PES_FORNECEDOR,
                    PesFuncionario = pessoa.PES_FUNCIONARIO,
                    PesGuid = pessoa.PES_GUID,
                    PesInscricao = pessoa.PES_INSCRICAO,
                    PesNumero = pessoa.PES_NUMERO,
                    PesObservacao = pessoa.PES_OBSERVACAO,
                    PesPessoa = pessoa.PES_PESSOA,
                    PesStatus = pessoa.PES_STATUS,
                    PesRazaosocial = pessoa.PES_RAZAOSOCIAL,
                    PesVendedor = pessoa.PES_VENDEDOR,
                    PesWeb = pessoa.PES_WEB,
                    PesContatoFone = pessoa.PES_CONTATO_FONE,
                    PesContatoFuncao = pessoa.PES_CONTATO_FUNCAO,
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                DateTime? dataAtualizada;
                if (pessoa.PES_CLIENTEDESDE != null)
                {
                    dataAtualizada = DateTime.ParseExact(s: pessoa.PES_CLIENTEDESDE, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
                }
                else
                {
                    dataAtualizada = null;
                }

                _context.TbPessoas.Update(new TbPessoa
                {
                    PesCodigo = pessoa.PES_CODIGO,
                    EmpCodigo = pessoa.EMP_CODIGO,
                    AtiCodigo = pessoa.ATI_CODIGO,
                    PesNome = pessoa.PES_NOME,
                    PesCelular = pessoa.PES_CELULAR,
                    PesFone = pessoa.PES_FONE,
                    PesBairro = pessoa.PES_BAIRRO,
                    PesCidade = pessoa.PES_CIDADE,
                    PesCliente = pessoa.PES_CLIENTE,
                    PesAnivdia = pessoa.PES_ANIVDIA,
                    PesAnivmes = pessoa.PES_ANIVMES,
                    PesCep = pessoa.PES_CEP,
                    PesCgccpf = pessoa.PES_CGCCPF,
                    PesEmail = pessoa.PES_EMAIL,
                    PesEndereco = pessoa.PES_ENDERECO,
                    PesClientedesde = dataAtualizada,
                    PesComissao = pessoa.PES_COMISSAO,
                    PesContato = pessoa.PES_CONTATO,
                    PesEstado = pessoa.PES_ESTADO,
                    PesFax = pessoa.PES_FAX,
                    PesFornecedor = pessoa.PES_FORNECEDOR,
                    PesFuncionario = pessoa.PES_FUNCIONARIO,
                    PesGuid = pessoa.PES_GUID,
                    PesInscricao = pessoa.PES_INSCRICAO,
                    PesNumero = pessoa.PES_NUMERO,
                    PesObservacao = pessoa.PES_OBSERVACAO,
                    PesPessoa = pessoa.PES_PESSOA,
                    PesStatus = pessoa.PES_STATUS,
                    PesRazaosocial = pessoa.PES_RAZAOSOCIAL,
                    PesVendedor = pessoa.PES_VENDEDOR,
                    PesWeb = pessoa.PES_WEB,
                    PesContatoFone = pessoa.PES_CONTATO_FONE,
                    PesContatoFuncao = pessoa.PES_CONTATO_FUNCAO,
                });
                await _context.SaveChangesAsync();
            }
        }
        DisableEnableTrigger("INSERT TB_PESSOAS", "ENABLE");
        DisableEnableTrigger("UPDATE TB_PESSOAS", "ENABLE");
    }

    public async Task SincronizarDadosUsuario(List<TbUsuarioFinanceiro> usuarios)
    {
        await DisableEnableTrigger("INSERT TB_USUARIOS", "DISABLE");
        await DisableEnableTrigger("UPDATE TB_USUARIOS", "DISABLE");
        foreach (var usuario in usuarios)
        {
            var usuarioEncontrado = await _context.TbUsuarios.AsNoTracking().FirstOrDefaultAsync(u => u.UsuCodigo == usuario.USU_CODIGO);
            if (usuarioEncontrado == null)
            {
                _context.TbUsuarios.Add(new TbUsuario
                {
                    UsuCodigo = usuario.USU_CODIGO,
                    UsuNome = usuario.USU_NOME,
                    UsuEmail = usuario.USU_EMAIL,
                    UsuFone = usuario.USU_FONE,
                    UsuAutorizacaoacesso = usuario.USU_AUTORIZACAOACESSO,
                    UsuAcessoComercial = usuario.USU_ACESSO_COMERCIAL,
                    UsuAcessoLocucao = usuario.USU_ACESSO_LOCUCAO,
                    UsuAcessoMusical = usuario.USU_ACESSO_MUSICAL,
                    UsuBairro = usuario.USU_BAIRRO,
                    UsuCelular = usuario.USU_CELULAR,
                    UsuCep = usuario.USU_CEP,
                    UsuCidade = usuario.USU_CIDADE,
                    UsuDiaaniversario = usuario.USU_DIAANIVERSARIO,
                    UsuEndereco = usuario.USU_ENDERECO,
                    UsuFuncao = usuario.USU_FUNCAO,
                    UsuLogin = usuario.USU_LOGIN,
                    UsuObs = usuario.USU_OBS,
                    UsuMesaniversario = usuario.USU_MESANIVERSARIO,
                    UsuPerfilacesso = usuario.USU_PERFILACESSO,
                    UsuSenha = usuario.USU_SENHA,
                    UsuTipo = usuario.USU_TIPO,
                    UsuUf = usuario.USU_UF,
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbUsuarios.Update(new TbUsuario
                {
                    UsuCodigo = usuario.USU_CODIGO,
                    UsuNome = usuario.USU_NOME,
                    UsuEmail = usuario.USU_EMAIL,
                    UsuFone = usuario.USU_FONE,
                    UsuAutorizacaoacesso = usuario.USU_AUTORIZACAOACESSO,
                    UsuAcessoComercial = usuario.USU_ACESSO_COMERCIAL,
                    UsuAcessoLocucao = usuario.USU_ACESSO_LOCUCAO,
                    UsuAcessoMusical = usuario.USU_ACESSO_MUSICAL,
                    UsuBairro = usuario.USU_BAIRRO,
                    UsuCelular = usuario.USU_CELULAR,
                    UsuCep = usuario.USU_CEP,
                    UsuCidade = usuario.USU_CIDADE,
                    UsuDiaaniversario = usuario.USU_DIAANIVERSARIO,
                    UsuEndereco = usuario.USU_ENDERECO,
                    UsuFuncao = usuario.USU_FUNCAO,
                    UsuLogin = usuario.USU_LOGIN,
                    UsuObs = usuario.USU_OBS,
                    UsuMesaniversario = usuario.USU_MESANIVERSARIO,
                    UsuPerfilacesso = usuario.USU_PERFILACESSO,
                    UsuSenha = usuario.USU_SENHA,
                    UsuTipo = usuario.USU_TIPO,
                    UsuUf = usuario.USU_UF,
                });
                await _context.SaveChangesAsync();
            }
        }
        await DisableEnableTrigger("INSERT TB_USUARIOS", "ENABLE");
        await DisableEnableTrigger("UPDATE TB_USUARIOS", "ENABLE");
    }
    public async Task SincronizarDadosAtividade(List<TbAtividadeFinanceiro> atividades)
    {
        await DisableEnableTrigger("INSERT TB_ATIVIDADE", "DISABLE");
        await DisableEnableTrigger("UPDATE TB_ATIVIDADE", "DISABLE");
        foreach (var atividade in atividades)
        {
            var atividadeEncontrada = await _context.TbAtividades.AsNoTracking().FirstOrDefaultAsync(a => a.AtiCodigo == atividade.ATI_CODIGO);
            if (atividadeEncontrada == null)
            {
                _context.TbAtividades.Add(new TbAtividade
                {
                    AtiCodigo = atividade.ATI_CODIGO,
                    AtiNome = atividade.ATI_NOME,
                    EmpCodigo = atividade.EMP_CODIGO,
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbAtividades.Update(new TbAtividade
                {
                    AtiCodigo = atividade.ATI_CODIGO,
                    AtiNome = atividade.ATI_NOME,
                    EmpCodigo = atividade.EMP_CODIGO,
                });
                await _context.SaveChangesAsync();
            }
        }
        await DisableEnableTrigger("INSERT TB_ATIVIDADE", "ENABLE");
        await DisableEnableTrigger("UPDATE TB_ATIVIDADE", "ENABLE");
    }
    public async Task SincronizarDadosContrato(List<TbContratoFinanceiro> contratos)
    {
        await DisableEnableTrigger("INSERT TB_CONTRATOS", "DISABLE");
        await DisableEnableTrigger("UPDATE TB_CONTRATOS", "DISABLE");
        foreach (var contrato in contratos)
        {
            DateTime? dataAtualizada;
            if (contrato.CNT_DATA != null)
            {
                dataAtualizada = DateTime.ParseExact(s: contrato.CNT_DATA, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                dataAtualizada = null;
            }
            DateTime? dataAtualizadaInicio;
            if (contrato.CNT_INICIO != null)
            {
                dataAtualizadaInicio = DateTime.ParseExact(s: contrato.CNT_INICIO, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                dataAtualizadaInicio = null;
            }
            DateTime? dataAtualizadaFim;
            if (contrato.CNT_TERMINO != null)
            {
                dataAtualizadaFim = DateTime.ParseExact(s: contrato.CNT_TERMINO, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                dataAtualizadaFim = null;
            }

            var contratoEncontrado = await _context.TbContratos.AsNoTracking().FirstOrDefaultAsync(c => c.CntCodigo == contrato.CNT_CODIGO);
            if (contratoEncontrado == null)
            {
                _context.TbContratos.Add(new TbContrato
                {
                    CntCodigo = contrato.CNT_CODIGO,
                    CntBoleto = contrato.CNT_BOLETO,
                    CntData = dataAtualizada,
                    CntCodigocom = contrato.CNT_CODIGOCOM,
                    CntDomingo = contrato.CNT_DOMINGO,
                    CntDuplicata = contrato.CNT_DUPLICATA,
                    CntFaturado = contrato.CNT_FATURADO,
                    CntInicio = dataAtualizadaInicio,
                    CntNumero = contrato.CNT_NUMERO,
                    CntObservacao = contrato.CNT_OBSERVACAO,
                    CntOculto = contrato.CNT_OCULTO,
                    CntPi = contrato.CNT_PI,
                    CntProposto = contrato.CNT_PROPOSTO,
                    CntQtdinsercao = contrato.CNT_QTDINSERCAO,
                    CntQtdinsercaototal = contrato.CNT_QTDINSERCAOTOTAL,
                    CntQuarta = contrato.CNT_QUARTA,
                    CntQuinta = contrato.CNT_QUINTA,
                    CntSabado = contrato.CNT_SABADO,
                    CntSegunda = contrato.CNT_SEGUNDA,
                    CntSexta = contrato.CNT_SEXTA,
                    CntRealizado = contrato.CNT_REALIZADO,
                    CntTerca = contrato.CNT_TERCA,
                    CntTermino = dataAtualizadaFim,
                    CntRecibo = contrato.CNT_RECIBO,
                    CntSemregistro = contrato.CNT_SEMREGISTRO,
                    CntTipo = contrato.CNT_TIPO,
                    CntTipoveiculacao = contrato.CNT_TIPOVEICULACAO,
                    CntValorcontrato = contrato.CNT_VALORCONTRATO,
                    CntValorinsercao = contrato.CNT_VALORINSERCAO,
                    EmpCodigo = contrato.EMP_CODIGO,
                    PesCodigo = contrato.PES_CODIGO
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbContratos.Update(new TbContrato
                {
                    CntBoleto = contrato.CNT_BOLETO,
                    CntCodigo = contrato.CNT_CODIGO,
                    CntData = dataAtualizada,
                    CntCodigocom = contrato.CNT_CODIGOCOM,
                    CntDomingo = contrato.CNT_DOMINGO,
                    CntDuplicata = contrato.CNT_DUPLICATA,
                    CntFaturado = contrato.CNT_FATURADO,
                    CntInicio = dataAtualizadaInicio,
                    CntNumero = contrato.CNT_NUMERO,
                    CntObservacao = contrato.CNT_OBSERVACAO,
                    CntOculto = contrato.CNT_OCULTO,
                    CntPi = contrato.CNT_PI,
                    CntProposto = contrato.CNT_PROPOSTO,
                    CntQtdinsercao = contrato.CNT_QTDINSERCAO,
                    CntQtdinsercaototal = contrato.CNT_QTDINSERCAOTOTAL,
                    CntQuarta = contrato.CNT_QUARTA,
                    CntQuinta = contrato.CNT_QUINTA,
                    CntSabado = contrato.CNT_SABADO,
                    CntSegunda = contrato.CNT_SEGUNDA,
                    CntSexta = contrato.CNT_SEXTA,
                    CntRealizado = contrato.CNT_REALIZADO,
                    CntTerca = contrato.CNT_TERCA,
                    CntTermino = dataAtualizadaFim,
                    CntRecibo = contrato.CNT_RECIBO,
                    CntSemregistro = contrato.CNT_SEMREGISTRO,
                    CntTipo = contrato.CNT_TIPO,
                    CntTipoveiculacao = contrato.CNT_TIPOVEICULACAO,
                    CntValorcontrato = contrato.CNT_VALORCONTRATO,
                    CntValorinsercao = contrato.CNT_VALORINSERCAO,
                    EmpCodigo = contrato.EMP_CODIGO,
                    PesCodigo = contrato.PES_CODIGO
                });
                await _context.SaveChangesAsync();
            }
        }
        await DisableEnableTrigger("INSERT TB_CONTRATOS", "ENABLE");
        await DisableEnableTrigger("UPDATE TB_CONTRATOS", "ENABLE");
    }

    public async Task SincronizarDadosContasReceber(List<TbContasreceberFinanceiro> contasReceber)
    {
        await DisableEnableTrigger("INSERT TB_CONTASRECEBER", "DISABLE");
        await DisableEnableTrigger("UPDATE TB_CONTASRECEBER", "DISABLE");
        foreach (var contaReceber in contasReceber)
        {
            DateTime? data;
            if (contaReceber.CTR_DATA != null)
            {
                data = DateTime.ParseExact(s: contaReceber.CTR_DATA, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                data = null;
            }

            DateTime? dataVencimento;
            if (contaReceber.CTR_DATAVENCIMENTO != null)
            {
                dataVencimento = DateTime.ParseExact(s: contaReceber.CTR_DATAVENCIMENTO, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                dataVencimento = null;
            }

            DateTime? dataInicio;
            if (contaReceber.CTR_PERIODOINICIO != null)
            {
                dataInicio = DateTime.ParseExact(s: contaReceber.CTR_PERIODOINICIO, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                dataInicio = null;
            }

            DateTime? dataFim;
            if (contaReceber.CTR_PERIODOFIM != null)
            {
                dataFim = DateTime.ParseExact(s: contaReceber.CTR_PERIODOFIM, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                dataFim = null;
            }

            DateTime? dataVencimentoBase;
            if (contaReceber.CTR_DATAVENCIMENTOBASE != null)
            {
                dataVencimentoBase = DateTime.ParseExact(s: contaReceber.CTR_DATAVENCIMENTOBASE, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                dataVencimentoBase = null;
            }

            var contasReceberEncontrada = await _context.TbContasrecebers.AsNoTracking().FirstOrDefaultAsync(c => c.CtrCodigo == contaReceber.CTR_CODIGO);
            if (contasReceberEncontrada == null)
            {

                _context.TbContasrecebers.Add(new TbContasreceber
                {
                    CntCodigo = contaReceber.CNT_CODIGO,
                    EmpCodigo = contaReceber.EMP_CODIGO,
                    CcoCodigo = contaReceber.CCO_CODIGO,
                    PlcCodigo = contaReceber.PLC_CODIGO,
                    CtrBoleto = contaReceber.CTR_BOLETO,
                    CtrCodigo = contaReceber.CTR_CODIGO,
                    CtrCodigomovimento = contaReceber.CTR_CODIGOMOVIMENTO,
                    CtrBoletoimpresso = contaReceber.CTR_BOLETOIMPRESSO,
                    CtrData = data,
                    CtrDatavencimento = dataVencimento,
                    CtrDatavencimentobase = dataVencimentoBase,
                    CtrDuplicata = contaReceber.CTR_DUPLICATA,
                    CtrHistorico = contaReceber.CTR_HISTORICO,
                    CtrNossonumero = contaReceber.CTR_NOSSONUMERO,
                    CtrNumdoc = contaReceber.CTR_NUMDOC,
                    CtrNumeronf = contaReceber.CTR_NUMERONF,
                    CtrNumrecibo = contaReceber.CTR_NUMRECIBO,
                    CtrObservacao = contaReceber.CTR_OBSERVACAO,
                    CtrParcela = contaReceber.CTR_PARCELA,
                    CtrPeriodofim = dataFim,
                    CtrPeriodoinicio = dataInicio,
                    CtrPrevisao = contaReceber.CTR_PREVISAO,
                    CtrRecibo = contaReceber.CTR_RECIBO,
                    CtrSemregistro = contaReceber.CTR_SEMREGISTRO,
                    CtrSituacao = contaReceber.CTR_SITUACAO,
                    CtrSituacaoautorizacao = contaReceber.CTR_SITUACAOAUTORIZACAO,
                    CtrTipomovimento = contaReceber.CTR_TIPOMOVIMENTO,
                    CtrValor = contaReceber.CTR_VALOR,
                    PesCodigo = contaReceber.PES_CODIGO,
                    UsuCodigo = contaReceber.USU_CODIGO,
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbContasrecebers.Update(new TbContasreceber
                {
                    CntCodigo = contaReceber.CNT_CODIGO,
                    EmpCodigo = contaReceber.EMP_CODIGO,
                    CcoCodigo = contaReceber.CCO_CODIGO,
                    PlcCodigo = contaReceber.PLC_CODIGO,
                    CtrBoleto = contaReceber.CTR_BOLETO,
                    CtrCodigo = contaReceber.CTR_CODIGO,
                    CtrCodigomovimento = contaReceber.CTR_CODIGOMOVIMENTO,
                    CtrBoletoimpresso = contaReceber.CTR_BOLETOIMPRESSO,
                    CtrData = data,
                    CtrDatavencimento = dataVencimento,
                    CtrDatavencimentobase = dataVencimentoBase,
                    CtrDuplicata = contaReceber.CTR_DUPLICATA,
                    CtrHistorico = contaReceber.CTR_HISTORICO,
                    CtrNossonumero = contaReceber.CTR_NOSSONUMERO,
                    CtrNumdoc = contaReceber.CTR_NUMDOC,
                    CtrNumeronf = contaReceber.CTR_NUMERONF,
                    CtrNumrecibo = contaReceber.CTR_NUMRECIBO,
                    CtrObservacao = contaReceber.CTR_OBSERVACAO,
                    CtrParcela = contaReceber.CTR_PARCELA,
                    CtrPeriodofim = dataFim,
                    CtrPeriodoinicio = dataInicio,
                    CtrPrevisao = contaReceber.CTR_PREVISAO,
                    CtrRecibo = contaReceber.CTR_RECIBO,
                    CtrSemregistro = contaReceber.CTR_SEMREGISTRO,
                    CtrSituacao = contaReceber.CTR_SITUACAO,
                    CtrSituacaoautorizacao = contaReceber.CTR_SITUACAOAUTORIZACAO,
                    CtrTipomovimento = contaReceber.CTR_TIPOMOVIMENTO,
                    CtrValor = contaReceber.CTR_VALOR,
                    PesCodigo = contaReceber.PES_CODIGO,
                    UsuCodigo = contaReceber.USU_CODIGO,
                });
                await _context.SaveChangesAsync();
            }
        }
        await DisableEnableTrigger("INSERT TB_CONTASRECEBER", "ENABLE");
        await DisableEnableTrigger("UPDATE TB_CONTASRECEBER", "ENABLE");
    }

    public async Task SincronizarDadosContasReceberIten(List<TbContasreceberitenFinanceiro> contasReceberIten)
    {
        foreach (var contaReceberIten in contasReceberIten)
        {
            DateTime? dataPago;
            if (contaReceberIten.CRI_DATAPAGO != null)
            {
                dataPago = DateTime.ParseExact(s: contaReceberIten.CRI_DATAPAGO, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                dataPago = null;
            }

            var contasReceberItenEncontrada = await _context.TbContasreceberitens.AsNoTracking().FirstOrDefaultAsync(c => c.CriCodigo == contaReceberIten.CRI_CODIGO);
            if (contasReceberItenEncontrada == null)
            {
                _context.TbContasreceberitens.Add(new TbContasreceberiten
                {
                    CriCodigo = contaReceberIten.CRI_CODIGO,
                    CriConciliado = contaReceberIten.CRI_CONCILIADO,
                    CriDatapago = dataPago,
                    CriDesconto = contaReceberIten.CRI_DESCONTO,
                    CriHorapago = contaReceberIten.CRI_HORAPAGO,
                    CriJuros = contaReceberIten.CRI_JUROS,
                    CriMulta = contaReceberIten.CRI_MULTA,
                    CriTipopag = contaReceberIten.CRI_TIPOPAG,
                    CriValorpago = contaReceberIten.CRI_VALORPAGO,
                    CtrCodigo = contaReceberIten.CTR_CODIGO
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbContasreceberitens.Update(new TbContasreceberiten
                {
                    CriCodigo = contaReceberIten.CRI_CODIGO,
                    CriConciliado = contaReceberIten.CRI_CONCILIADO,
                    CriDatapago = dataPago,
                    CriDesconto = contaReceberIten.CRI_DESCONTO,
                    CriHorapago = contaReceberIten.CRI_HORAPAGO,
                    CriJuros = contaReceberIten.CRI_JUROS,
                    CriMulta = contaReceberIten.CRI_MULTA,
                    CriTipopag = contaReceberIten.CRI_TIPOPAG,
                    CriValorpago = contaReceberIten.CRI_VALORPAGO,
                    CtrCodigo = contaReceberIten.CTR_CODIGO
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarDadosContasPagar(List<TbContaspagarFinanceiro> contasPagar)
    {
        foreach (var contaPagar in contasPagar)
        {
            DateTime? data;
            if (contaPagar.CTP_DATA != null)
            {
                data = DateTime.ParseExact(s: contaPagar.CTP_DATA, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                data = null;
            }

            DateTime? dataVencimento;
            if (contaPagar.CTP_DATAVENCIMENTO != null)
            {
                dataVencimento = DateTime.ParseExact(s: contaPagar.CTP_DATAVENCIMENTO, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                dataVencimento = null;
            }

            var contasPagarEncontrada = await _context.TbContaspagars.AsNoTracking().FirstOrDefaultAsync(c => c.CtpCodigo == contaPagar.CTP_CODIGO);
            if (contasPagarEncontrada == null)
            {
                _context.TbContaspagars.Add(new TbContaspagar
                {
                    CtpCodigo = contaPagar.CTP_CODIGO,
                    CtpCodigomovimento = contaPagar.CTP_CODIGOMOVIMENTO,
                    CtpData = data,
                    CcoCodigo = contaPagar.CCO_CODIGO,
                    CtpDatavencimento = dataVencimento,
                    CtpHistorico = contaPagar.CTP_HISTORICO,
                    CtpNumdoc = contaPagar.CTP_NUMDOC,
                    CtpObservacao = contaPagar.CTP_OBSERVACAO,
                    CtpParcela = contaPagar.CTP_PARCELA,
                    CtpPrevisao = contaPagar.CTP_PREVISAO,
                    CtpSituacao = contaPagar.CTP_SITUACAO,
                    CtpTipomovimento = contaPagar.CTP_TIPOMOVIMENTO,
                    CtpValor = contaPagar.CTP_VALOR,
                    PesCodigo = contaPagar.PES_CODIGO,
                    UsuCodigo = contaPagar.USU_CODIGO,
                    CtpTotalparcela = contaPagar.CTP_TOTALPARCELA,
                    PlcCodigo = contaPagar.PLC_CODIGO,
                    EmpCodigo = contaPagar.EMP_CODIGO,
                    CtpSituacaoautorizacao = contaPagar.CTP_SITUACAOAUTORIZACAO
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbContaspagars.Update(new TbContaspagar
                {
                    CtpCodigo = contaPagar.CTP_CODIGO,
                    CtpCodigomovimento = contaPagar.CTP_CODIGOMOVIMENTO,
                    CtpData = data,
                    CcoCodigo = contaPagar.CCO_CODIGO,
                    CtpDatavencimento = dataVencimento,
                    CtpHistorico = contaPagar.CTP_HISTORICO,
                    CtpNumdoc = contaPagar.CTP_NUMDOC,
                    CtpObservacao = contaPagar.CTP_OBSERVACAO,
                    CtpParcela = contaPagar.CTP_PARCELA,
                    CtpPrevisao = contaPagar.CTP_PREVISAO,
                    CtpSituacao = contaPagar.CTP_SITUACAO,
                    CtpTipomovimento = contaPagar.CTP_TIPOMOVIMENTO,
                    CtpValor = contaPagar.CTP_VALOR,
                    PesCodigo = contaPagar.PES_CODIGO,
                    UsuCodigo = contaPagar.USU_CODIGO,
                    CtpTotalparcela = contaPagar.CTP_TOTALPARCELA,
                    PlcCodigo = contaPagar.PLC_CODIGO,
                    EmpCodigo = contaPagar.EMP_CODIGO,
                    CtpSituacaoautorizacao = contaPagar.CTP_SITUACAOAUTORIZACAO
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarDadosContasPagarIten(List<TbContaspagaritenFinanceiro> contasPagarIten)
    {
        foreach (var contaPagarIten in contasPagarIten)
        {
            DateTime? dataVencimento;
            if (contaPagarIten.CPI_DATAPAGO != null)
            {
                dataVencimento = DateTime.ParseExact(s: contaPagarIten.CPI_DATAPAGO, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                dataVencimento = null;
            }

            var contasPagarItenEncontrada = await _context.TbContaspagaritens.AsNoTracking().FirstOrDefaultAsync(c => c.CtpCodigo == contaPagarIten.CTP_CODIGO);
            if (contasPagarItenEncontrada == null)
            {
                _context.TbContaspagaritens.Add(new TbContaspagariten
                {
                    CpiCodigo = contaPagarIten.CPI_CODIGO,
                    CpiConciliado = contaPagarIten.CPI_CONCILIADO,
                    CpiDesconto = contaPagarIten.CPI_DESCONTO,
                    CpiDatapago = dataVencimento,
                    CpiHorapago = contaPagarIten.CPI_HORAPAGO,
                    CpiJuros = contaPagarIten.CPI_JUROS,
                    CpiMulta = contaPagarIten.CPI_MULTA,
                    CpiTipopag = contaPagarIten.CPI_TIPOPAG,
                    CpiValorpago = contaPagarIten.CPI_VALORPAGO,
                    CtpCodigo = contaPagarIten.CTP_CODIGO
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbContaspagaritens.Update(new TbContaspagariten
                {
                    CpiCodigo = contaPagarIten.CPI_CODIGO,
                    CpiConciliado = contaPagarIten.CPI_CONCILIADO,
                    CpiDesconto = contaPagarIten.CPI_DESCONTO,
                    CpiDatapago = dataVencimento,
                    CpiHorapago = contaPagarIten.CPI_HORAPAGO,
                    CpiJuros = contaPagarIten.CPI_JUROS,
                    CpiMulta = contaPagarIten.CPI_MULTA,
                    CpiTipopag = contaPagarIten.CPI_TIPOPAG,
                    CpiValorpago = contaPagarIten.CPI_VALORPAGO,
                    CtpCodigo = contaPagarIten.CTP_CODIGO
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarDadosPlanoContas(List<TbPlanodecontaFinanceiro> planodecontas)
    {
        foreach (var planodeconta in planodecontas)
        {
            var planodecontaEncontrada = await _context.TbPlanodecontas.AsNoTracking().FirstOrDefaultAsync(p => p.PlcCodigo == planodeconta.PLC_CODIGO);
            if (planodecontaEncontrada == null)
            {
                _context.TbPlanodecontas.Add(new TbPlanodeconta
                {
                    PlcCodigo = planodeconta.PLC_CODIGO,
                    PlcContamae = planodeconta.PLC_CONTAMAE,
                    PlcDescricao = planodeconta.PLC_DESCRICAO,
                    PlcId = planodeconta.PLC_ID,
                    PlcTipo = planodeconta.PLC_TIPO
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbPlanodecontas.Update(new TbPlanodeconta
                {
                    PlcCodigo = planodeconta.PLC_CODIGO,
                    PlcContamae = planodeconta.PLC_CONTAMAE,
                    PlcDescricao = planodeconta.PLC_DESCRICAO,
                    PlcId = planodeconta.PLC_ID,
                    PlcTipo = planodeconta.PLC_TIPO
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarDadosCentroContas(List<TbCentrocontaFinanceiro> centrocontas)
    {
        foreach (var centroconta in centrocontas)
        {
            var centrocontaEncontrada = await _context.TbCentrocontas.AsNoTracking().FirstOrDefaultAsync(c => c.CcoCodigo == centroconta.CCO_CODIGO);
            if (centrocontaEncontrada == null)
            {
                _context.TbCentrocontas.Add(new TbCentroconta
                {
                    CcoCodigo = centroconta.CCO_CODIGO,
                    CcoContamae = centroconta.CCO_CONTAMAE,
                    CcoDescricao = centroconta.CCO_DESCRICAO,
                    CcoId = centroconta.CCO_ID,
                    EmpCodigo = centroconta.EMP_CODIGO
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbCentrocontas.Update(new TbCentroconta
                {
                    CcoCodigo = centroconta.CCO_CODIGO,
                    CcoContamae = centroconta.CCO_CONTAMAE,
                    CcoDescricao = centroconta.CCO_DESCRICAO,
                    CcoId = centroconta.CCO_ID,
                    EmpCodigo = centroconta.EMP_CODIGO
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarDadosContasInvestimento(List<TbContainvestimentoFinanceiro> contasInvestimento)
    {
        foreach (var contaInvestimento in contasInvestimento)
        {
            DateTime? data;
            if (contaInvestimento.CIN_DATA != null)
            {
                data = DateTime.ParseExact(s: contaInvestimento.CIN_DATA, format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("pt-BR"));
            }
            else
            {
                data = null;
            }

            var contaInvestimentoEncontrada = await _context.TbContainvestimentos.AsNoTracking().FirstOrDefaultAsync(c => c.CinCodigo == contaInvestimento.CIN_CODIGO);
            if (contaInvestimentoEncontrada == null)
            {
                _context.TbContainvestimentos.Add(new TbContainvestimento
                {
                    CinCodigo = contaInvestimento.CIN_CODIGO,
                    CinData = data,
                    CinDescricao = contaInvestimento.CIN_DESCRICAO,
                    CinValor = contaInvestimento.CIN_VALOR,
                    EmpCodigo = contaInvestimento.EMP_CODIGO,
                    CinCodigomovimento = contaInvestimento.CIN_CODIGOMOVIMENTO,
                    CinTipo = contaInvestimento.CIN_TIPO,
                    CinTipomovimento = contaInvestimento.CIN_TIPOMOVIMENTO,
                    CinTipooperacao = contaInvestimento.CIN_TIPOOPERACAO,
                    CtcCodigo = contaInvestimento.CTC_CODIGO,
                    PlcCodigo = contaInvestimento.PLC_CODIGO
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbContainvestimentos.Update(new TbContainvestimento
                {
                    CinCodigo = contaInvestimento.CIN_CODIGO,
                    CinData = data,
                    CinDescricao = contaInvestimento.CIN_DESCRICAO,
                    CinValor = contaInvestimento.CIN_VALOR,
                    EmpCodigo = contaInvestimento.EMP_CODIGO,
                    CinCodigomovimento = contaInvestimento.CIN_CODIGOMOVIMENTO,
                    CinTipo = contaInvestimento.CIN_TIPO,
                    CinTipomovimento = contaInvestimento.CIN_TIPOMOVIMENTO,
                    CinTipooperacao = contaInvestimento.CIN_TIPOOPERACAO,
                    CtcCodigo = contaInvestimento.CTC_CODIGO,
                    PlcCodigo = contaInvestimento.PLC_CODIGO
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarDadosContaCorrente(List<TbContacorrenteFinanceiro> contasCorrentes)
    {
        foreach (var contaCorrente in contasCorrentes)
        {
            var contaCorrenteEncontrada = await _context.TbContacorrentes.AsNoTracking().FirstOrDefaultAsync(c => c.CtcCodigo == contaCorrente.CTC_CODIGO);
            if (contaCorrenteEncontrada == null)
            {
                _context.TbContacorrentes.Add(new TbContacorrente
                {
                    CtcCodigo = contaCorrente.CTC_CODIGO,
                    CtcAgencia = contaCorrente.CTC_AGENCIA,
                    CtcConta = contaCorrente.CTC_CONTA,
                    BanCodigo = contaCorrente.BAN_CODIGO,
                    CtcAgenciadigito = contaCorrente.CTC_AGENCIADIGITO,
                    CtcAtiva = contaCorrente.CTC_ATIVA,
                    CtcContadigito = contaCorrente.CTC_CONTADIGITO,
                    CtcGeraboleto = contaCorrente.CTC_GERABOLETO,
                    CtcNomeagencia = contaCorrente.CTC_NOMEAGENCIA,
                    CtcTipoconta = contaCorrente.CTC_TIPOCONTA,
                    EmpCodigo = contaCorrente.EMP_CODIGO,
                    CtcTitular = contaCorrente.CTC_TITULAR
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbContacorrentes.Update(new TbContacorrente
                {
                    CtcCodigo = contaCorrente.CTC_CODIGO,
                    CtcAgencia = contaCorrente.CTC_AGENCIA,
                    CtcConta = contaCorrente.CTC_CONTA,
                    BanCodigo = contaCorrente.BAN_CODIGO,
                    CtcAgenciadigito = contaCorrente.CTC_AGENCIADIGITO,
                    CtcAtiva = contaCorrente.CTC_ATIVA,
                    CtcContadigito = contaCorrente.CTC_CONTADIGITO,
                    CtcGeraboleto = contaCorrente.CTC_GERABOLETO,
                    CtcNomeagencia = contaCorrente.CTC_NOMEAGENCIA,
                    CtcTipoconta = contaCorrente.CTC_TIPOCONTA,
                    EmpCodigo = contaCorrente.EMP_CODIGO,
                    CtcTitular = contaCorrente.CTC_TITULAR
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarDadosBancos(List<TbBancoFinanceiro> bancos)
    {
        foreach (var banco in bancos)
        {
            var bancoEncontrado = await _context.TbBancos.AsNoTracking().FirstOrDefaultAsync(b => b.BanCodigo == banco.BAN_CODIGO);
            if (bancoEncontrado == null)
            {
                _context.TbBancos.Add(new TbBanco
                {
                    BanCodigo = banco.BAN_CODIGO,
                    BanDescricao = banco.BAN_DESCRICAO,
                    BanNumero = banco.BAN_NUMERO,
                    BanDigito = banco.BAN_DIGITO,
                    BanLogo = banco.BAN_LOGO
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbBancos.Update(new TbBanco
                {
                    BanCodigo = banco.BAN_CODIGO,
                    BanDescricao = banco.BAN_DESCRICAO,
                    BanNumero = banco.BAN_NUMERO,
                    BanDigito = banco.BAN_DIGITO,
                    BanLogo = banco.BAN_LOGO
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarRateio(List<TbRateioFinanceiro> rateio)
    {
        foreach (var item in rateio)
        {
            var rateioEncontrado = await _context.TbRateios.AsNoTracking().FirstOrDefaultAsync(r => r.RatCodigo == item.RAT_CODIGO);
            if (rateioEncontrado == null)
            {
                _context.TbRateios.Add(new TbRateio
                {
                    RatCodigo = item.RAT_CODIGO,
                    RatAlias = item.RAT_ALIAS,
                    RatDescricao = item.RAT_DESCRICAO,
                    EmpCodigo = item.EMP_CODIGO,
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbRateios.Update(new TbRateio
                {
                    RatCodigo = item.RAT_CODIGO,
                    RatAlias = item.RAT_ALIAS,
                    RatDescricao = item.RAT_DESCRICAO,
                    EmpCodigo = item.EMP_CODIGO,
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarRateioContasReceber(List<TbRateiocontasreceberFinanceiro> rateioContasReceber)
    {
        foreach (var item in rateioContasReceber)
        {
            var rateioContasReceberEncontrado = await _context.TbRateiocontasrecebers.AsNoTracking().FirstOrDefaultAsync(r => r.RcrCodigo == item.RCR_CODIGO);
            if (rateioContasReceberEncontrado == null)
            {
                _context.TbRateiocontasrecebers.Add(new TbRateiocontasreceber
                {
                    RcrCodigo = item.RCR_CODIGO,
                    RatCodigo = item.RAT_CODIGO,
                    CtrCodigo = item.CTR_CODIGO,
                    RcrPercentual = item.RCR_PERCENTUAL,
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbRateiocontasrecebers.Update(new TbRateiocontasreceber
                {
                    RcrCodigo = item.RCR_CODIGO,
                    RatCodigo = item.RAT_CODIGO,
                    CtrCodigo = item.CTR_CODIGO,
                    RcrPercentual = item.RCR_PERCENTUAL,
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarBoleto(List<TbBoletoFinanceiro> boleto)
    {
        foreach (var item in boleto)
        {
            var boletoEncontrado = await _context.TbBoletos.AsNoTracking().FirstOrDefaultAsync(b => b.BolCodigo == item.BOL_CODIGO);
            if (boletoEncontrado == null)
            {
                _context.TbBoletos.Add(new TbBoleto
                {
                    BolCodigo = item.BOL_CODIGO,
                    BolCarteira = item.BOL_CARTEIRA,
                    BolNossonumero = item.BOL_NOSSONUMERO,
                    BolCodigomovimento = item.BOL_CODIGOMOVIMENTO,
                    BolDataabatimento = item.BOL_DATAABATIMENTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAABATIMENTO),
                    BolDatadesconto = item.BOL_DATADESCONTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATADESCONTO),
                    BolDatadocumento = item.BOL_DATADOCUMENTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATADOCUMENTO),
                    BolDatamorajuros = item.BOL_DATAMORAJUROS.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAMORAJUROS),
                    BolDataprocessamento = item.BOL_DATAPROCESSAMENTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAPROCESSAMENTO),
                    BolDataprotesto = item.BOL_DATAPROTESTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAPROTESTO),
                    BolDatarecebimento = item.BOL_DATARECEBIMENTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATARECEBIMENTO),
                    BolDataremessa = item.BOL_DATAREMESSA.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAREMESSA),
                    BolDataretorno = item.BOL_DATARETORNO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATARETORNO),
                    BolDatastatus = item.BOL_DATASTATUS.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATASTATUS),
                    BolDatavendimento = item.BOL_DATAVENDIMENTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAVENDIMENTO),
                    BolGerouremessa = item.BOL_GEROUREMESSA,
                    BolNumerodoc = item.BOL_NUMERODOC,
                    BolObs = item.BOL_OBS,
                    BolPercentualmulta = item.BOL_PERCENTUALMULTA,
                    BolRetorno = item.BOL_RETORNO,
                    BolStatus = item.BOL_STATUS,
                    BolStatusvencimento = item.BOL_STATUSVENCIMENTO,
                    BolTipomovimento = item.BOL_TIPOMOVIMENTO,
                    BolValorabatimento = item.BOL_VALORABATIMENTO,
                    BolValordesconto = item.BOL_VALORDESCONTO,
                    BolValordocumento = item.BOL_VALORDOCUMENTO,
                    BolValormorajuros = item.BOL_VALORMORAJUROS,
                    BolValorrecebido = item.BOL_VALORRECEBIDO,
                    CcbCodigo = item.CCB_CODIGO,
                    CtcCodigo = item.CTC_CODIGO,
                    EmpCodigo = item.EMP_CODIGO,
                    PesCodigo = item.PES_CODIGO,
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TbBoletos.Update(new TbBoleto
                {
                    BolCodigo = item.BOL_CODIGO,
                    BolCarteira = item.BOL_CARTEIRA,
                    BolNossonumero = item.BOL_NOSSONUMERO,
                    BolCodigomovimento = item.BOL_CODIGOMOVIMENTO,
                    BolDataabatimento = item.BOL_DATAABATIMENTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAABATIMENTO),
                    BolDatadesconto = item.BOL_DATADESCONTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATADESCONTO),
                    BolDatadocumento = item.BOL_DATADOCUMENTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATADOCUMENTO),
                    BolDatamorajuros = item.BOL_DATAMORAJUROS.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAMORAJUROS),
                    BolDataprocessamento = item.BOL_DATAPROCESSAMENTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAPROCESSAMENTO),
                    BolDataprotesto = item.BOL_DATAPROTESTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAPROTESTO),
                    BolDatarecebimento = item.BOL_DATARECEBIMENTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATARECEBIMENTO),
                    BolDataremessa = item.BOL_DATAREMESSA.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAREMESSA),
                    BolDataretorno = item.BOL_DATARETORNO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATARETORNO),
                    BolDatastatus = item.BOL_DATASTATUS.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATASTATUS),
                    BolDatavendimento = item.BOL_DATAVENDIMENTO.IsNullOrEmpty() ? null : DateTime.Parse(item.BOL_DATAVENDIMENTO),
                    BolGerouremessa = item.BOL_GEROUREMESSA,
                    BolNumerodoc = item.BOL_NUMERODOC,
                    BolObs = item.BOL_OBS,
                    BolPercentualmulta = item.BOL_PERCENTUALMULTA,
                    BolRetorno = item.BOL_RETORNO,
                    BolStatus = item.BOL_STATUS,
                    BolStatusvencimento = item.BOL_STATUSVENCIMENTO,
                    BolTipomovimento = item.BOL_TIPOMOVIMENTO,
                    BolValorabatimento = item.BOL_VALORABATIMENTO,
                    BolValordesconto = item.BOL_VALORDESCONTO,
                    BolValordocumento = item.BOL_VALORDOCUMENTO,
                    BolValormorajuros = item.BOL_VALORMORAJUROS,
                    BolValorrecebido = item.BOL_VALORRECEBIDO,
                    CcbCodigo = item.CCB_CODIGO,
                    CtcCodigo = item.CTC_CODIGO,
                    EmpCodigo = item.EMP_CODIGO,
                    PesCodigo = item.PES_CODIGO,
                });
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task SincronizarECAD(List<TbEcadOmegaPlay> ecad, int codigoEmpresa)
    {
        var filiais = await _context.TbEmpresas.Where(e => e.EmpCodigo == codigoEmpresa)
                                               .Select(x => x.EmpQtdFiliais).FirstOrDefaultAsync();
        if (filiais == null || filiais <= 1)
            await DisableEnableTrigger("INSERT TB_ECAD", "DISABLE");
        foreach (var item in ecad)
        {
            var ecadEncontrado = _context.TbEcads.AsNoTracking().FirstOrDefault(e => e.EcaCodigo == item.ECA_CODIGO);
            if (ecadEncontrado == null)
            {
                _context.TbEcads.Add(new TbEcad
                {
                    EcaCodigo = item.ECA_CODIGO,
                    EcaData = item.ECA_DATA,
                    EcaHora = item.ECA_HORA,
                    EcaMusnomecompleto = item.ECA_MUSNOMECOMPLETO,
                    MusCodigo = item.MUS_CODIGO,
                    MusCompositor = item.MUS_COMPOSITOR,
                    MusDuracao = item.MUS_DURACAO,
                    MusGravadora = item.MUS_GRAVADORA,
                    MusInterprete = item.MUS_INTERPRETE,
                    EmpCodigo = codigoEmpresa
                });
            }
            else
            {
                _context.TbEcads.Update(new TbEcad
                {
                    EcaCodigo = item.ECA_CODIGO,
                    EcaData = item.ECA_DATA,
                    EcaHora = item.ECA_HORA,
                    EcaMusnomecompleto = item.ECA_MUSNOMECOMPLETO,
                    MusCodigo = item.MUS_CODIGO,
                    MusCompositor = item.MUS_COMPOSITOR,
                    MusDuracao = item.MUS_DURACAO,
                    MusGravadora = item.MUS_GRAVADORA,
                    MusInterprete = item.MUS_INTERPRETE,
                    EmpCodigo = codigoEmpresa
                });
            }
            await _context.SaveChangesAsync();
        }

        if (filiais == null || filiais <= 1)
            await DisableEnableTrigger("INSERT TB_ECAD", "ENABLE");
    }

    public async Task SincronizarGravadora(List<TbGravadoraOmegaPlay> gravadora, int codigoEmpresa)
    {
        var filiais = await _context.TbEmpresas.Where(e => e.EmpCodigo == codigoEmpresa)
                                               .Select(x => x.EmpQtdFiliais).FirstOrDefaultAsync();
        if (filiais == null || filiais <= 1)
            await DisableEnableTrigger("INSERT TB_GRAVADORAS", "DISABLE");

        foreach (var item in gravadora)
        {
            var gravadoraEncontrada = _context.TbGravadoras.AsNoTracking().FirstOrDefault(g => g.GraCodigo == item.GRA_CODIGO);
            if (gravadoraEncontrada == null)
            {
                _context.TbGravadoras.Add(new TbGravadora
                {
                    GraCodigo = item.GRA_CODIGO,
                    GraNome = item.GRA_NOME,
                    EmpCodigo = codigoEmpresa
                });
            }
            else

            {
                _context.TbGravadoras.Update(new TbGravadora
                {
                    GraCodigo = item.GRA_CODIGO,
                    GraNome = item.GRA_NOME,
                    EmpCodigo = codigoEmpresa
                });
            }
            await _context.SaveChangesAsync();
        }

        if (filiais == null || filiais <= 1)
            await DisableEnableTrigger("INSERT TB_GRAVADORAS", "ENABLE");
    }

    public async Task SincronizarMusicas(List<TbMusicaOmegaPlay> musicas, int codigoEmpresa)
    {
        var filiais = await _context.TbEmpresas.Where(e => e.EmpCodigo == codigoEmpresa)
                                               .Select(x => x.EmpQtdFiliais).FirstOrDefaultAsync();
        if (filiais == null || filiais <= 1)
            await DisableEnableTrigger("INSERT TB_MUSICAS", "DISABLE");

        foreach (var musica in musicas)
        {
            var musicaEncontrada = _context.TbMusicas.AsNoTracking().FirstOrDefault(m => m.MusCodigo == musica.MUS_CODIGO);
            //var musicaEncontrada = _context.TbMusicas.AsNoTracking().FirstOrDefault(m => m.MusCodigo == musica.MUS_CODIGO);
            if (musicaEncontrada == null)
            {
                _context.TbMusicas.Add(new TbMusica
                {
                    MusCodigo = musica.MUS_CODIGO,
                    MusNome = musica.MUS_NOME,
                    GraCodigo = musica.GRA_CODIGO,
                    IdiCodigo = musica.IDI_CODIGO,
                    MusAlbum = musica.MUS_ALBUM,
                    MusAno = musica.MUS_ANO,
                    MusArquivo = musica.MUS_ARQUIVO,
                    MusAvaliacao = musica.MUS_AVALIACAO,
                    MusCompositor = musica.MUS_COMPOSITOR,
                    MusFaixa = musica.MUS_FAIXA,
                    MusInterprete = musica.MUS_INTERPRETE,
                    MusNomecompleto = musica.MUS_NOMECOMPLETO,
                    MusPeriodofim = musica.MUS_PERIODOFIM,
                    MusPeriodoinicio = musica.MUS_PERIODOINICIO,
                    MusTipo = musica.MUS_TIPO,
                    MusSegundos = musica.MUS_SEGUNDOS,
                    MusTempo = musica.MUS_TEMPO,
                    MusTipoperiodo = musica.MUS_TIPOPERIODO,
                    PasCodigo = musica.PAS_CODIGO,
                    RitCodigo = musica.RIT_CODIGO,
                    SubCodigo = musica.SUB_CODIGO,
                    VocCodigo = musica.VOC_CODIGO,
                    EmpCodigo = codigoEmpresa
                });
            }
            else
            {
                _context.TbMusicas.Update(new TbMusica
                {
                    MusCodigo = musica.MUS_CODIGO,
                    MusNome = musica.MUS_NOME,
                    GraCodigo = musica.GRA_CODIGO,
                    IdiCodigo = musica.IDI_CODIGO,
                    MusAlbum = musica.MUS_ALBUM,
                    MusAno = musica.MUS_ANO,
                    MusArquivo = musica.MUS_ARQUIVO,
                    MusAvaliacao = musica.MUS_AVALIACAO,
                    MusCompositor = musica.MUS_COMPOSITOR,
                    MusFaixa = musica.MUS_FAIXA,
                    MusInterprete = musica.MUS_INTERPRETE,
                    MusNomecompleto = musica.MUS_NOMECOMPLETO,
                    MusPeriodofim = musica.MUS_PERIODOFIM,
                    MusPeriodoinicio = musica.MUS_PERIODOINICIO,
                    MusTipo = musica.MUS_TIPO,
                    MusSegundos = musica.MUS_SEGUNDOS,
                    MusTempo = musica.MUS_TEMPO,
                    MusTipoperiodo = musica.MUS_TIPOPERIODO,
                    PasCodigo = musica.PAS_CODIGO,
                    RitCodigo = musica.RIT_CODIGO,
                    SubCodigo = musica.SUB_CODIGO,
                    VocCodigo = musica.VOC_CODIGO,
                    EmpCodigo = codigoEmpresa
                });
            }
            await _context.SaveChangesAsync();
        }

        if (filiais == null || filiais <= 1)
            await DisableEnableTrigger("INSERT TB_MUSICAS", "ENABLE");
    }

    //GET
    public async Task<int> ReplicarDados(List<Replicacao> comandoSql)
    {
        //Desativar trigger do banco
        //_context.Entry(comandoSql).State = EntityState.Detached;
        //_context.ChangeTracker.Clear();
        int listaRetorno = 0;

        var validado = comandoSql[0].reP_SCRIPT.Replace("{", "{{").Replace("}", "}}");
        try
        {
            await DisableEnableTrigger(comandoSql[0].reP_SCRIPT, "DISABLE");
            await _context.Database.ExecuteSqlRawAsync(validado);
            await _context.SaveChangesAsync();
            listaRetorno = comandoSql[0].reP_CODIGO;
            await DisableEnableTrigger(comandoSql[0].reP_SCRIPT, "ENABLE");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return listaRetorno;
        }

        /*foreach (DictionaryEntry item in comandoSql)
		{
			try {
				DisableEnableTrigger(item.Value.ToString(), "DISABLE");
				await _context.Database.ExecuteSqlRawAsync(item.Value.ToString());
				await _context.SaveChangesAsync();
				listaRetorno.Add(int.Parse(item.Key.ToString()));
				DisableEnableTrigger(item.Value.ToString(), "ENABLE");
			} catch
			{
				return listaRetorno;
			}
		}*/
        //Reativar trigger do banco
        //_context.Entry(comandoSql).State = EntityState.Detached;
        //await _context.Database.ExecuteSqlRawAsync("ALTER TABLE TbReplicacao ENABLE TRIGGER ALL");
        return listaRetorno;
    }
    public async Task<TbReplicacao> GetReplicacaoItens(int codigoAlias)
    {
        return await _context.TbReplicacaos.OrderBy(x => x.RepCodigo).FirstOrDefaultAsync(r => r.RepAlias == codigoAlias);
    }

    public async Task<TbReplicacao> GetItemReplicacao(int codigoItem)
    {
        return await _context.TbReplicacaos.FindAsync(codigoItem);
    }

    public async Task<IEnumerable<TbReplicacao>> GetReplicacoes()
    {
        return await _context.TbReplicacaos.ToListAsync();
    }

    //UPDATE
    public async Task UpdateItensReplicacao(TbReplicacao replicacao)
    {
        _context.TbReplicacaos.Update(replicacao);
        await _context.SaveChangesAsync();
    }

    //DELETE
    public async Task DeleteItensReplicacao(int codigoExclusao)
    {
        TbReplicacao retorno = await GetItemReplicacao(codigoExclusao);
        if (retorno != null)
        {
            _context.TbReplicacaos.Remove(retorno);
            await _context.SaveChangesAsync();
        }
    }
}
