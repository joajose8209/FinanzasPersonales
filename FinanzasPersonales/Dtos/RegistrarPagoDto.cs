namespace FinanzasPersonales.API.Dtos
{
    public class RegistrarPagoDto
    { public int DeudaId { get; set; }
        public decimal Monto { get; set; }

        public string MedioPago { get; set; } = string.Empty;

        public DateTime FechaDePago { get; set; } = DateTime.Now;
    }
}
