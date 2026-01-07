using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanzasPersonales.API.Dtos;
using FinanzasPersonales.Data;


namespace FinanzasPersonales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PagosController(AppDbContext context)
        { _context = context; }
        [HttpPost]
        public async Task<IActionResult> RegistrarPago([FromBody] RegistrarPagoDto pagoDto)
        {
            var deuda = await _context.Deudas.FindAsync(pagoDto.DeudaId);
            if (deuda == null)
            {
                return NotFound($"No se encontró ninguna deuda con el ID {pagoDto.DeudaId}");
            }
            if (pagoDto.Monto > deuda.Monto)
            {
                return BadRequest(" El pago no puede ser superior al monto de la deuda");
            }

            {
            }

            deuda.Monto -= pagoDto.Monto;
            if (deuda.Monto < 0)
            {
                deuda.Monto = 0;
            }

            await _context.SaveChangesAsync();
            return Ok(new
            {
                mensaje = "Pago registrado exitosamente",
                NuevoSaldo = deuda.Monto,

                DeudaSaldada = deuda.Monto == 0
            });
        }


    }
}
