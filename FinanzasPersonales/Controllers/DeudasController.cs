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
        public async Task<IEnumerable<Deuda>> Get()
        {
            return await _context.Deudas.ToListAsync();
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