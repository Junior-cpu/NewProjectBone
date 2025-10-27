using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonepile_New.Models
{
    [Table("UDTLOOK_UP_BONE_GERAL_HISTORICO_CHART")]
    public class BonepileChartModel
    {
        [Key]
        public long Id { get; set; }
        public string Almoxarifado { get; set; } = string.Empty;
        public string Item { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Estoque_Disponivel { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public string Unid_Estoq { get; set; } = string.Empty;
        public double Preco_Medio_Mensal_Em_Brl { get; set; }
        public double Preco_Medio_Mensal_Em_Usd { get; set; }
        public string Aging { get; set; } = string.Empty;
        public DateTime Data_Insercao { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Customer_Division { get; set; } = string.Empty;
        public DateTime Data_Update { get; set; }

    }
}
