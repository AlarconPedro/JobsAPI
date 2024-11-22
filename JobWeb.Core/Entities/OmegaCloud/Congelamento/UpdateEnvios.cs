namespace JobWeb.Core.Entities.OmegaCloud.Congelamento;

public class UpdateEnvios
{
    public int CngCodigo { get; set; }
    public bool? CngAvisocobranca { get; set; }
    public DateTime? CngDataavisocobranca { get; set; }
    public bool? CngAvisocongelamento { get; set; }
    public DateTime? CngDataavisocongelamento { get; set; }
    public bool? CngAvisoprotesto { get; set; }
    public DateTime? CngDataavisoprotesto { get; set; }
}
