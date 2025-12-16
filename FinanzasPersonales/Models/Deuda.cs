namespace FinanzasPersonales.API.Models
{
    public class Deuda
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public decimal MontoOriginal { get; set; }

        public decimal Monto { get; set; }

        public decimal CostoFinancieroTotal { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public bool EstaVencida => DateTime.Now > FechaVencimiento;


    }

}
