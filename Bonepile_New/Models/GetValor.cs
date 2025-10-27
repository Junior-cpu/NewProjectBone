using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonepile_New.Models
{
    [Table("GetValor")]
    public class GetValor
    {
        [Key]
        public double PRECO_MEDIO_MENSAL_EM_USD { get; set; }
    }
}
