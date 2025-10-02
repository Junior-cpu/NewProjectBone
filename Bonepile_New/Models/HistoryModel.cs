using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonepile_New.Models;
[Table("rvwHistory")]
public class HistoryModel
{
    public long CustomerDivisionId { get; set; }
    [Key]
    public long HistoryId { get; set; }
    public DateTime Datetime { get; set; }
    public long UnitId { get; set; }
    public string? Serialnumber { get; set; } 
    public long HistoryPartId { get; set; }
    public string? Partnumber { get; set; } 
    public string? Family { get; set; } 
    public string? Station { get; set; } 
    public long StationTypeId { get; set; }
    public string? Station_Type { get; set; } 
    public long LineId { get; set; }
    public string? Line { get; set; } 
    public long UnitStateId { get; set; }
    public string? Unit_State { get; set; } 
    public string? PO { get; set; } 
    public string? User_Id { get; set; } 
    public string? User_Name { get; set; } 
    public string? User_Group { get; set; } 
    public long UnitPartId { get; set; }
    public string? UnitPartNumber { get; set; } 
    public string? AppProjectName { get; set; } 


}
