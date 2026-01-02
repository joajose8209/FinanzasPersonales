namespace FinanzasPersonales.API.Dtos
{
    public class CrearDeudaDto
    {
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
