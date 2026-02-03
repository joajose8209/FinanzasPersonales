using System.Globalization;

namespace FinanzasPersonales.API.Models
{
    public class Pago
    {
        public int Id { get; set; }
       
        public int DeudaId { get; set; }
        
        public Deuda? Deuda { get; set; }

        public decimal Monto { get; set; }

        public string MedioPago { get; set; } = string.Empty;

        public DateTime FechaPago { get; set; } = DateTime.Now;

    }

}

