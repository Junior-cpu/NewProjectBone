namespace Bonepile_New.Models
{
    public class HardRepairModel1
    {
        public long Id { get; set; }
        public string Serial_Number { get; set; } = string.Empty;
        public string Unit_Status { get; set; } = string.Empty;
        public string Unit_State { get; set; } = string.Empty;
        public string Part_Number { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Station { get; set; } = string.Empty;
        public DateTime Update_Date { get; set; }
        public int Aging { get; set; }
    }
}
