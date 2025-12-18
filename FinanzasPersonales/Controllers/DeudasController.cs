using FinanzasPersonales.API.Models;
using FinanzasPersonales.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<Deuda>> GetDeuda(int id)
        {
            var deuda = await _context.Deudas.FindAsync(id);
            if (deuda == null)
            {
                return NotFound();
            }
            return deuda;
        }

        // DELETE: api/Deudas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeuda(int id)
        {
            // 1. Buscamos la deuda
            var deuda = await _context.Deudas.FindAsync(id);

            // 2. Si no existe, error 404
            if (deuda == null)
            {
                return NotFound();
            }

            // 3. Si existe, la removemos del contexto
            _context.Deudas.Remove(deuda);

            // 4. Confirmamos los cambios en la Base de Datos
            await _context.SaveChangesAsync();

            // 5. Devolvemos "Sin Contenido" (Código 204 - Éxito silencioso)
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Deuda nuevaDeuda)
        {
            if (nuevaDeuda == null) return BadRequest();

            _context.Deudas.Add(nuevaDeuda);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = nuevaDeuda.Id }, nuevaDeuda);
        }

    }
}