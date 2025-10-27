using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonepile_New.Models
{
    [Table("UDTBONE_GERAR_ARMARIO_IN_BONE_PILE")]
    public class Armario_BoneModel
    {
        [Key]
        public long ID { get; set; }
        public string name { get; set; }= string.Empty;
        public int qtda_Gavetas { get; set; }

    }
}
