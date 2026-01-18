using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanzasPersonales.API.Models;
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
        {   if(pagoDto.FechaDePago > DateTime.Now)
            {
                return BadRequest(" La fecha de pago no puede ser futura");
            }
           
            if (pagoDto.Monto <= 0)
            {
                return BadRequest(" El pago no puede ser  cero o negativo");
            }

            var deuda = await _context.Deudas.FindAsync(pagoDto.DeudaId);
            if (deuda == null)
            {
                return NotFound($"No se encontró ninguna deuda con el ID {pagoDto.DeudaId}");
            }
            if (pagoDto.Monto > deuda.Monto)
            {
                return BadRequest(" El pago no puede ser superior al monto de la deuda");



            }

            var nuevoPago = new Pago
            {
                DeudaId = pagoDto.DeudaId,
                Monto = pagoDto.Monto,
                MedioPago = pagoDto.MedioPago,
                FechaPago = pagoDto.FechaDePago
            };
            _context.Pagos.Add(nuevoPago);




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



        [HttpGet("{deudaId}")]
        public async Task<ActionResult<List<Pago>>> ObtenerPagos(int deudaId)
        {
            var pagos = await _context.Pagos
                .Where(p => p.DeudaId == deudaId)
                .ToListAsync();
            return Ok(pagos);
        }


    }
}
