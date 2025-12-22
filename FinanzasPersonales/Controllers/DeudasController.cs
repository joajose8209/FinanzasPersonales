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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Deuda nuevaDeuda)
        {
            if (nuevaDeuda == null) return BadRequest();

            _context.Deudas.Add(nuevaDeuda);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = nuevaDeuda.Id }, nuevaDeuda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeuda(int id, Deuda deuda)
        {
            if (id != deuda.Id)
            {
                return BadRequest();
            }
            _context.Entry(deuda).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeudaExists(id))
                {
                    return NotFound();

                }
                else
                {
                    throw;
                }

            }

            return NoContent();

        }
        private bool DeudaExists(int id)
        {
            return _context.Deudas.Any(e => e.Id == id);
        }
    }
}