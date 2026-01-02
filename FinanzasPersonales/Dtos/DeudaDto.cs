namespace FinanzasPersonales.API.Dtos
{
    public class DeudaDto
    {
        public int Id { get; set; } // <--- La diferencia clave: Este SÍ tiene ID
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool EstaVencida { get; set; } // <--- Y este dato calculado
    }
}