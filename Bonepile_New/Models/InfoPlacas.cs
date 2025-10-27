using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonepile_New.Models;
[Table("InfoPlacas")]
public class InfoPlacas
{

    public long Id { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string StateDescription { get; set; } = string.Empty;
    public string PoNumber { get; set; } = string.Empty;
    public string Partnumber { get; set; } = string.Empty;
    public string Revision { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public string Produto { get; set; } = string.Empty;
    public string StationFail { get; set; } = string.Empty;
    public string Failure { get; set; } = string.Empty;
    public string DateFail { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;


}
