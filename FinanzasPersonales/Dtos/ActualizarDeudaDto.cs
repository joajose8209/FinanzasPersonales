using System;
using System.ComponentModel.DataAnnotations; // Opcional, por si quieres validar campos obligatorios a futuro

namespace FinanzasPersonales.API.Dtos
{
    public class ActualizarDeudaDto
    {
        // El "Menú" de edición: Solo lo que permitimos cambiar
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(50, MinimumLength =3 , ErrorMessage = "La descripcion debe tener entre 3 y 50 caracteres")]
        public string Descripcion { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal Monto { get; set; }

        public DateTime FechaVencimiento { get; set; }
    }
}