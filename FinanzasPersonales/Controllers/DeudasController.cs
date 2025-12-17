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