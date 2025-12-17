using Microsoft.EntityFrameworkCore;
using FinanzasPersonales.API.Models;

namespace FinanzasPersonales.Data
{
public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)  : base(options)
        {
        }
        public DbSet<Deuda> Deudas { get; set; }
    }

}


