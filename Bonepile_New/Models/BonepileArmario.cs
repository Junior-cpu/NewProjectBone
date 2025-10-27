using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonepile_New.Models;
[Table("UDTBONE_BONE_PILE_ARMARIO")]
public class BonepileArmario
{
    [Key]
    public long Id { get; set; }
    public string Coluna { get; set; } = string.Empty;
    public string Linha { get; set; } = string.Empty;
    public string Part_Number_Alocado { get; set; } = string.Empty;
    public int Qtd { get; set; }
    public int Qtd_Max { get; set; }
}
