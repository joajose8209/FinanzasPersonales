namespace FinanzasPersonales.API.Dtos
{
    public class DeudaDto
    {
        public int Id { get; set; } 
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool EstaVencida { get; set; } 
    }
}