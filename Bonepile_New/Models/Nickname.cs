namespace Bonepile_New.Models;

public class Nickname
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
    public long Employee_Id_Create { get; set; }
    public DateTime Create_Date { get; set; }
    public DateTime Update_Date { get; set; }
}
