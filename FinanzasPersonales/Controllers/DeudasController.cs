using FinanzasPersonales.API.Models;
using FinanzasPersonales.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanzasPersonales.API.Dtos;

namespace FinanzasPersonales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeudasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeudasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeudaDto>>> Get()

        {
            var deudas = await _context.Deudas
             .Select(d => new DeudaDto
             {
                 Id = d.Id,
                 Descripcion = d.Descripcion,
                 Monto = d.Monto,
                 FechaVencimiento = d.FechaVencimiento,
                 EstaVencida = d.FechaVencimiento < DateTime.Today,

             })
             .ToListAsync();
            return Ok(deudas);
        }
        [HttpGet("total")]
        public async Task<ActionResult<decimal>> ObtenerTotal()
        {
            var listaDeudas = await _context.Deudas.ToListAsync();
            decimal total = 0;
            foreach (var deuda in listaDeudas)
            {
                if (deuda.EsGastoRecurrente())
                {

                    total += deuda.Monto;
                }

            }
            return Ok(total);
        }
        [HttpGet("simulacion")]
        public ActionResult<List<string>> SimularPlan(decimal deuda, decimal cuota)
        {
            int meses = 0;
            var historialDePagos = new List<string>();
            while (deuda > 0)
            {
                decimal pagoDelMes;

                if (deuda < cuota)
                {
                    pagoDelMes = deuda; // Pagamos todo lo que falta
                }
                else
                {
                    pagoDelMes = cuota; // Pagamos la cuota normal
                }

                deuda -= pagoDelMes;
                meses++;
                historialDePagos.Add($"Cuota nro {meses}: ${pagoDelMes}");
            }
            return Ok(historialDePagos);
        } 


        [HttpGet("{id}")]
        public async Task<ActionResult<DeudaDto>> GetDeuda(int id)
        {
            var deuda = await _context.Deudas.FindAsync(id);
            if (deuda == null)
            {
                return NotFound();
            }


            var dto = new DeudaDto
            {
                Id = deuda.Id,
                Descripcion = deuda.Descripcion,
                Monto = deuda.Monto,
                FechaVencimiento = deuda.FechaVencimiento,
                EstaVencida = deuda.FechaVencimiento < DateTime.Today
            };

            return dto;
        }

        [HttpPost]
        public async Task<IActionResult> CrearDeuda(CrearDeudaDto dto)
        {
            var deudaReal = new Deuda
            {
                Descripcion = dto.Descripcion,
                MontoOriginal = dto.Monto,
                Monto = dto.Monto,
                FechaVencimiento = dto.FechaVencimiento
            };
            _context.Deudas.Add(deudaReal);
            await _context.SaveChangesAsync();
            return Ok(deudaReal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeuda(int id)
        {
            var deuda = await _context.Deudas.FindAsync(id);

            if (deuda == null)
            {
                return NotFound();
            }

            _context.Deudas.Remove(deuda);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDeuda(int id, ActualizarDeudaDto dto)
        {
            var deuda = await _context.Deudas.FindAsync(id);

            if (deuda == null)
            {
                return NotFound();
            }

            deuda.Descripcion = dto.Descripcion;
            deuda.Monto = dto.Monto;
            deuda.FechaVencimiento = dto.FechaVencimiento;

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}