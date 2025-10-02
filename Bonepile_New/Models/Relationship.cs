namespace Bonepile_New.Models;

public class Relationship
{
    public long Id { get; set; }
    public long Part_Number_Id { get; set; }
    public long NickName_Id { get; set; }
    public long Employee_Id_Create { get; set; }
    public long Employee_Id_Update { get; set; }
    public DateTime Create_Date { get; set; }
    public DateTime Update_Date { get; set; }

}
