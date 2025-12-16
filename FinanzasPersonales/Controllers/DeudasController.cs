using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.API.Models;
namespace FinanzasPersonales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeudasController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Deuda> Get()
        {
            return new List<Deuda>
        { new Deuda
        {
            Id = 1,
            Descripcion = "Préstamo personal",
            MontoOriginal =200000m,
            Monto = 400565.13m,
            CostoFinancieroTotal = 320.07m,
            FechaVencimiento = new DateTime(2025, 10, 10)
        },
        new Deuda
        {
            Id = 2,
            Descripcion = "Préstamo personal",
            MontoOriginal =29000m,
            Monto = 58020.79m,
            CostoFinancieroTotal = 320.07m,
            FechaVencimiento = new DateTime(2025, 10, 10)
        }
        };
        }

    }
}