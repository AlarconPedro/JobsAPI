using System;
using System.Collections.Generic;

namespace JobWeb.Infra.Data.Repositories;

public partial class TbUsuario
{
    public int UsuCodigo { get; set; }

    public string? UsuNome { get; set; }

    public string? UsuSenha { get; set; }

    public string? UsuFuncao { get; set; }

    public string? UsuEndereco { get; set; }

    public string? UsuBairro { get; set; }

    public string? UsuCidade { get; set; }

    public string? UsuUf { get; set; }

    public string? UsuCep { get; set; }

    public string? UsuFone { get; set; }

    public string? UsuCelular { get; set; }

    public string? UsuEmail { get; set; }

    public int? UsuDiaaniversario { get; set; }

    public int? UsuMesaniversario { get; set; }

    public string? UsuObs { get; set; }

    public string? UsuLogin { get; set; }

    public int? UsuTipo { get; set; }

    public int? UsuPerfilacesso { get; set; }

    public string? UsuAcessoComercial { get; set; }

    public string? UsuAcessoMusical { get; set; }

    public string? UsuAcessoLocucao { get; set; }

    public int? UsuAutorizacaoacesso { get; set; }

    public string? UsuIdFirebase { get; set; }

    public int? UsuPesCodigo { get; set; }

    public string? UsuAcessoAgendaComercial { get; set; }

    public string? UsuPlayerIdOnesignal { get; set; }

    public int? UsuMinutosNotificacao { get; set; }

    public bool? UsuEnviaNotificacaoOs { get; set; }

    public bool? UsuEnviaNotificacaoLembrete { get; set; }

    public DateTime? UsuUltimoEnvioNotificacao { get; set; }

    public string? UsuImagem { get; set; }

    public string? UsuAcessoTask { get; set; }

    public string? UsuAcessoFinanceiro { get; set; }

    public string? UsuAcessoCloud { get; set; }

    public virtual ICollection<TbDireito> TbDireitos { get; set; } = new List<TbDireito>();

    public virtual ICollection<TbOrdemServicoIten> TbOrdemServicoItens { get; set; } = new List<TbOrdemServicoIten>();

    public virtual ICollection<TbUsuarioPessoa> TbUsuarioPessoas { get; set; } = new List<TbUsuarioPessoa>();
}
