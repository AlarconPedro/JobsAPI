namespace JobWeb.Core.Entities.OmegaCloud.Usuario;

public class DetalhesUsuario
{
    public int UsuCodigo { get; set; }
    public int? EmpCodigo { get; set; }
    public string? EmpNome { get; set; }
    public string? EmpCidade { get; set; }
    public string? UsuNome { get; set; }
    public string? UsuLogin { get; set; }
    public string? UsuSenha { get; set; }
    public string? UsuAcessoCloud { get; set; }
    public string? UsuIdFirebase { get; set; }
}
