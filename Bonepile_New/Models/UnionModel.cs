namespace Bonepile_New.Models
{
    public class UnionModel
    {

        public long Id { get; set; }
        public string Local { get; set; }= string.Empty;
        public string Serial_Number { get; set; } = string.Empty;   
        public string Part_Number { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Acao { get; set; } = string.Empty;
        public string Falha { get; set; } = string.Empty;
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; } // Pode ser nulo
        public int Aging { get; set; }
        public double Valor { get; set; }   

    }
}
