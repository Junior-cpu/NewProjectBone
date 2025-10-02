namespace Bonepile_New.Models;

public class PartNumber
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long Customer_Division_Id { get; set; }
    public long Employee_Id_Create { get; set; }
    public long Employee_Id_Update { get; set; }
    public DateTime Create_Date { get; set; }
    public DateTime Update_Date { get; set; }

}
