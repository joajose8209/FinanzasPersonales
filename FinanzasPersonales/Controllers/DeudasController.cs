using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.API.Models;
namespace FinanzasPersonales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeudasController : ControllerBase
    {
        private static List<Deuda> _repositorioDeudas = new List<Deuda>
        { new Deuda
        {
            Id = 1,
            Descripcion = "Préstamo personal MercadoPago",
            MontoOriginal = 200000m,
            Monto = 400565.13m,
            CostoFinancieroTotal = 320.07m,
            FechaVencimiento = new DateTime(2025, 10, 10)
        },
        new Deuda
        {
            Id = 2,
            Descripcion = "Préstamo personal MercadoPago2",
            MontoOriginal = 29000m,
            Monto = 58020.79m,
            CostoFinancieroTotal = 320.07m,
            FechaVencimiento = new DateTime(2025, 10, 10)
        }

        };

        [HttpGet]
        public IEnumerable<Deuda> Get()
        {
            return _repositorioDeudas;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Deuda nuevaDeuda)
        {
            if (nuevaDeuda == null)
            {
                return BadRequest();
            }
            _repositorioDeudas.Add(nuevaDeuda);
            return CreatedAtAction(nameof(Get), new { id = nuevaDeuda.Id }, nuevaDeuda);
        }

    }
}