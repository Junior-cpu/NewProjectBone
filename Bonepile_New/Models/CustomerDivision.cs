namespace Bonepile_New.Models;

public class CustomerDivision
{
    public long Id { get; set; }
    public long Customer_Id { get; set; }
    public bool Active { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Customer_Division_Code_Baan { get; set; } = string.Empty;
    public long Employee_Id_create { get; set; }
    public long Employee_Id_Update { get; set; }
    public DateTime Create_Date { get; set; }
    public DateTime Update_Date { get; set; }
}
