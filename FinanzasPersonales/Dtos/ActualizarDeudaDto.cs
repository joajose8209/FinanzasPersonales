using System;
using System.ComponentModel.DataAnnotations; // Opcional, por si quieres validar campos obligatorios a futuro

namespace FinanzasPersonales.API.Dtos
{
    public class ActualizarDeudaDto
    {
        // El "Menú" de edición: Solo lo que permitimos cambiar

        public string Descripcion { get; set; } = string.Empty;

        public decimal Monto { get; set; }

        public DateTime FechaVencimiento { get; set; }
    }
}