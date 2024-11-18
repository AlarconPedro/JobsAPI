using System;
using System.Collections.Generic;
using JobWeb.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobWeb.Infra.Data.Context;

public partial class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    public virtual DbSet<TbAgendacomercial> TbAgendacomercials { get; set; }

    public virtual DbSet<TbArea> TbAreas { get; set; }

    public virtual DbSet<TbAtividade> TbAtividades { get; set; }

    public virtual DbSet<TbBanco> TbBancos { get; set; }

    public virtual DbSet<TbBoleto> TbBoletos { get; set; }

    public virtual DbSet<TbCaixa> TbCaixas { get; set; }

    public virtual DbSet<TbCarteiracobranca> TbCarteiracobrancas { get; set; }

    public virtual DbSet<TbCedentecheque> TbCedentecheques { get; set; }

    public virtual DbSet<TbCentroconta> TbCentrocontas { get; set; }

    public virtual DbSet<TbCheque> TbCheques { get; set; }

    public virtual DbSet<TbChequesituacao> TbChequesituacaos { get; set; }

    public virtual DbSet<TbChequesmovimentacao> TbChequesmovimentacaos { get; set; }

    public virtual DbSet<TbClienteAntigo> TbClienteAntigos { get; set; }

    public virtual DbSet<TbComissionadoscontrato> TbComissionadoscontratos { get; set; }

    public virtual DbSet<TbConfiguracao> TbConfiguracaos { get; set; }

    public virtual DbSet<TbConfiguracaoempresa> TbConfiguracaoempresas { get; set; }

    public virtual DbSet<TbCongelamento> TbCongelamentos { get; set; }

    public virtual DbSet<TbContacorrente> TbContacorrentes { get; set; }

    public virtual DbSet<TbContacorrentelanc> TbContacorrentelancs { get; set; }

    public virtual DbSet<TbContacorrentelanciten> TbContacorrentelancitens { get; set; }

    public virtual DbSet<TbContainvestimento> TbContainvestimentos { get; set; }

    public virtual DbSet<TbContamensal> TbContamensals { get; set; }

    public virtual DbSet<TbContamensalcontrato> TbContamensalcontratos { get; set; }

    public virtual DbSet<TbContaspagar> TbContaspagars { get; set; }

    public virtual DbSet<TbContaspagariten> TbContaspagaritens { get; set; }

    public virtual DbSet<TbContasreceber> TbContasrecebers { get; set; }

    public virtual DbSet<TbContasreceberiten> TbContasreceberitens { get; set; }

    public virtual DbSet<TbContrato> TbContratos { get; set; }

    public virtual DbSet<TbDireito> TbDireitos { get; set; }

    public virtual DbSet<TbEcad> TbEcads { get; set; }

    public virtual DbSet<TbEmail> TbEmails { get; set; }

    public virtual DbSet<TbEmpresa> TbEmpresas { get; set; }

    public virtual DbSet<TbFaq> TbFaqs { get; set; }

    public virtual DbSet<TbGavetum> TbGaveta { get; set; }

    public virtual DbSet<TbGravadora> TbGravadoras { get; set; }

    public virtual DbSet<TbHorario> TbHorarios { get; set; }

    public virtual DbSet<TbMateriai> TbMateriais { get; set; }

    public virtual DbSet<TbMovimentodecaixa> TbMovimentodecaixas { get; set; }

    public virtual DbSet<TbMusica> TbMusicas { get; set; }

    public virtual DbSet<TbNotafiscal21> TbNotafiscal21s { get; set; }

    public virtual DbSet<TbOrdemServico> TbOrdemServicos { get; set; }

    public virtual DbSet<TbOrdemServicoIten> TbOrdemServicoItens { get; set; }

    public virtual DbSet<TbPessoa> TbPessoas { get; set; }

    public virtual DbSet<TbPlanodeconta> TbPlanodecontas { get; set; }

    public virtual DbSet<TbProduto> TbProdutos { get; set; }

    public virtual DbSet<TbProdutoChave> TbProdutoChaves { get; set; }

    public virtual DbSet<TbProdutoCliente> TbProdutoClientes { get; set; }

    public virtual DbSet<TbProgcomercial> TbProgcomercials { get; set; }

    public virtual DbSet<TbRateio> TbRateios { get; set; }

    public virtual DbSet<TbRateiocontamensalcontrato> TbRateiocontamensalcontratos { get; set; }

    public virtual DbSet<TbRateiocontasreceber> TbRateiocontasrecebers { get; set; }

    public virtual DbSet<TbReplicacao> TbReplicacaos { get; set; }

    public virtual DbSet<TbRespostaEmail> TbRespostaEmails { get; set; }

    public virtual DbSet<TbSolicitacaoSenha> TbSolicitacaoSenhas { get; set; }

    public virtual DbSet<TbTela> TbTelas { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<TbUsuarioPessoa> TbUsuarioPessoas { get; set; }

    public virtual DbSet<TbVersaoProduto> TbVersaoProdutos { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=OmegaCloud;Integrated Security=true;Encrypt=false;");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DataBaseConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAgendacomercial>(entity =>
        {
            entity.HasKey(e => e.AgcCodigo);

            entity.ToTable("TB_AGENDACOMERCIAL");

            entity.Property(e => e.AgcCodigo).HasColumnName("AGC_CODIGO");
            entity.Property(e => e.AgcDatafim)
                .HasColumnType("datetime")
                .HasColumnName("AGC_DATAFIM");
            entity.Property(e => e.AgcDatainicio)
                .HasColumnType("datetime")
                .HasColumnName("AGC_DATAINICIO");
            entity.Property(e => e.AgcDescricao)
                .HasColumnType("text")
                .HasColumnName("AGC_DESCRICAO");
            entity.Property(e => e.AgcTempoalerta).HasColumnName("AGC_TEMPOALERTA");
            entity.Property(e => e.AgcTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("AGC_TIPO");
            entity.Property(e => e.AgcTitulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AGC_TITULO");
            entity.Property(e => e.CntCodigo).HasColumnName("CNT_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbAgendacomercials)
                .HasForeignKey(d => d.PesCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_AGENDACOMERCIAL_TB_PESSOAS");
        });

        modelBuilder.Entity<TbArea>(entity =>
        {
            entity.HasKey(e => e.AreCodigo).HasName("PK_TbArea");

            entity.ToTable("TB_AREA");

            entity.Property(e => e.AreCodigo)
                .ValueGeneratedNever()
                .HasColumnName("ARE_CODIGO");
            entity.Property(e => e.AreNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ARE_NOME");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbAreas)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_AREA_TB_EMPRESA");
        });

        modelBuilder.Entity<TbAtividade>(entity =>
        {
            entity.HasKey(e => e.AtiCodigo);

            entity.ToTable("TB_ATIVIDADE", tb =>
                {
                    tb.HasTrigger("DeleteAtividade");
                    tb.HasTrigger("ReplicaAtividade");
                    tb.HasTrigger("UpdateAtividade");
                });

            entity.Property(e => e.AtiCodigo)
                .ValueGeneratedNever()
                .HasColumnName("ATI_CODIGO");
            entity.Property(e => e.AtiCodigocom).HasColumnName("ATI_CODIGOCOM");
            entity.Property(e => e.AtiNome)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ATI_NOME");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbAtividades)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_ATIVIDADE_TB_ATIVIDADE");
        });

        modelBuilder.Entity<TbBanco>(entity =>
        {
            entity.HasKey(e => e.BanCodigo).HasName("PK_BANCOS");

            entity.ToTable("TB_BANCOS");

            entity.Property(e => e.BanCodigo)
                .ValueGeneratedNever()
                .HasColumnName("BAN_CODIGO");
            entity.Property(e => e.BanDescricao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BAN_DESCRICAO");
            entity.Property(e => e.BanDigito)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("BAN_DIGITO");
            entity.Property(e => e.BanLogo)
                .HasColumnType("text")
                .HasColumnName("BAN_LOGO");
            entity.Property(e => e.BanNumero).HasColumnName("BAN_NUMERO");
        });

        modelBuilder.Entity<TbBoleto>(entity =>
        {
            entity.HasKey(e => e.BolCodigo).HasName("PK_BOLETOS");

            entity.ToTable("TB_BOLETOS");

            entity.Property(e => e.BolCodigo)
                .ValueGeneratedNever()
                .HasColumnName("BOL_CODIGO");
            entity.Property(e => e.BolCarteira).HasColumnName("BOL_CARTEIRA");
            entity.Property(e => e.BolCodigomovimento).HasColumnName("BOL_CODIGOMOVIMENTO");
            entity.Property(e => e.BolDataabatimento)
                .HasColumnType("datetime")
                .HasColumnName("BOL_DATAABATIMENTO");
            entity.Property(e => e.BolDatadesconto)
                .HasColumnType("datetime")
                .HasColumnName("BOL_DATADESCONTO");
            entity.Property(e => e.BolDatadocumento)
                .HasColumnType("datetime")
                .HasColumnName("BOL_DATADOCUMENTO");
            entity.Property(e => e.BolDatamorajuros)
                .HasColumnType("datetime")
                .HasColumnName("BOL_DATAMORAJUROS");
            entity.Property(e => e.BolDataprocessamento)
                .HasColumnType("datetime")
                .HasColumnName("BOL_DATAPROCESSAMENTO");
            entity.Property(e => e.BolDataprotesto)
                .HasColumnType("datetime")
                .HasColumnName("BOL_DATAPROTESTO");
            entity.Property(e => e.BolDatarecebimento).HasColumnName("BOL_DATARECEBIMENTO");
            entity.Property(e => e.BolDataremessa)
                .HasColumnType("datetime")
                .HasColumnName("BOL_DATAREMESSA");
            entity.Property(e => e.BolDataretorno)
                .HasColumnType("datetime")
                .HasColumnName("BOL_DATARETORNO");
            entity.Property(e => e.BolDatastatus)
                .HasColumnType("datetime")
                .HasColumnName("BOL_DATASTATUS");
            entity.Property(e => e.BolDatavendimento)
                .HasColumnType("datetime")
                .HasColumnName("BOL_DATAVENDIMENTO");
            entity.Property(e => e.BolGerouremessa)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("BOL_GEROUREMESSA");
            entity.Property(e => e.BolNossonumero).HasColumnName("BOL_NOSSONUMERO");
            entity.Property(e => e.BolNumerodoc).HasColumnName("BOL_NUMERODOC");
            entity.Property(e => e.BolObs)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("BOL_OBS");
            entity.Property(e => e.BolPercentualmulta)
                .HasColumnType("numeric(15, 5)")
                .HasColumnName("BOL_PERCENTUALMULTA");
            entity.Property(e => e.BolRetorno)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("BOL_RETORNO");
            entity.Property(e => e.BolStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("BOL_STATUS");
            entity.Property(e => e.BolStatusvencimento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("BOL_STATUSVENCIMENTO");
            entity.Property(e => e.BolTipomovimento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("BOL_TIPOMOVIMENTO");
            entity.Property(e => e.BolValorabatimento)
                .HasColumnType("numeric(10, 5)")
                .HasColumnName("BOL_VALORABATIMENTO");
            entity.Property(e => e.BolValordesconto)
                .HasColumnType("numeric(10, 5)")
                .HasColumnName("BOL_VALORDESCONTO");
            entity.Property(e => e.BolValordocumento)
                .HasColumnType("numeric(10, 5)")
                .HasColumnName("BOL_VALORDOCUMENTO");
            entity.Property(e => e.BolValormorajuros)
                .HasColumnType("numeric(10, 5)")
                .HasColumnName("BOL_VALORMORAJUROS");
            entity.Property(e => e.BolValorrecebido)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("BOL_VALORRECEBIDO");
            entity.Property(e => e.CcbCodigo).HasColumnName("CCB_CODIGO");
            entity.Property(e => e.CtcCodigo).HasColumnName("CTC_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");
        });

        modelBuilder.Entity<TbCaixa>(entity =>
        {
            entity.HasKey(e => e.CaiCodigo);

            entity.ToTable("TB_CAIXA");

            entity.Property(e => e.CaiCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CAI_CODIGO");
            entity.Property(e => e.CaiDataabertura).HasColumnName("CAI_DATAABERTURA");
            entity.Property(e => e.CaiDatafechamento).HasColumnName("CAI_DATAFECHAMENTO");
            entity.Property(e => e.CaiHoraabertura)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("CAI_HORAABERTURA");
            entity.Property(e => e.CaiHorafechamento)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("CAI_HORAFECHAMENTO");
            entity.Property(e => e.CaiSaldofechamento)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CAI_SALDOFECHAMENTO");
            entity.Property(e => e.CaiSaldoinicial)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CAI_SALDOINICIAL");
            entity.Property(e => e.CaiStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CAI_STATUS");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCaixas)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CAIXA_2");
        });

        modelBuilder.Entity<TbCarteiracobranca>(entity =>
        {
            entity.HasKey(e => e.CcbCodigo).HasName("PK__TB_CARTE__8E5933DD1479ACEB");

            entity.ToTable("TB_CARTEIRACOBRANCA");

            entity.Property(e => e.CcbCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CCB_CODIGO");
            entity.Property(e => e.CcbAceite)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CCB_ACEITE");
            entity.Property(e => e.CcbCarteira)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CCB_CARTEIRA");
            entity.Property(e => e.CcbContadorremessa).HasColumnName("CCB_CONTADORREMESSA");
            entity.Property(e => e.CcbContrato)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CCB_CONTRATO");
            entity.Property(e => e.CcbConvenio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CCB_CONVENIO");
            entity.Property(e => e.CcbDescricao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CCB_DESCRICAO");
            entity.Property(e => e.CcbDiasbaixa).HasColumnName("CCB_DIASBAIXA");
            entity.Property(e => e.CcbDiasdevolucaobaixa).HasColumnName("CCB_DIASDEVOLUCAOBAIXA");
            entity.Property(e => e.CcbDiasprotesto).HasColumnName("CCB_DIASPROTESTO");
            entity.Property(e => e.CcbEspeciedocumento)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CCB_ESPECIEDOCUMENTO");
            entity.Property(e => e.CcbGeraremessa)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CCB_GERAREMESSA");
            entity.Property(e => e.CcbInstrucao1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CCB_INSTRUCAO1");
            entity.Property(e => e.CcbInstrucao2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CCB_INSTRUCAO2");
            entity.Property(e => e.CcbInstrucao3)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CCB_INSTRUCAO3");
            entity.Property(e => e.CcbJurosdia)
                .HasColumnType("numeric(15, 5)")
                .HasColumnName("CCB_JUROSDIA");
            entity.Property(e => e.CcbLayoutremessa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CCB_LAYOUTREMESSA");
            entity.Property(e => e.CcbLocalpagamento)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("CCB_LOCALPAGAMENTO");
            entity.Property(e => e.CcbModalidade)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CCB_MODALIDADE");
            entity.Property(e => e.CcbMultaaposvencimento)
                .HasColumnType("numeric(15, 5)")
                .HasColumnName("CCB_MULTAAPOSVENCIMENTO");
            entity.Property(e => e.CcbStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CCB_STATUS");
            entity.Property(e => e.CcbUltimoarquivo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CCB_ULTIMOARQUIVO");
            entity.Property(e => e.CtcCodigo).HasColumnName("CTC_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");
            entity.Property(e => e.PlcCodigo).HasColumnName("PLC_CODIGO");

            entity.HasOne(d => d.CtcCodigoNavigation).WithMany(p => p.TbCarteiracobrancas)
                .HasForeignKey(d => d.CtcCodigo)
                .HasConstraintName("FK_CARTEIRACOBRANCA_CONTA");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCarteiracobrancas)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CARTEIRACOBRANCA_2");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbCarteiracobrancas)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_TB_CARTEIRACOBRANCA_1");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbCarteiracobrancas)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_TB_CARTEIRACOBRANCA_3");
        });

        modelBuilder.Entity<TbCedentecheque>(entity =>
        {
            entity.HasKey(e => e.CedCodigo).HasName("PK__TB_CEDEN__175E416690FCE375");

            entity.ToTable("TB_CEDENTECHEQUE");

            entity.Property(e => e.CedCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CED_CODIGO");
            entity.Property(e => e.CedCpfcnpj)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CED_CPFCNPJ");
            entity.Property(e => e.CedNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CED_NOME");
            entity.Property(e => e.CedTipopessoa)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CED_TIPOPESSOA");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCedentecheques)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CEDENTECHEQUE_2");
        });

        modelBuilder.Entity<TbCentroconta>(entity =>
        {
            entity.HasKey(e => e.CcoCodigo);

            entity.ToTable("TB_CENTROCONTAS");

            entity.Property(e => e.CcoCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CCO_CODIGO");
            entity.Property(e => e.CcoContamae)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CCO_CONTAMAE");
            entity.Property(e => e.CcoDescricao)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("CCO_DESCRICAO");
            entity.Property(e => e.CcoId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CCO_ID");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCentroconta)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CENTROCONTAS_1");
        });

        modelBuilder.Entity<TbCheque>(entity =>
        {
            entity.HasKey(e => e.CheCodigo).HasName("PK__TB_CHEQU__AB54CC54C8E67BF5");

            entity.ToTable("TB_CHEQUES");

            entity.Property(e => e.CheCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CHE_CODIGO");
            entity.Property(e => e.BanCodigo).HasColumnName("BAN_CODIGO");
            entity.Property(e => e.CedCodigo).HasColumnName("CED_CODIGO");
            entity.Property(e => e.CheAgencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CHE_AGENCIA");
            entity.Property(e => e.CheBompara).HasColumnName("CHE_BOMPARA");
            entity.Property(e => e.CheConta)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CHE_CONTA");
            entity.Property(e => e.CheDataemissao).HasColumnName("CHE_DATAEMISSAO");
            entity.Property(e => e.CheNumero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CHE_NUMERO");
            entity.Property(e => e.ChePredatado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CHE_PREDATADO");
            entity.Property(e => e.CheTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CHE_TIPO");
            entity.Property(e => e.CheValor)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CHE_VALOR");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");
            entity.Property(e => e.PlcCodigo).HasColumnName("PLC_CODIGO");

            entity.HasOne(d => d.BanCodigoNavigation).WithMany(p => p.TbCheques)
                .HasForeignKey(d => d.BanCodigo)
                .HasConstraintName("FK_TB_CHEQUES_3");

            entity.HasOne(d => d.CedCodigoNavigation).WithMany(p => p.TbCheques)
                .HasForeignKey(d => d.CedCodigo)
                .HasConstraintName("FK_TB_CHEQUES_4");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCheques)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CHEQUES_2");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbCheques)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_TB_CHEQUES_5");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbCheques)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_TB_CHEQUES_6");
        });

        modelBuilder.Entity<TbChequesituacao>(entity =>
        {
            entity.HasKey(e => e.CqsCodigo);

            entity.ToTable("TB_CHEQUESITUACAO");

            entity.Property(e => e.CqsCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CQS_CODIGO");
            entity.Property(e => e.CheCodigo).HasColumnName("CHE_CODIGO");
            entity.Property(e => e.CqsData).HasColumnName("CQS_DATA");
            entity.Property(e => e.CqsHistorico)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CQS_HISTORICO");
            entity.Property(e => e.CqsHora)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CQS_HORA");
            entity.Property(e => e.CqsSituacao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CQS_SITUACAO");

            entity.HasOne(d => d.CheCodigoNavigation).WithMany(p => p.TbChequesituacaos)
                .HasForeignKey(d => d.CheCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TB_CHEQUESITUACAO_2");
        });

        modelBuilder.Entity<TbChequesmovimentacao>(entity =>
        {
            entity.HasKey(e => e.CqmCodigo);

            entity.ToTable("TB_CHEQUESMOVIMENTACAO");

            entity.Property(e => e.CqmCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CQM_CODIGO");
            entity.Property(e => e.CheCodigo).HasColumnName("CHE_CODIGO");
            entity.Property(e => e.CqmCodigomovimento).HasColumnName("CQM_CODIGOMOVIMENTO");
            entity.Property(e => e.CqmConciliado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CQM_CONCILIADO");
            entity.Property(e => e.CqmData).HasColumnName("CQM_DATA");
            entity.Property(e => e.CqmDescricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CQM_DESCRICAO");
            entity.Property(e => e.CqmObservacao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CQM_OBSERVACAO");
            entity.Property(e => e.CqmTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CQM_TIPO");
            entity.Property(e => e.CqmTipomovimento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CQM_TIPOMOVIMENTO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");

            entity.HasOne(d => d.CheCodigoNavigation).WithMany(p => p.TbChequesmovimentacaos)
                .HasForeignKey(d => d.CheCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TB_CHEQUESMOVIMENTACAO_2");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbChequesmovimentacaos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CHEQUESMOVIMENTACAO_3");
        });

        modelBuilder.Entity<TbClienteAntigo>(entity =>
        {
            entity.HasKey(e => e.CliAntCodigo);

            entity.ToTable("TB_CLIENTE_ANTIGO");

            entity.Property(e => e.CliAntCodigo).ValueGeneratedNever();
            entity.Property(e => e.CliAntBairro)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CliAntCelular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CliAntCep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CliAntCEP");
            entity.Property(e => e.CliAntContatoFone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CliAntContatoFuncao)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CliAntContatoNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CliAntCpfCnpj)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CliAntEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CliAntEndereco)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CliAntFone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CliAntGuid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CliAntGUID");
            entity.Property(e => e.CliAntNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CliAntObservacao).HasColumnType("text");
            entity.Property(e => e.CliAntRazaoSocial)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CliAntRgIe)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CliAntSite)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CliAntStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CliAntTipoPessoa)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CliAntTipoRadio)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbClienteAntigos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CLIENTE_ANTIGO_TB_EMPRESA");
        });

        modelBuilder.Entity<TbComissionadoscontrato>(entity =>
        {
            entity.HasKey(e => e.CmcCodigo);

            entity.ToTable("TB_COMISSIONADOSCONTRATO");

            entity.Property(e => e.CmcCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CMC_CODIGO");
            entity.Property(e => e.CmcComissao)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CMC_COMISSAO");
            entity.Property(e => e.CntCodigo).HasColumnName("CNT_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");

            entity.HasOne(d => d.CntCodigoNavigation).WithMany(p => p.TbComissionadoscontratos)
                .HasForeignKey(d => d.CntCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_COMISSIONADOSCONTRATO_1");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbComissionadoscontratos)
                .HasForeignKey(d => d.PesCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_COMISSIONADOSCONTRATO_2");
        });

        modelBuilder.Entity<TbConfiguracao>(entity =>
        {
            entity.HasKey(e => e.CfgCodigo);

            entity.ToTable("TB_CONFIGURACAO");

            entity.Property(e => e.CfgCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CFG_CODIGO");
            entity.Property(e => e.CfgDatasistema)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("CFG_DATASISTEMA");
            entity.Property(e => e.CfgGuid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CFG_GUID");
            entity.Property(e => e.CfgIdCloud).HasColumnName("CFG_ID_CLOUD");
            entity.Property(e => e.CfgLembretebackup)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CFG_LEMBRETEBACKUP");
            entity.Property(e => e.CfgModulos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CFG_MODULOS");
            entity.Property(e => e.CfgPathgerated)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CFG_PATHGERATED");
            entity.Property(e => e.CfgPathted)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CFG_PATHTED");
            entity.Property(e => e.CfgPathvalidador)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CFG_PATHVALIDADOR");
            entity.Property(e => e.CfgSalariominimo)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("CFG_SALARIOMINIMO");
            entity.Property(e => e.CfgSenhastatus)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("CFG_SENHASTATUS");
            entity.Property(e => e.CfgSenhavezes)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("CFG_SENHAVEZES");
            entity.Property(e => e.CfgVersao)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CFG_VERSAO");
        });

        modelBuilder.Entity<TbConfiguracaoempresa>(entity =>
        {
            entity.HasKey(e => e.CfeCodigo).HasName("PK__TB_CONFI__A86B41F44DECAA57");

            entity.ToTable("TB_CONFIGURACAOEMPRESA");

            entity.Property(e => e.CfeCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CFE_CODIGO");
            entity.Property(e => e.CfeDescricaoemailboleto)
                .HasColumnType("text")
                .HasColumnName("CFE_DESCRICAOEMAILBOLETO");
            entity.Property(e => e.CfeDescricaoemailnf21)
                .HasColumnType("text")
                .HasColumnName("CFE_DESCRICAOEMAILNF21");
            entity.Property(e => e.CfeDiaslembretecontrato).HasColumnName("CFE_DIASLEMBRETECONTRATO");
            entity.Property(e => e.CfeDiaslembretecp).HasColumnName("CFE_DIASLEMBRETECP");
            entity.Property(e => e.CfeDiaslembretecr).HasColumnName("CFE_DIASLEMBRETECR");
            entity.Property(e => e.CfeEmailenvio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CFE_EMAILENVIO");
            entity.Property(e => e.CfeEmailtipoenvio)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CFE_EMAILTIPOENVIO");
            entity.Property(e => e.CfeEmissorchequepadrao).HasColumnName("CFE_EMISSORCHEQUEPADRAO");
            entity.Property(e => e.CfeEnderecocomercial)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CFE_ENDERECOCOMERCIAL");
            entity.Property(e => e.CfeHistoricoFaturamento)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_FATURAMENTO");
            entity.Property(e => e.CfeHistoricoPagBoleto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_PAG_BOLETO");
            entity.Property(e => e.CfeHistoricoPagCartao)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_PAG_CARTAO");
            entity.Property(e => e.CfeHistoricoPagCarteira)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_PAG_CARTEIRA");
            entity.Property(e => e.CfeHistoricoPagCheque)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_PAG_CHEQUE");
            entity.Property(e => e.CfeHistoricoPagDinheiro)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_PAG_DINHEIRO");
            entity.Property(e => e.CfeHistoricoPagTransfdep)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_PAG_TRANSFDEP");
            entity.Property(e => e.CfeHistoricoRecBoleto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_REC_BOLETO");
            entity.Property(e => e.CfeHistoricoRecCartao)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_REC_CARTAO");
            entity.Property(e => e.CfeHistoricoRecCarteira)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_REC_CARTEIRA");
            entity.Property(e => e.CfeHistoricoRecCheque)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_REC_CHEQUE");
            entity.Property(e => e.CfeHistoricoRecDinheiro)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_REC_DINHEIRO");
            entity.Property(e => e.CfeHistoricoRecTransfdep)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CFE_HISTORICO_REC_TRANSFDEP");
            entity.Property(e => e.CfeHostemail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CFE_HOSTEMAIL");
            entity.Property(e => e.CfeIntegracaocomercial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CFE_INTEGRACAOCOMERCIAL");
            entity.Property(e => e.CfeJuros)
                .HasColumnType("numeric(15, 5)")
                .HasColumnName("CFE_JUROS");
            entity.Property(e => e.CfeMostracalendario)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CFE_MOSTRACALENDARIO");
            entity.Property(e => e.CfeMostralembretecontrato)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CFE_MOSTRALEMBRETECONTRATO");
            entity.Property(e => e.CfeMostralembretecp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CFE_MOSTRALEMBRETECP");
            entity.Property(e => e.CfeMostralembretecr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CFE_MOSTRALEMBRETECR");
            entity.Property(e => e.CfeMulta)
                .HasColumnType("numeric(15, 5)")
                .HasColumnName("CFE_MULTA");
            entity.Property(e => e.CfeNumerocontratoauto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CFE_NUMEROCONTRATOAUTO");
            entity.Property(e => e.CfeOnesignalAppId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CFE_ONESIGNAL_APP_ID");
            entity.Property(e => e.CfeOnesignalRestApiKey)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CFE_ONESIGNAL_REST_API_KEY");
            entity.Property(e => e.CfePortaemail)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CFE_PORTAEMAIL");
            entity.Property(e => e.CfeSenhaemail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CFE_SENHAEMAIL");
            entity.Property(e => e.CfeTempolembrete).HasColumnName("CFE_TEMPOLEMBRETE");
            entity.Property(e => e.CfeTextocontrato)
                .HasColumnType("text")
                .HasColumnName("CFE_TEXTOCONTRATO");
            entity.Property(e => e.CfeUltimorecibo).HasColumnName("CFE_ULTIMORECIBO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PlcCodigoComissao).HasColumnName("PLC_CODIGO_COMISSAO");
            entity.Property(e => e.PlcCodigoFaturamento).HasColumnName("PLC_CODIGO_FATURAMENTO");
            entity.Property(e => e.PlcCodigoRendimentoAplicacao).HasColumnName("PLC_CODIGO_RENDIMENTO_APLICACAO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbConfiguracaoempresas)
                .HasForeignKey(d => d.EmpCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TB_CONFIGURACAOEMPRESA_2");

            entity.HasOne(d => d.PlcCodigoComissaoNavigation).WithMany(p => p.TbConfiguracaoempresaPlcCodigoComissaoNavigations)
                .HasForeignKey(d => d.PlcCodigoComissao)
                .HasConstraintName("FK_TB_CONFIGURACAOEMPRESA_4");

            entity.HasOne(d => d.PlcCodigoFaturamentoNavigation).WithMany(p => p.TbConfiguracaoempresaPlcCodigoFaturamentoNavigations)
                .HasForeignKey(d => d.PlcCodigoFaturamento)
                .HasConstraintName("FK_TB_CONFIGURACAOEMPRESA_3");

            entity.HasOne(d => d.PlcCodigoRendimentoAplicacaoNavigation).WithMany(p => p.TbConfiguracaoempresaPlcCodigoRendimentoAplicacaoNavigations)
                .HasForeignKey(d => d.PlcCodigoRendimentoAplicacao)
                .HasConstraintName("FK_TB_CONFIGURACAOEMPRESA_5");
        });

        modelBuilder.Entity<TbCongelamento>(entity =>
        {
            entity.HasKey(e => e.CngCodigo);

            entity.ToTable("TB_CONGELAMENTOS");

            entity.HasIndex(e => e.CtrCodigo, "IX_TB_CONGELAMENTOS_CTR_CODIGO");

            entity.Property(e => e.CngCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CNG_CODIGO");
            entity.Property(e => e.ChaCodigo).HasColumnName("CHA_CODIGO");
            entity.Property(e => e.CngAvisocobranca).HasColumnName("CNG_AVISOCOBRANCA");
            entity.Property(e => e.CngAvisocongelamento).HasColumnName("CNG_AVISOCONGELAMENTO");
            entity.Property(e => e.CngAvisoprotesto).HasColumnName("CNG_AVISOPROTESTO");
            entity.Property(e => e.CngCongelado).HasColumnName("CNG_CONGELADO");
            entity.Property(e => e.CngDataavisocobranca)
                .HasColumnType("datetime")
                .HasColumnName("CNG_DATAAVISOCOBRANCA");
            entity.Property(e => e.CngDataavisocongelamento)
                .HasColumnType("datetime")
                .HasColumnName("CNG_DATAAVISOCONGELAMENTO");
            entity.Property(e => e.CngDataavisoprotesto)
                .HasColumnType("datetime")
                .HasColumnName("CNG_DATAAVISOPROTESTO");
            entity.Property(e => e.CngDatacongelamento)
                .HasColumnType("datetime")
                .HasColumnName("CNG_DATACONGELAMENTO");
            entity.Property(e => e.CngDescricao)
                .HasColumnType("text")
                .HasColumnName("CNG_DESCRICAO");
            entity.Property(e => e.CngStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNG_STATUS");
            entity.Property(e => e.CtrCodigo).HasColumnName("CTR_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");
            entity.Property(e => e.ProcliCodigo).HasColumnName("PROCLI_CODIGO");

            entity.HasOne(d => d.ChaCodigoNavigation).WithMany(p => p.TbCongelamentos)
                .HasForeignKey(d => d.ChaCodigo)
                .HasConstraintName("Chave");

            entity.HasOne(d => d.CtrCodigoNavigation).WithMany(p => p.TbCongelamentos)
                .HasForeignKey(d => d.CtrCodigo)
                .HasConstraintName("ContasReceber");

            entity.HasOne(d => d.ProcliCodigoNavigation).WithMany(p => p.TbCongelamentos)
                .HasForeignKey(d => d.ProcliCodigo)
                .HasConstraintName("Produto");
        });

        modelBuilder.Entity<TbContacorrente>(entity =>
        {
            entity.HasKey(e => e.CtcCodigo).HasName("PK_CONTACORRENTE");

            entity.ToTable("TB_CONTACORRENTE");

            entity.Property(e => e.CtcCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CTC_CODIGO");
            entity.Property(e => e.BanCodigo).HasColumnName("BAN_CODIGO");
            entity.Property(e => e.CtcAgencia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CTC_AGENCIA");
            entity.Property(e => e.CtcAgenciadigito)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CTC_AGENCIADIGITO");
            entity.Property(e => e.CtcAtiva)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CTC_ATIVA");
            entity.Property(e => e.CtcConta)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CTC_CONTA");
            entity.Property(e => e.CtcContadigito)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CTC_CONTADIGITO");
            entity.Property(e => e.CtcGeraboleto)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CTC_GERABOLETO");
            entity.Property(e => e.CtcNomeagencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CTC_NOMEAGENCIA");
            entity.Property(e => e.CtcTipoconta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CTC_TIPOCONTA");
            entity.Property(e => e.CtcTitular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CTC_TITULAR");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");

            entity.HasOne(d => d.BanCodigoNavigation).WithMany(p => p.TbContacorrentes)
                .HasForeignKey(d => d.BanCodigo)
                .HasConstraintName("FK_CONTACORRENTE_BANCO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContacorrentes)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_CONTACORRENTE_EMPRESA");
        });

        modelBuilder.Entity<TbContacorrentelanc>(entity =>
        {
            entity.HasKey(e => e.CclCodigo).HasName("PK_CONTACORRENTELANC");

            entity.ToTable("TB_CONTACORRENTELANC");

            entity.Property(e => e.CclCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CCL_CODIGO");
            entity.Property(e => e.CclCodigomovimento).HasColumnName("CCL_CODIGOMOVIMENTO");
            entity.Property(e => e.CclConciliado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CCL_CONCILIADO");
            entity.Property(e => e.CclData).HasColumnName("CCL_DATA");
            entity.Property(e => e.CclDescricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CCL_DESCRICAO");
            entity.Property(e => e.CclDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CCL_DOCUMENTO");
            entity.Property(e => e.CclHistorico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CCL_HISTORICO");
            entity.Property(e => e.CclPendente)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CCL_PENDENTE");
            entity.Property(e => e.CclTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CCL_TIPO");
            entity.Property(e => e.CclTipomovimento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CCL_TIPOMOVIMENTO");
            entity.Property(e => e.CclValor)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("CCL_VALOR");
            entity.Property(e => e.CtcCodigo).HasColumnName("CTC_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");

            entity.HasOne(d => d.CtcCodigoNavigation).WithMany(p => p.TbContacorrentelancs)
                .HasForeignKey(d => d.CtcCodigo)
                .HasConstraintName("FK_CONTACORRENTELANC_CONTA");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContacorrentelancs)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_CONTACORRENTELANC_EMPRESA");
        });

        modelBuilder.Entity<TbContacorrentelanciten>(entity =>
        {
            entity.HasKey(e => e.CliCodigo);

            entity.ToTable("TB_CONTACORRENTELANCITENS");

            entity.Property(e => e.CliCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CLI_CODIGO");
            entity.Property(e => e.CclCodigo).HasColumnName("CCL_CODIGO");
            entity.Property(e => e.CliCodigomovimento).HasColumnName("CLI_CODIGOMOVIMENTO");
            entity.Property(e => e.CliData).HasColumnName("CLI_DATA");
            entity.Property(e => e.CliDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLI_DOCUMENTO");
            entity.Property(e => e.CliTipomovimento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CLI_TIPOMOVIMENTO");
            entity.Property(e => e.CliValor)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("CLI_VALOR");

            entity.HasOne(d => d.CclCodigoNavigation).WithMany(p => p.TbContacorrentelancitens)
                .HasForeignKey(d => d.CclCodigo)
                .HasConstraintName("FK_TB_CONTACORRENTELANCITENS_1");
        });

        modelBuilder.Entity<TbContainvestimento>(entity =>
        {
            entity.HasKey(e => e.CinCodigo);

            entity.ToTable("TB_CONTAINVESTIMENTO");

            entity.Property(e => e.CinCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CIN_CODIGO");
            entity.Property(e => e.CinCodigomovimento).HasColumnName("CIN_CODIGOMOVIMENTO");
            entity.Property(e => e.CinData).HasColumnName("CIN_DATA");
            entity.Property(e => e.CinDescricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CIN_DESCRICAO");
            entity.Property(e => e.CinTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CIN_TIPO");
            entity.Property(e => e.CinTipomovimento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CIN_TIPOMOVIMENTO");
            entity.Property(e => e.CinTipooperacao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CIN_TIPOOPERACAO");
            entity.Property(e => e.CinValor)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("CIN_VALOR");
            entity.Property(e => e.CtcCodigo).HasColumnName("CTC_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PlcCodigo).HasColumnName("PLC_CODIGO");

            entity.HasOne(d => d.CtcCodigoNavigation).WithMany(p => p.TbContainvestimentos)
                .HasForeignKey(d => d.CtcCodigo)
                .HasConstraintName("FK_TB_CONTAINVESTIMENTO_2");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContainvestimentos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CONTAINVESTIMENTO_1");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbContainvestimentos)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_TB_CONTAINVESTIMENTO_4");
        });

        modelBuilder.Entity<TbContamensal>(entity =>
        {
            entity.HasKey(e => e.CmeCodigo);

            entity.ToTable("TB_CONTAMENSAL");

            entity.Property(e => e.CmeCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CME_CODIGO");
            entity.Property(e => e.CcoCodigo).HasColumnName("CCO_CODIGO");
            entity.Property(e => e.CmeDiasperiodo).HasColumnName("CME_DIASPERIODO");
            entity.Property(e => e.CmeDiavencimento).HasColumnName("CME_DIAVENCIMENTO");
            entity.Property(e => e.CmeHistorico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CME_HISTORICO");
            entity.Property(e => e.CmeHistoricoconta)
                .HasColumnType("text")
                .HasColumnName("CME_HISTORICOCONTA");
            entity.Property(e => e.CmeTipoperiodo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CME_TIPOPERIODO");
            entity.Property(e => e.CmeValor).HasColumnName("CME_VALOR");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");
            entity.Property(e => e.PlcCodigo).HasColumnName("PLC_CODIGO");

            entity.HasOne(d => d.CcoCodigoNavigation).WithMany(p => p.TbContamensals)
                .HasForeignKey(d => d.CcoCodigo)
                .HasConstraintName("FK_TB_CONTAMENSAL_4");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContamensals)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CONTAMENSAL_1");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbContamensals)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_TB_CONTAMENSAL_2");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbContamensals)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_TB_CONTAMENSAL_3");
        });

        modelBuilder.Entity<TbContamensalcontrato>(entity =>
        {
            entity.HasKey(e => e.CmcCodigo);

            entity.ToTable("TB_CONTAMENSALCONTRATO");

            entity.Property(e => e.CmcCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CMC_CODIGO");
            entity.Property(e => e.CcoCodigo).HasColumnName("CCO_CODIGO");
            entity.Property(e => e.CmcDiainiciovigencia).HasColumnName("CMC_DIAINICIOVIGENCIA");
            entity.Property(e => e.CmcDiasperiodo).HasColumnName("CMC_DIASPERIODO");
            entity.Property(e => e.CmcDiavencimento).HasColumnName("CMC_DIAVENCIMENTO");
            entity.Property(e => e.CmcHistorico)
                .HasColumnType("text")
                .HasColumnName("CMC_HISTORICO");
            entity.Property(e => e.CmcPercentual)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("CMC_PERCENTUAL");
            entity.Property(e => e.CmcTipofaturamento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CMC_TIPOFATURAMENTO");
            entity.Property(e => e.CmcTipoperiodo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CMC_TIPOPERIODO");
            entity.Property(e => e.CmcTipovalor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CMC_TIPOVALOR");
            entity.Property(e => e.CmcValor)
                .HasColumnType("numeric(15, 2)")
                .HasColumnName("CMC_VALOR");
            entity.Property(e => e.CntCodigo).HasColumnName("CNT_CODIGO");
            entity.Property(e => e.PlcCodigo).HasColumnName("PLC_CODIGO");

            entity.HasOne(d => d.CcoCodigoNavigation).WithMany(p => p.TbContamensalcontratos)
                .HasForeignKey(d => d.CcoCodigo)
                .HasConstraintName("FK_TB_CONTAMENSALCONTRATO_2");

            entity.HasOne(d => d.CntCodigoNavigation).WithMany(p => p.TbContamensalcontratos)
                .HasForeignKey(d => d.CntCodigo)
                .HasConstraintName("FK_TB_CONTAMENSALCONTRATO_3");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbContamensalcontratos)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_TB_CONTAMENSALCONTRATO_1");
        });

        modelBuilder.Entity<TbContaspagar>(entity =>
        {
            entity.HasKey(e => e.CtpCodigo);

            entity.ToTable("TB_CONTASPAGAR");

            entity.Property(e => e.CtpCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CTP_CODIGO");
            entity.Property(e => e.CcoCodigo).HasColumnName("CCO_CODIGO");
            entity.Property(e => e.CtpCodigomovimento).HasColumnName("CTP_CODIGOMOVIMENTO");
            entity.Property(e => e.CtpData).HasColumnName("CTP_DATA");
            entity.Property(e => e.CtpDatavencimento).HasColumnName("CTP_DATAVENCIMENTO");
            entity.Property(e => e.CtpHistorico)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CTP_HISTORICO");
            entity.Property(e => e.CtpNumdoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CTP_NUMDOC");
            entity.Property(e => e.CtpObservacao)
                .HasColumnType("text")
                .HasColumnName("CTP_OBSERVACAO");
            entity.Property(e => e.CtpParcela).HasColumnName("CTP_PARCELA");
            entity.Property(e => e.CtpPrevisao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CTP_PREVISAO");
            entity.Property(e => e.CtpSituacao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CTP_SITUACAO");
            entity.Property(e => e.CtpSituacaoautorizacao)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CTP_SITUACAOAUTORIZACAO");
            entity.Property(e => e.CtpTipomovimento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CTP_TIPOMOVIMENTO");
            entity.Property(e => e.CtpTotalparcela).HasColumnName("CTP_TOTALPARCELA");
            entity.Property(e => e.CtpValor)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CTP_VALOR");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");
            entity.Property(e => e.PlcCodigo).HasColumnName("PLC_CODIGO");
            entity.Property(e => e.UsuCodigo).HasColumnName("USU_CODIGO");

            entity.HasOne(d => d.CcoCodigoNavigation).WithMany(p => p.TbContaspagars)
                .HasForeignKey(d => d.CcoCodigo)
                .HasConstraintName("FK_TB_CONTASPAGAR_1");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContaspagars)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CONTASPAGAR_2");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbContaspagars)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_TB_CONTASPAGAR_3");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbContaspagars)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_TB_CONTASPAGAR_4");
        });

        modelBuilder.Entity<TbContaspagariten>(entity =>
        {
            entity.HasKey(e => e.CpiCodigo);

            entity.ToTable("TB_CONTASPAGARITENS");

            entity.Property(e => e.CpiCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CPI_CODIGO");
            entity.Property(e => e.CpiConciliado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CPI_CONCILIADO");
            entity.Property(e => e.CpiDatapago).HasColumnName("CPI_DATAPAGO");
            entity.Property(e => e.CpiDesconto)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CPI_DESCONTO");
            entity.Property(e => e.CpiHorapago)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CPI_HORAPAGO");
            entity.Property(e => e.CpiJuros)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CPI_JUROS");
            entity.Property(e => e.CpiMulta)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CPI_MULTA");
            entity.Property(e => e.CpiTipopag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CPI_TIPOPAG");
            entity.Property(e => e.CpiValorpago)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CPI_VALORPAGO");
            entity.Property(e => e.CtpCodigo).HasColumnName("CTP_CODIGO");

            entity.HasOne(d => d.CtpCodigoNavigation).WithMany(p => p.TbContaspagaritens)
                .HasForeignKey(d => d.CtpCodigo)
                .HasConstraintName("FK_TB_CONTASPAGARITENS_2");
        });

        modelBuilder.Entity<TbContasreceber>(entity =>
        {
            entity.HasKey(e => e.CtrCodigo);

            entity.ToTable("TB_CONTASRECEBER", tb =>
                {
                    tb.HasTrigger("DeleteContasReceber");
                    tb.HasTrigger("ReplicaContasReceber");
                    tb.HasTrigger("UpdateContasReceber");
                });

            entity.HasIndex(e => e.CtrSituacao, "TB_CONTASRECEBER_IDXCTR_SITUACA");

            entity.Property(e => e.CtrCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CTR_CODIGO");
            entity.Property(e => e.CcoCodigo).HasColumnName("CCO_CODIGO");
            entity.Property(e => e.CntCodigo).HasColumnName("CNT_CODIGO");
            entity.Property(e => e.CtrBoleto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CTR_BOLETO");
            entity.Property(e => e.CtrBoletoimpresso)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CTR_BOLETOIMPRESSO");
            entity.Property(e => e.CtrCodigomovimento).HasColumnName("CTR_CODIGOMOVIMENTO");
            entity.Property(e => e.CtrData).HasColumnName("CTR_DATA");
            entity.Property(e => e.CtrDatavencimento).HasColumnName("CTR_DATAVENCIMENTO");
            entity.Property(e => e.CtrDatavencimentobase).HasColumnName("CTR_DATAVENCIMENTOBASE");
            entity.Property(e => e.CtrDuplicata)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CTR_DUPLICATA");
            entity.Property(e => e.CtrHistorico)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CTR_HISTORICO");
            entity.Property(e => e.CtrNossonumero)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CTR_NOSSONUMERO");
            entity.Property(e => e.CtrNumdoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CTR_NUMDOC");
            entity.Property(e => e.CtrNumeronf)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CTR_NUMERONF");
            entity.Property(e => e.CtrNumrecibo).HasColumnName("CTR_NUMRECIBO");
            entity.Property(e => e.CtrObservacao)
                .IsUnicode(false)
                .HasColumnName("CTR_OBSERVACAO");
            entity.Property(e => e.CtrParcela).HasColumnName("CTR_PARCELA");
            entity.Property(e => e.CtrPeriodofim).HasColumnName("CTR_PERIODOFIM");
            entity.Property(e => e.CtrPeriodoinicio).HasColumnName("CTR_PERIODOINICIO");
            entity.Property(e => e.CtrPrevisao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CTR_PREVISAO");
            entity.Property(e => e.CtrRecibo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CTR_RECIBO");
            entity.Property(e => e.CtrSemregistro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CTR_SEMREGISTRO");
            entity.Property(e => e.CtrSituacao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CTR_SITUACAO");
            entity.Property(e => e.CtrSituacaoautorizacao)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CTR_SITUACAOAUTORIZACAO");
            entity.Property(e => e.CtrTipomovimento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CTR_TIPOMOVIMENTO");
            entity.Property(e => e.CtrValor)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("CTR_VALOR");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");
            entity.Property(e => e.PlcCodigo).HasColumnName("PLC_CODIGO");
            entity.Property(e => e.UsuCodigo).HasColumnName("USU_CODIGO");

            entity.HasOne(d => d.CcoCodigoNavigation).WithMany(p => p.TbContasrecebers)
                .HasForeignKey(d => d.CcoCodigo)
                .HasConstraintName("FK_TB_CONTASRECEBER_1");

            entity.HasOne(d => d.CntCodigoNavigation).WithMany(p => p.TbContasrecebers)
                .HasForeignKey(d => d.CntCodigo)
                .HasConstraintName("FK_TB_CONTASRECEBER_5");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContasrecebers)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CONTASRECEBER_2");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbContasrecebers)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_TB_CONTASRECEBER_3");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbContasrecebers)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_TB_CONTASRECEBER_4");
        });

        modelBuilder.Entity<TbContasreceberiten>(entity =>
        {
            entity.HasKey(e => e.CriCodigo);

            entity.ToTable("TB_CONTASRECEBERITENS");

            entity.Property(e => e.CriCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CRI_CODIGO");
            entity.Property(e => e.CriConciliado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CRI_CONCILIADO");
            entity.Property(e => e.CriDatapago).HasColumnName("CRI_DATAPAGO");
            entity.Property(e => e.CriDesconto)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CRI_DESCONTO");
            entity.Property(e => e.CriHorapago)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CRI_HORAPAGO");
            entity.Property(e => e.CriJuros)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CRI_JUROS");
            entity.Property(e => e.CriMulta)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CRI_MULTA");
            entity.Property(e => e.CriTipopag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CRI_TIPOPAG");
            entity.Property(e => e.CriValorpago)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("CRI_VALORPAGO");
            entity.Property(e => e.CtrCodigo).HasColumnName("CTR_CODIGO");

            entity.HasOne(d => d.CtrCodigoNavigation).WithMany(p => p.TbContasreceberitens)
                .HasForeignKey(d => d.CtrCodigo)
                .HasConstraintName("FK_TB_CONTASRECEBERITENS_2");
        });

        modelBuilder.Entity<TbContrato>(entity =>
        {
            entity.HasKey(e => e.CntCodigo);

            entity.ToTable("TB_CONTRATOS", tb =>
                {
                    tb.HasTrigger("DeleteContratos");
                    tb.HasTrigger("ReplicaContratos");
                    tb.HasTrigger("UpdateContratos");
                });

            entity.Property(e => e.CntCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CNT_CODIGO");
            entity.Property(e => e.CntBoleto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_BOLETO");
            entity.Property(e => e.CntCodigocom).HasColumnName("CNT_CODIGOCOM");
            entity.Property(e => e.CntData).HasColumnName("CNT_DATA");
            entity.Property(e => e.CntDomingo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_DOMINGO");
            entity.Property(e => e.CntDuplicata)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_DUPLICATA");
            entity.Property(e => e.CntFaturado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_FATURADO");
            entity.Property(e => e.CntInicio).HasColumnName("CNT_INICIO");
            entity.Property(e => e.CntNumero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CNT_NUMERO");
            entity.Property(e => e.CntObservacao)
                .IsUnicode(false)
                .HasColumnName("CNT_OBSERVACAO");
            entity.Property(e => e.CntOculto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_OCULTO");
            entity.Property(e => e.CntPi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CNT_PI");
            entity.Property(e => e.CntProposto).HasColumnName("CNT_PROPOSTO");
            entity.Property(e => e.CntQtdinsercao).HasColumnName("CNT_QTDINSERCAO");
            entity.Property(e => e.CntQtdinsercaototal).HasColumnName("CNT_QTDINSERCAOTOTAL");
            entity.Property(e => e.CntQuarta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_QUARTA");
            entity.Property(e => e.CntQuinta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_QUINTA");
            entity.Property(e => e.CntRealizado).HasColumnName("CNT_REALIZADO");
            entity.Property(e => e.CntRecibo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_RECIBO");
            entity.Property(e => e.CntSabado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_SABADO");
            entity.Property(e => e.CntSegunda)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_SEGUNDA");
            entity.Property(e => e.CntSemregistro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_SEMREGISTRO");
            entity.Property(e => e.CntSexta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_SEXTA");
            entity.Property(e => e.CntTerca)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_TERCA");
            entity.Property(e => e.CntTermino).HasColumnName("CNT_TERMINO");
            entity.Property(e => e.CntTipo).HasColumnName("CNT_TIPO");
            entity.Property(e => e.CntTipoveiculacao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CNT_TIPOVEICULACAO");
            entity.Property(e => e.CntValorcontrato)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("CNT_VALORCONTRATO");
            entity.Property(e => e.CntValorinsercao)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("CNT_VALORINSERCAO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContratos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_CONTRATOS_TB_EMPRESA");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbContratos)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_TB_CONTRATOS_TB_PESSOAS");
        });

        modelBuilder.Entity<TbDireito>(entity =>
        {
            entity.HasKey(e => e.DirCodigo).HasName("PK__TB_DIREI__DAF21673440DEECD");

            entity.ToTable("TB_DIREITOS");

            entity.Property(e => e.DirCodigo)
                .ValueGeneratedNever()
                .HasColumnName("DIR_CODIGO");
            entity.Property(e => e.DirAcesso).HasColumnName("DIR_ACESSO");
            entity.Property(e => e.DirAlterar).HasColumnName("DIR_ALTERAR");
            entity.Property(e => e.DirExcluir).HasColumnName("DIR_EXCLUIR");
            entity.Property(e => e.DirIncluir).HasColumnName("DIR_INCLUIR");
            entity.Property(e => e.DirRelatorio).HasColumnName("DIR_RELATORIO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.TelCodigo).HasColumnName("TEL_CODIGO");
            entity.Property(e => e.TelModulo).HasColumnName("TEL_MODULO");
            entity.Property(e => e.UsuCodigo).HasColumnName("USU_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbDireitos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_DIREITOS_1");

            entity.HasOne(d => d.UsuCodigoNavigation).WithMany(p => p.TbDireitos)
                .HasForeignKey(d => d.UsuCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("USUARIO");

            entity.HasOne(d => d.TbTela).WithMany(p => p.TbDireitos)
                .HasForeignKey(d => new { d.TelCodigo, d.TelModulo })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("TELAS");
        });

        modelBuilder.Entity<TbEcad>(entity =>
        {
            entity.HasKey(e => e.EcaCodigo).HasName("TB_ECADPRIMARYKEY1");

            entity.ToTable("TB_ECAD", tb =>
                {
                    tb.HasTrigger("DeleteECAD");
                    tb.HasTrigger("ReplicaECAD");
                    tb.HasTrigger("UpdateECAD");
                });

            entity.Property(e => e.EcaCodigo)
                .ValueGeneratedNever()
                .HasColumnName("ECA_CODIGO");
            entity.Property(e => e.EcaData).HasColumnName("ECA_DATA");
            entity.Property(e => e.EcaHora)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ECA_HORA");
            entity.Property(e => e.EcaMusnomecompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ECA_MUSNOMECOMPLETO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.IdFilial).HasColumnName("ID_FILIAL");
            entity.Property(e => e.MusCodigo).HasColumnName("MUS_CODIGO");
            entity.Property(e => e.MusCompositor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MUS_COMPOSITOR");
            entity.Property(e => e.MusDuracao)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MUS_DURACAO");
            entity.Property(e => e.MusGravadora)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MUS_GRAVADORA");
            entity.Property(e => e.MusInterprete)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MUS_INTERPRETE");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbEcads)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_ECAD_TB_EMPRESA");

            entity.HasOne(d => d.MusCodigoNavigation).WithMany(p => p.TbEcads)
                .HasForeignKey(d => d.MusCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("MUSICA_FK");
        });

        modelBuilder.Entity<TbEmail>(entity =>
        {
            entity.HasKey(e => e.EmaCodigo).HasName("PK_TbEmail");

            entity.ToTable("TB_EMAIL");

            entity.Property(e => e.EmaCodigo).HasColumnName("EMA_CODIGO");
            entity.Property(e => e.EmaEmailEnvio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMA_EMAIL_ENVIO");
            entity.Property(e => e.EmaPorta)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EMA_PORTA");
            entity.Property(e => e.EmaSenha)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMA_SENHA");
            entity.Property(e => e.EmaSmtp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMA_SMTP");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbEmails)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_EMAIL_TB_EMPRESA");
        });

        modelBuilder.Entity<TbEmpresa>(entity =>
        {
            entity.HasKey(e => e.EmpCodigo);

            entity.ToTable("TB_EMPRESA", tb =>
                {
                    tb.HasTrigger("DeleteEmpresa");
                    tb.HasTrigger("ReplicaEmpresa");
                    tb.HasTrigger("UpdateEmpresa");
                });

            entity.Property(e => e.EmpCodigo)
                .ValueGeneratedNever()
                .HasColumnName("EMP_CODIGO");
            entity.Property(e => e.EmpAliasCodigo).HasColumnName("EMP_ALIAS_CODIGO");
            entity.Property(e => e.EmpBairro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_BAIRRO");
            entity.Property(e => e.EmpCep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EMP_CEP");
            entity.Property(e => e.EmpCidade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_CIDADE");
            entity.Property(e => e.EmpCnpj)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("EMP_CNPJ");
            entity.Property(e => e.EmpContadorbairro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORBAIRRO");
            entity.Property(e => e.EmpContadorcargo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORCARGO");
            entity.Property(e => e.EmpContadorcep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORCEP");
            entity.Property(e => e.EmpContadorcidade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORCIDADE");
            entity.Property(e => e.EmpContadorcpf)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORCPF");
            entity.Property(e => e.EmpContadorcrc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORCRC");
            entity.Property(e => e.EmpContadoremail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADOREMAIL");
            entity.Property(e => e.EmpContadorendereco)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORENDERECO");
            entity.Property(e => e.EmpContadorfone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORFONE");
            entity.Property(e => e.EmpContadornome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORNOME");
            entity.Property(e => e.EmpContadornumero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORNUMERO");
            entity.Property(e => e.EmpContadoruf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("EMP_CONTADORUF");
            entity.Property(e => e.EmpDenominacao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_DENOMINACAO");
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("EMP_EMAIL");
            entity.Property(e => e.EmpEndereco)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("EMP_ENDERECO");
            entity.Property(e => e.EmpFax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EMP_FAX");
            entity.Property(e => e.EmpFone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EMP_FONE");
            entity.Property(e => e.EmpInscricao)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EMP_INSCRICAO");
            entity.Property(e => e.EmpLinha1)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("EMP_LINHA1");
            entity.Property(e => e.EmpLinha2)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("EMP_LINHA2");
            entity.Property(e => e.EmpLinha3)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("EMP_LINHA3");
            entity.Property(e => e.EmpLinha4)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("EMP_LINHA4");
            entity.Property(e => e.EmpLinha5)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("EMP_LINHA5");
            entity.Property(e => e.EmpLogomarca)
                .IsUnicode(false)
                .HasColumnName("EMP_LOGOMARCA");
            entity.Property(e => e.EmpNome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("EMP_NOME");
            entity.Property(e => e.EmpNumero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMP_NUMERO");
            entity.Property(e => e.EmpQtdFiliais).HasColumnName("EMP_QTD_FILIAIS");
            entity.Property(e => e.EmpRazaosocial)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EMP_RAZAOSOCIAL");
            entity.Property(e => e.EmpStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("EMP_STATUS");
            entity.Property(e => e.EmpUf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("EMP_UF");
            entity.Property(e => e.EmpWeb)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("EMP_WEB");
        });

        modelBuilder.Entity<TbFaq>(entity =>
        {
            entity.HasKey(e => e.FaqCodigo).HasName("PK_TbPergunta");

            entity.ToTable("TB_FAQ");

            entity.Property(e => e.FaqCodigo).HasColumnName("FAQ_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.FaqPergunta)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("FAQ_PERGUNTA");
            entity.Property(e => e.FaqResposta)
                .HasColumnType("text")
                .HasColumnName("FAQ_RESPOSTA");
            entity.Property(e => e.ProCodigo).HasColumnName("PRO_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbFaqs)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_FAQ_TB_EMPRESA");

            entity.HasOne(d => d.ProCodigoNavigation).WithMany(p => p.TbFaqs)
                .HasForeignKey(d => d.ProCodigo)
                .HasConstraintName("FK_TB_FAQ_TB_PRODUTO");
        });

        modelBuilder.Entity<TbGavetum>(entity =>
        {
            entity.HasKey(e => e.GavCodigo);

            entity.ToTable("TB_GAVETA");

            entity.Property(e => e.GavCodigo)
                .ValueGeneratedNever()
                .HasColumnName("GAV_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.GavCodigomovimento).HasColumnName("GAV_CODIGOMOVIMENTO");
            entity.Property(e => e.GavConciliado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("GAV_CONCILIADO");
            entity.Property(e => e.GavData).HasColumnName("GAV_DATA");
            entity.Property(e => e.GavDescricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("GAV_DESCRICAO");
            entity.Property(e => e.GavObservacao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("GAV_OBSERVACAO");
            entity.Property(e => e.GavTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("GAV_TIPO");
            entity.Property(e => e.GavTipomovimento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GAV_TIPOMOVIMENTO");
            entity.Property(e => e.GavValor)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("GAV_VALOR");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbGaveta)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_GAVETA_2");
        });

        modelBuilder.Entity<TbGravadora>(entity =>
        {
            entity.HasKey(e => e.GraCodigo).HasName("TB_GRAVADORA_PK");

            entity.ToTable("TB_GRAVADORA", tb =>
                {
                    tb.HasTrigger("DeleteGravadora");
                    tb.HasTrigger("ReplicaGravadora");
                    tb.HasTrigger("UpdateGravadora");
                });

            entity.Property(e => e.GraCodigo)
                .ValueGeneratedNever()
                .HasColumnName("GRA_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.GraNome)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GRA_NOME");
            entity.Property(e => e.IdFilial).HasColumnName("ID_FILIAL");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbGravadoras)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_GRAVADORA_TB_EMPRESA");
        });

        modelBuilder.Entity<TbHorario>(entity =>
        {
            entity.HasKey(e => e.HorCodigo);

            entity.ToTable("TB_HORARIOS");

            entity.Property(e => e.HorCodigo)
                .ValueGeneratedNever()
                .HasColumnName("HOR_CODIGO");
            entity.Property(e => e.HorBreak)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("HOR_BREAK");
            entity.Property(e => e.HorData).HasColumnName("HOR_DATA");
            entity.Property(e => e.HorDataeditado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HOR_DATAEDITADO");
            entity.Property(e => e.HorHortocado)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("HOR_HORTOCADO");
            entity.Property(e => e.HorOrdem).HasColumnName("HOR_ORDEM");
            entity.Property(e => e.HorStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("HOR_STATUS");
            entity.Property(e => e.PrcCodigo).HasColumnName("PRC_CODIGO");

            entity.HasOne(d => d.PrcCodigoNavigation).WithMany(p => p.TbHorarios)
                .HasForeignKey(d => d.PrcCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_HORARIOS_TB_PROGCOMERCIAL");
        });

        modelBuilder.Entity<TbMateriai>(entity =>
        {
            entity.HasKey(e => e.MatCodigo);

            entity.ToTable("TB_MATERIAIS");

            entity.Property(e => e.MatCodigo)
                .ValueGeneratedNever()
                .HasColumnName("MAT_CODIGO");
            entity.Property(e => e.AtiCodigo).HasColumnName("ATI_CODIGO");
            entity.Property(e => e.CliCodigo).HasColumnName("CLI_CODIGO");
            entity.Property(e => e.ConCodigo).HasColumnName("CON_CODIGO");
            entity.Property(e => e.MatArquivo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("MAT_ARQUIVO");
            entity.Property(e => e.MatBloqueado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MAT_BLOQUEADO");
            entity.Property(e => e.MatDiario)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .HasColumnName("MAT_DIARIO");
            entity.Property(e => e.MatInicio).HasColumnName("MAT_INICIO");
            entity.Property(e => e.MatNome)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MAT_NOME");
            entity.Property(e => e.MatPosicaopatrocinio)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MAT_POSICAOPATROCINIO");
            entity.Property(e => e.MatProposto).HasColumnName("MAT_PROPOSTO");
            entity.Property(e => e.MatRabicho)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("MAT_RABICHO");
            entity.Property(e => e.MatRealizado).HasColumnName("MAT_REALIZADO");
            entity.Property(e => e.MatRodizio)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MAT_RODIZIO");
            entity.Property(e => e.MatSegundos).HasColumnName("MAT_SEGUNDOS");
            entity.Property(e => e.MatSegundoschamada).HasColumnName("MAT_SEGUNDOSCHAMADA");
            entity.Property(e => e.MatSegundospatrocinio).HasColumnName("MAT_SEGUNDOSPATROCINIO");
            entity.Property(e => e.MatTempo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MAT_TEMPO");
            entity.Property(e => e.MatTermino).HasColumnName("MAT_TERMINO");
            entity.Property(e => e.MatTerminorabicho).HasColumnName("MAT_TERMINORABICHO");
            entity.Property(e => e.MatTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MAT_TIPO");
            entity.Property(e => e.MatTrilha)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("MAT_TRILHA");
            entity.Property(e => e.MatTrilharabicho)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("MAT_TRILHARABICHO");
            entity.Property(e => e.MatVigencia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MAT_VIGENCIA");
            entity.Property(e => e.VinCodigochamada).HasColumnName("VIN_CODIGOCHAMADA");
            entity.Property(e => e.VinCodigopatrocinio).HasColumnName("VIN_CODIGOPATROCINIO");
        });

        modelBuilder.Entity<TbMovimentodecaixa>(entity =>
        {
            entity.HasKey(e => e.McxCodigo).HasName("PK__TB_MOVIM__93DB657830361D5A");

            entity.ToTable("TB_MOVIMENTODECAIXA");

            entity.Property(e => e.McxCodigo)
                .ValueGeneratedNever()
                .HasColumnName("MCX_CODIGO");
            entity.Property(e => e.CaiCodigo).HasColumnName("CAI_CODIGO");
            entity.Property(e => e.McxCodigomovimento).HasColumnName("MCX_CODIGOMOVIMENTO");
            entity.Property(e => e.McxData).HasColumnName("MCX_DATA");
            entity.Property(e => e.McxEntrada)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("MCX_ENTRADA");
            entity.Property(e => e.McxFormapagamento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MCX_FORMAPAGAMENTO");
            entity.Property(e => e.McxHistorico)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("MCX_HISTORICO");
            entity.Property(e => e.McxHora)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MCX_HORA");
            entity.Property(e => e.McxSaida)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("MCX_SAIDA");
            entity.Property(e => e.McxTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MCX_TIPO");
            entity.Property(e => e.McxTipomovimento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("MCX_TIPOMOVIMENTO");
            entity.Property(e => e.McxValor)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("MCX_VALOR");

            entity.HasOne(d => d.CaiCodigoNavigation).WithMany(p => p.TbMovimentodecaixas)
                .HasForeignKey(d => d.CaiCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TB_MOVIMENTODECAIXA_3");
        });

        modelBuilder.Entity<TbMusica>(entity =>
        {
            entity.HasKey(e => e.MusCodigo).HasName("TB_MUSICASPRIMARYKEY1");

            entity.ToTable("TB_MUSICAS", tb =>
                {
                    tb.HasTrigger("DeleteMusica");
                    tb.HasTrigger("ReplicaMusica");
                    tb.HasTrigger("UpdateMusica");
                });

            entity.Property(e => e.MusCodigo)
                .ValueGeneratedNever()
                .HasColumnName("MUS_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.GraCodigo).HasColumnName("GRA_CODIGO");
            entity.Property(e => e.IdFilial).HasColumnName("ID_FILIAL");
            entity.Property(e => e.IdiCodigo).HasColumnName("IDI_CODIGO");
            entity.Property(e => e.MusAlbum)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MUS_ALBUM");
            entity.Property(e => e.MusAno).HasColumnName("MUS_ANO");
            entity.Property(e => e.MusArquivo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("MUS_ARQUIVO");
            entity.Property(e => e.MusAvaliacao).HasColumnName("MUS_AVALIACAO");
            entity.Property(e => e.MusCompositor)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MUS_COMPOSITOR");
            entity.Property(e => e.MusFaixa).HasColumnName("MUS_FAIXA");
            entity.Property(e => e.MusInterprete)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MUS_INTERPRETE");
            entity.Property(e => e.MusNome)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MUS_NOME");
            entity.Property(e => e.MusNomecompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MUS_NOMECOMPLETO");
            entity.Property(e => e.MusPeriodofim)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MUS_PERIODOFIM");
            entity.Property(e => e.MusPeriodoinicio)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MUS_PERIODOINICIO");
            entity.Property(e => e.MusSegundos).HasColumnName("MUS_SEGUNDOS");
            entity.Property(e => e.MusTempo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MUS_TEMPO");
            entity.Property(e => e.MusTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MUS_TIPO");
            entity.Property(e => e.MusTipoperiodo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MUS_TIPOPERIODO");
            entity.Property(e => e.PasCodigo).HasColumnName("PAS_CODIGO");
            entity.Property(e => e.RitCodigo).HasColumnName("RIT_CODIGO");
            entity.Property(e => e.SubCodigo).HasColumnName("SUB_CODIGO");
            entity.Property(e => e.VocCodigo).HasColumnName("VOC_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbMusicas)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_MUSICAS_TB_EMPRESA");
        });

        modelBuilder.Entity<TbNotafiscal21>(entity =>
        {
            entity.HasKey(e => e.NfiCodigo);

            entity.ToTable("TB_NOTAFISCAL21");

            entity.Property(e => e.NfiCodigo)
                .ValueGeneratedNever()
                .HasColumnName("NFI_CODIGO");
            entity.Property(e => e.CtrCodigo).HasColumnName("CTR_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.NfiCfop)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NFI_CFOP");
            entity.Property(e => e.NfiData).HasColumnName("NFI_DATA");
            entity.Property(e => e.NfiMd5)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("NFI_MD5");
            entity.Property(e => e.NfiNumero).HasColumnName("NFI_NUMERO");
            entity.Property(e => e.NfiStatus)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("NFI_STATUS");

            entity.HasOne(d => d.CtrCodigoNavigation).WithMany(p => p.TbNotafiscal21s)
                .HasForeignKey(d => d.CtrCodigo)
                .HasConstraintName("FK_TB_NOTAFISCAL21_1");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbNotafiscal21s)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_NOTAFISCAL21_2");
        });

        modelBuilder.Entity<TbOrdemServico>(entity =>
        {
            entity.HasKey(e => e.OrdCodigo).HasName("PK_TbOrdemServico");

            entity.ToTable("TB_ORDEM_SERVICO");

            entity.Property(e => e.OrdCodigo)
                .ValueGeneratedNever()
                .HasColumnName("ORD_CODIGO");
            entity.Property(e => e.OrdAssunto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ORD_ASSUNTO");
            entity.Property(e => e.OrdDescricao)
                .HasColumnType("text")
                .HasColumnName("ORD_DESCRICAO");
            entity.Property(e => e.OrdSolicitante)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ORD_SOLICITANTE");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbOrdemServicos)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_TB_ORDEM_SERVICO_TB_PESSOAS");
        });

        modelBuilder.Entity<TbOrdemServicoIten>(entity =>
        {
            entity.HasKey(e => e.OrditeCodigo).HasName("PK_TbOrdemServicoItens");

            entity.ToTable("TB_ORDEM_SERVICO_ITENS");

            entity.Property(e => e.OrditeCodigo)
                .ValueGeneratedNever()
                .HasColumnName("ORDITE_CODIGO");
            entity.Property(e => e.AreCodigo).HasColumnName("ARE_CODIGO");
            entity.Property(e => e.OrdCodigo).HasColumnName("ORD_CODIGO");
            entity.Property(e => e.OrditeDataConclusao)
                .HasColumnType("datetime")
                .HasColumnName("ORDITE_DATA_CONCLUSAO");
            entity.Property(e => e.OrditeDataInicio)
                .HasColumnType("datetime")
                .HasColumnName("ORDITE_DATA_INICIO");
            entity.Property(e => e.OrditeDataVence)
                .HasColumnType("datetime")
                .HasColumnName("ORDITE_DATA_VENCE");
            entity.Property(e => e.OrditeDescricao)
                .HasColumnType("text")
                .HasColumnName("ORDITE_DESCRICAO");
            entity.Property(e => e.OrditeFinalizada).HasColumnName("ORDITE_FINALIZADA");
            entity.Property(e => e.OrditePrioridade).HasColumnName("ORDITE_PRIORIDADE");
            entity.Property(e => e.OrditeTitulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ORDITE_TITULO");
            entity.Property(e => e.UsuCodigo).HasColumnName("USU_CODIGO");

            entity.HasOne(d => d.AreCodigoNavigation).WithMany(p => p.TbOrdemServicoItens)
                .HasForeignKey(d => d.AreCodigo)
                .HasConstraintName("FK_TB_ORDEM_SERVICO_ITENS_TB_AREA");

            entity.HasOne(d => d.OrdCodigoNavigation).WithMany(p => p.TbOrdemServicoItens)
                .HasForeignKey(d => d.OrdCodigo)
                .HasConstraintName("FK_TB_ORDEM_SERVICO_ITENS_TB_ORDEM_SERVICO");

            entity.HasOne(d => d.UsuCodigoNavigation).WithMany(p => p.TbOrdemServicoItens)
                .HasForeignKey(d => d.UsuCodigo)
                .HasConstraintName("FK_TB_ORDEM_SERVICO_ITENS_TB_USUARIOS");
        });

        modelBuilder.Entity<TbPessoa>(entity =>
        {
            entity.HasKey(e => e.PesCodigo);

            entity.ToTable("TB_PESSOAS", tb =>
                {
                    tb.HasTrigger("DeletePessoas");
                    tb.HasTrigger("ReplicaPessoas");
                    tb.HasTrigger("UpdatePessoas");
                });

            entity.Property(e => e.PesCodigo)
                .ValueGeneratedNever()
                .HasColumnName("PES_CODIGO");
            entity.Property(e => e.AtiCodigo).HasColumnName("ATI_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PesAnivdia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("PES_ANIVDIA");
            entity.Property(e => e.PesAnivmes)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("PES_ANIVMES");
            entity.Property(e => e.PesBairro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PES_BAIRRO");
            entity.Property(e => e.PesCelular)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PES_CELULAR");
            entity.Property(e => e.PesCep)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("PES_CEP");
            entity.Property(e => e.PesCgccpf)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("PES_CGCCPF");
            entity.Property(e => e.PesCidade)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PES_CIDADE");
            entity.Property(e => e.PesCliente)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PES_CLIENTE");
            entity.Property(e => e.PesClientedesde).HasColumnName("PES_CLIENTEDESDE");
            entity.Property(e => e.PesCodigocom).HasColumnName("PES_CODIGOCOM");
            entity.Property(e => e.PesComissao)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("PES_COMISSAO");
            entity.Property(e => e.PesContato)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("PES_CONTATO");
            entity.Property(e => e.PesContatoFone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PES_CONTATO_FONE");
            entity.Property(e => e.PesContatoFuncao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PES_CONTATO_FUNCAO");
            entity.Property(e => e.PesEmail)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("PES_EMAIL");
            entity.Property(e => e.PesEndereco)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("PES_ENDERECO");
            entity.Property(e => e.PesEstado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("PES_ESTADO");
            entity.Property(e => e.PesFax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PES_FAX");
            entity.Property(e => e.PesFone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PES_FONE");
            entity.Property(e => e.PesFornecedor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PES_FORNECEDOR");
            entity.Property(e => e.PesFuncionario)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PES_FUNCIONARIO");
            entity.Property(e => e.PesGuid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PES_GUID");
            entity.Property(e => e.PesIdFirebase)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PES_ID_FIREBASE");
            entity.Property(e => e.PesInscricao)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PES_INSCRICAO");
            entity.Property(e => e.PesNome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("PES_NOME");
            entity.Property(e => e.PesNumero)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("PES_NUMERO");
            entity.Property(e => e.PesObservacao)
                .IsUnicode(false)
                .HasColumnName("PES_OBSERVACAO");
            entity.Property(e => e.PesPessoa)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("J")
                .HasColumnName("PES_PESSOA");
            entity.Property(e => e.PesRazaosocial)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("PES_RAZAOSOCIAL");
            entity.Property(e => e.PesStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PES_STATUS");
            entity.Property(e => e.PesVendedor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PES_VENDEDOR");
            entity.Property(e => e.PesWeb)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PES_WEB");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbPessoas)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_PESSOAS_TB_EMPRESA");
        });

        modelBuilder.Entity<TbPlanodeconta>(entity =>
        {
            entity.HasKey(e => e.PlcCodigo);

            entity.ToTable("TB_PLANODECONTAS");

            entity.Property(e => e.PlcCodigo)
                .ValueGeneratedNever()
                .HasColumnName("PLC_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PlcContamae)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PLC_CONTAMAE");
            entity.Property(e => e.PlcDescricao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PLC_DESCRICAO");
            entity.Property(e => e.PlcId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PLC_ID");
            entity.Property(e => e.PlcTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PLC_TIPO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbPlanodeconta)
                .HasForeignKey(d => d.EmpCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TB_PLANODECONTAS_2");
        });

        modelBuilder.Entity<TbProduto>(entity =>
        {
            entity.HasKey(e => e.ProCodigo).HasName("PK_TbProduto");

            entity.ToTable("TB_PRODUTO");

            entity.Property(e => e.ProCodigo)
                .ValueGeneratedNever()
                .HasColumnName("PRO_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.ProAlias)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PRO_ALIAS");
            entity.Property(e => e.ProNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRO_NOME");
            entity.Property(e => e.ProNomeProduto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRO_NOME_PRODUTO");
            entity.Property(e => e.ProPercentualLocucao).HasColumnName("PRO_PERCENTUAL_LOCUCAO");
            entity.Property(e => e.ProPercentualVenda).HasColumnName("PRO_PERCENTUAL_VENDA");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbProdutos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_PRODUTO_TB_EMPRESA");
        });

        modelBuilder.Entity<TbProdutoChave>(entity =>
        {
            entity.HasKey(e => e.ChaCodigo).HasName("PK_TbProdutoChave");

            entity.ToTable("TB_PRODUTO_CHAVE");

            entity.Property(e => e.ChaCodigo)
                .ValueGeneratedNever()
                .HasColumnName("CHA_CODIGO");
            entity.Property(e => e.ChaAtivo).HasColumnName("CHA_ATIVO");
            entity.Property(e => e.ChaKey)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CHA_KEY");
            entity.Property(e => e.ChaObersvacao)
                .HasColumnType("text")
                .HasColumnName("CHA_OBERSVACAO");
            entity.Property(e => e.ProcliCodigo).HasColumnName("PROCLI_CODIGO");

            entity.HasOne(d => d.ProcliCodigoNavigation).WithMany(p => p.TbProdutoChaves)
                .HasForeignKey(d => d.ProcliCodigo)
                .HasConstraintName("FK_TB_PRODUTO_CHAVE_TB_PRODUTO_CLIENTE");
        });

        modelBuilder.Entity<TbProdutoCliente>(entity =>
        {
            entity.HasKey(e => e.ProcliCodigo).HasName("PK_TbProdutoCliente");

            entity.ToTable("TB_PRODUTO_CLIENTE");

            entity.Property(e => e.ProcliCodigo)
                .ValueGeneratedNever()
                .HasColumnName("PROCLI_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");
            entity.Property(e => e.PesCodigoFilial).HasColumnName("PES_CODIGO_FILIAL");
            entity.Property(e => e.ProCodigo).HasColumnName("PRO_CODIGO");
            entity.Property(e => e.ProcliData)
                .HasColumnType("datetime")
                .HasColumnName("PROCLI_DATA");
            entity.Property(e => e.ProcliTipoAquisicao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PROCLI_TIPO_AQUISICAO");
            entity.Property(e => e.ProcliVersao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PROCLI_VERSAO");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbProdutoClientes)
                .HasForeignKey(d => d.PesCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_PRODUTO_CLIENTE_TB_PESSOAS");

            entity.HasOne(d => d.ProCodigoNavigation).WithMany(p => p.TbProdutoClientes)
                .HasForeignKey(d => d.ProCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_PRODUTO_CLIENTE_TB_PRODUTO");
        });

        modelBuilder.Entity<TbProgcomercial>(entity =>
        {
            entity.HasKey(e => e.PrcCodigo);

            entity.ToTable("TB_PROGCOMERCIAL");

            entity.Property(e => e.PrcCodigo)
                .ValueGeneratedNever()
                .HasColumnName("PRC_CODIGO");
            entity.Property(e => e.PrcCodigodispositivo).HasColumnName("PRC_CODIGODISPOSITIVO");
            entity.Property(e => e.PrcDatafinal).HasColumnName("PRC_DATAFINAL");
            entity.Property(e => e.PrcDatainicial).HasColumnName("PRC_DATAINICIAL");
            entity.Property(e => e.PrcDomingo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_DOMINGO");
            entity.Property(e => e.PrcHorafinal)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("PRC_HORAFINAL");
            entity.Property(e => e.PrcHorainicial)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("PRC_HORAINICIAL");
            entity.Property(e => e.PrcImpares)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .HasColumnName("PRC_IMPARES");
            entity.Property(e => e.PrcInsdiarias).HasColumnName("PRC_INSDIARIAS");
            entity.Property(e => e.PrcOcultablocoinvalido)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_OCULTABLOCOINVALIDO");
            entity.Property(e => e.PrcOrdem).HasColumnName("PRC_ORDEM");
            entity.Property(e => e.PrcOrdemsugerida).HasColumnName("PRC_ORDEMSUGERIDA");
            entity.Property(e => e.PrcPares)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N")
                .HasColumnName("PRC_PARES");
            entity.Property(e => e.PrcPo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_PO");
            entity.Property(e => e.PrcQuarta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_QUARTA");
            entity.Property(e => e.PrcQuinta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_QUINTA");
            entity.Property(e => e.PrcRenauto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_RENAUTO");
            entity.Property(e => e.PrcSabado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_SABADO");
            entity.Property(e => e.PrcSegunda)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_SEGUNDA");
            entity.Property(e => e.PrcSexta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_SEXTA");
            entity.Property(e => e.PrcSugeriuordem)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_SUGERIUORDEM");
            entity.Property(e => e.PrcTerca)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_TERCA");
            entity.Property(e => e.PrcTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_TIPO");
            entity.Property(e => e.PrcTipodispositivo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PRC_TIPODISPOSITIVO");
            entity.Property(e => e.PrcTotalins).HasColumnName("PRC_TOTALINS");
        });

        modelBuilder.Entity<TbRateio>(entity =>
        {
            entity.HasKey(e => e.RatCodigo);

            entity.ToTable("TB_RATEIO");

            entity.Property(e => e.RatCodigo)
                .ValueGeneratedNever()
                .HasColumnName("RAT_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.RatAlias)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RAT_ALIAS");
            entity.Property(e => e.RatDescricao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RAT_DESCRICAO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbRateios)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_RATEIO_1");
        });

        modelBuilder.Entity<TbRateiocontamensalcontrato>(entity =>
        {
            entity.HasKey(e => e.RcmCodigo);

            entity.ToTable("TB_RATEIOCONTAMENSALCONTRATO");

            entity.Property(e => e.RcmCodigo)
                .ValueGeneratedNever()
                .HasColumnName("RCM_CODIGO");
            entity.Property(e => e.CmcCodigo).HasColumnName("CMC_CODIGO");
            entity.Property(e => e.RatCodigo).HasColumnName("RAT_CODIGO");
            entity.Property(e => e.RcmPercentual)
                .HasColumnType("numeric(3, 2)")
                .HasColumnName("RCM_PERCENTUAL");

            entity.HasOne(d => d.CmcCodigoNavigation).WithMany(p => p.TbRateiocontamensalcontratos)
                .HasForeignKey(d => d.CmcCodigo)
                .HasConstraintName("FK_TB_RATEIOCMC_RATEIO");

            entity.HasOne(d => d.RatCodigoNavigation).WithMany(p => p.TbRateiocontamensalcontratos)
                .HasForeignKey(d => d.RatCodigo)
                .HasConstraintName("FK_TB_RATEIOCONTAMENSALCONTRATO");
        });

        modelBuilder.Entity<TbRateiocontasreceber>(entity =>
        {
            entity.HasKey(e => e.RcrCodigo);

            entity.ToTable("TB_RATEIOCONTASRECEBER");

            entity.Property(e => e.RcrCodigo)
                .ValueGeneratedNever()
                .HasColumnName("RCR_CODIGO");
            entity.Property(e => e.CtrCodigo).HasColumnName("CTR_CODIGO");
            entity.Property(e => e.RatCodigo).HasColumnName("RAT_CODIGO");
            entity.Property(e => e.RcrPercentual)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("RCR_PERCENTUAL");

            entity.HasOne(d => d.CtrCodigoNavigation).WithMany(p => p.TbRateiocontasrecebers)
                .HasForeignKey(d => d.CtrCodigo)
                .HasConstraintName("FK_TB_RATEIOCONTASRECEBER_2");

            entity.HasOne(d => d.RatCodigoNavigation).WithMany(p => p.TbRateiocontasrecebers)
                .HasForeignKey(d => d.RatCodigo)
                .HasConstraintName("FK_TB_RATEIOCONTASRECEBER_1");
        });

        modelBuilder.Entity<TbReplicacao>(entity =>
        {
            entity.HasKey(e => e.RepCodigo);

            entity.ToTable("TB_REPLICACAO");

            entity.Property(e => e.RepCodigo).HasColumnName("REP_CODIGO");
            entity.Property(e => e.RepAlias).HasColumnName("REP_ALIAS");
            entity.Property(e => e.RepAliasPro)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("REP_ALIAS_PRO");
            entity.Property(e => e.RepIdFilial).HasColumnName("REP_ID_FILIAL");
            entity.Property(e => e.RepScript)
                .HasColumnType("text")
                .HasColumnName("REP_SCRIPT");
        });

        modelBuilder.Entity<TbRespostaEmail>(entity =>
        {
            entity.HasKey(e => e.ResCodigo).HasName("PK_TbRespostaEmail");

            entity.ToTable("TB_RESPOSTA_EMAIL");

            entity.Property(e => e.ResCodigo).HasColumnName("RES_CODIGO");
            entity.Property(e => e.EmaCodigo).HasColumnName("EMA_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.ResQtdDiasDepois).HasColumnName("RES_QTD_DIAS_DEPOIS");
            entity.Property(e => e.ResTexto)
                .HasColumnType("text")
                .HasColumnName("RES_TEXTO");
            entity.Property(e => e.ResTipoEnvio).HasColumnName("RES_TIPO_ENVIO");
            entity.Property(e => e.ResTitulo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("RES_TITULO");
            entity.Property(e => e.TemEmaCodigo).HasColumnName("TEM_EMA_CODIGO");
        });

        modelBuilder.Entity<TbSolicitacaoSenha>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_SOLICITACAO_SENHA");

            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");
            entity.Property(e => e.ProCodigo).HasColumnName("PRO_CODIGO");
            entity.Property(e => e.SsCodigo).HasColumnName("SS_CODIGO");
            entity.Property(e => e.SsData)
                .HasColumnType("datetime")
                .HasColumnName("SS_DATA");
            entity.Property(e => e.SsDias).HasColumnName("SS_DIAS");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany()
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_TB_SOLICITACAO_SENHA_TB_PESSOAS");

            entity.HasOne(d => d.ProCodigoNavigation).WithMany()
                .HasForeignKey(d => d.ProCodigo)
                .HasConstraintName("FK_TB_SOLICITACAO_SENHA_TB_PRODUTO");
        });

        modelBuilder.Entity<TbTela>(entity =>
        {
            entity.HasKey(e => new { e.TelCodigo, e.TelModulo }).HasName("TB_TELAS_PK");

            entity.ToTable("TB_TELAS");

            entity.Property(e => e.TelCodigo).HasColumnName("TEL_CODIGO");
            entity.Property(e => e.TelModulo).HasColumnName("TEL_MODULO");
            entity.Property(e => e.TelClass)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("TEL_CLASS");
            entity.Property(e => e.TelDescricao)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("TEL_DESCRICAO");
            entity.Property(e => e.TelTipo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TEL_TIPO");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.UsuCodigo).HasName("PK__TB_USUAR__E96BF4898954CFDA");

            entity.ToTable("TB_USUARIOS", tb =>
                {
                    tb.HasTrigger("DeleteUsuario");
                    tb.HasTrigger("ReplicaUsuario");
                    tb.HasTrigger("UpdateUsuario");
                });

            entity.Property(e => e.UsuCodigo)
                .ValueGeneratedNever()
                .HasColumnName("USU_CODIGO");
            entity.Property(e => e.UsuAcessoAgendaComercial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("USU_ACESSO_AGENDA_COMERCIAL");
            entity.Property(e => e.UsuAcessoCloud)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("USU_ACESSO_CLOUD");
            entity.Property(e => e.UsuAcessoComercial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("USU_ACESSO_COMERCIAL");
            entity.Property(e => e.UsuAcessoFinanceiro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("USU_ACESSO_FINANCEIRO");
            entity.Property(e => e.UsuAcessoLocucao)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("USU_ACESSO_LOCUCAO");
            entity.Property(e => e.UsuAcessoMusical)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("USU_ACESSO_MUSICAL");
            entity.Property(e => e.UsuAcessoTask)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("USU_ACESSO_TASK");
            entity.Property(e => e.UsuAutorizacaoacesso).HasColumnName("USU_AUTORIZACAOACESSO");
            entity.Property(e => e.UsuBairro)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("USU_BAIRRO");
            entity.Property(e => e.UsuCelular)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("USU_CELULAR");
            entity.Property(e => e.UsuCep)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("USU_CEP");
            entity.Property(e => e.UsuCidade)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("USU_CIDADE");
            entity.Property(e => e.UsuDiaaniversario).HasColumnName("USU_DIAANIVERSARIO");
            entity.Property(e => e.UsuEmail)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("USU_EMAIL");
            entity.Property(e => e.UsuEndereco)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("USU_ENDERECO");
            entity.Property(e => e.UsuEnviaNotificacaoLembrete).HasColumnName("USU_ENVIA_NOTIFICACAO_LEMBRETE");
            entity.Property(e => e.UsuEnviaNotificacaoOs).HasColumnName("USU_ENVIA_NOTIFICACAO_OS");
            entity.Property(e => e.UsuFone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("USU_FONE");
            entity.Property(e => e.UsuFuncao)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("USU_FUNCAO");
            entity.Property(e => e.UsuIdFirebase)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USU_ID_FIREBASE");
            entity.Property(e => e.UsuImagem)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("USU_IMAGEM");
            entity.Property(e => e.UsuLogin)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("USU_LOGIN");
            entity.Property(e => e.UsuMesaniversario).HasColumnName("USU_MESANIVERSARIO");
            entity.Property(e => e.UsuMinutosNotificacao).HasColumnName("USU_MINUTOS_NOTIFICACAO");
            entity.Property(e => e.UsuNome)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USU_NOME");
            entity.Property(e => e.UsuObs)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("USU_OBS");
            entity.Property(e => e.UsuPerfilacesso).HasColumnName("USU_PERFILACESSO");
            entity.Property(e => e.UsuPesCodigo).HasColumnName("USU_PES_CODIGO");
            entity.Property(e => e.UsuPlayerIdOnesignal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USU_PLAYER_ID_ONESIGNAL");
            entity.Property(e => e.UsuSenha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USU_SENHA");
            entity.Property(e => e.UsuTipo).HasColumnName("USU_TIPO");
            entity.Property(e => e.UsuUf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("USU_UF");
            entity.Property(e => e.UsuUltimoEnvioNotificacao)
                .HasColumnType("datetime")
                .HasColumnName("USU_ULTIMO_ENVIO_NOTIFICACAO");
        });

        modelBuilder.Entity<TbUsuarioPessoa>(entity =>
        {
            entity.HasKey(e => e.UspCodigo).HasName("PK_TB_USUARIOPESSOA");

            entity.ToTable("TB_USUARIO_PESSOA");

            entity.Property(e => e.UspCodigo)
                .ValueGeneratedNever()
                .HasColumnName("USP_CODIGO");
            entity.Property(e => e.EmpCodigo).HasColumnName("EMP_CODIGO");
            entity.Property(e => e.PesCodigo).HasColumnName("PES_CODIGO");
            entity.Property(e => e.UsuCodigo).HasColumnName("USU_CODIGO");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbUsuarioPessoas)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_TB_USUARIOPESSOA_TB_EMPRESA");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbUsuarioPessoas)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_TB_USUARIOPESSOA_TB_PESSOAS");

            entity.HasOne(d => d.UsuCodigoNavigation).WithMany(p => p.TbUsuarioPessoas)
                .HasForeignKey(d => d.UsuCodigo)
                .HasConstraintName("FK_TB_USUARIOPESSOA_TB_USUARIOS");
        });

        modelBuilder.Entity<TbVersaoProduto>(entity =>
        {
            entity.HasKey(e => e.VprodCodigo);

            entity.ToTable("TB_VERSAO_PRODUTOS");

            entity.Property(e => e.VprodCodigo)
                .ValueGeneratedNever()
                .HasColumnName("VPROD_CODIGO");
            entity.Property(e => e.ProCodigo).HasColumnName("PRO_CODIGO");
            entity.Property(e => e.VprodDescricao)
                .HasColumnType("text")
                .HasColumnName("VPROD_DESCRICAO");
            entity.Property(e => e.VprodNomeArquivo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VPROD_NOME_ARQUIVO");
            entity.Property(e => e.VprodVersao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VPROD_VERSAO");
            entity.Property(e => e.VprodVersaoAtual)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VPROD_VERSAO_ATUAL");

            entity.HasOne(d => d.ProCodigoNavigation).WithMany(p => p.TbVersaoProdutos)
                .HasForeignKey(d => d.ProCodigo)
                .HasConstraintName("FK_TB_VERSAO_PRODUTOS_TB_PRODUTO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
