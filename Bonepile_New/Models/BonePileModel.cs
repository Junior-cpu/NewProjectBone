using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonepile_New.Models;
[Table("UDTLOOK_UP_BONE_GERAL_HISTORICO1")]
public class BonePileModel
{
    [Key]
    public long Id{ get; set; }
    public string Almoxarifado { get; set; } = string.Empty;
    public string Item { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Data_Ultima_Contagem { get; set; } = string.Empty;
    public string Estoque_Disponivel { get; set; } = string.Empty;
    public string Local { get; set; } = string.Empty;
    public string Unid_Estoq { get; set; } = string.Empty;
    public string Lote { get; set; } = string.Empty;
    public double Preco_Medio_Mensal_Em_BRL { get; set; }
    public double Preco_Medio_Mensal_Em_USD { get; set; }



    public string Codigo_ABC { get; set; } = string.Empty;
    public string Data_Ulima_Transicao { get; set; } = string.Empty;
    public string Fifo { get; set; } = string.Empty;
    public string Aging { get; set; } = string.Empty;
    public DateTime Data_Insercao { get; set; }
}
