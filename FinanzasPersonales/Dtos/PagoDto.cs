namespace FinanzasPersonales.API.Dtos
{
    public class PagoDto
    {
        public string DeudaDescripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }

    }
}
