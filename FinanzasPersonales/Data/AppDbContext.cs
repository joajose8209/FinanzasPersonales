using Microsoft.EntityFrameworkCore;
using FinanzasPersonales.API.Models;

namespace FinanzasPersonales.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Deuda> Deudas { get; set; }
        public DbSet<Pago> Pagos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pago>()
.Property(p => p.Monto)
.HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Deuda>(entity =>
            {
                entity.Property(d => d.Monto).HasColumnType("decimal(18, 2)");
                entity.Property(d => d.MontoOriginal).HasColumnType("decimal(18,2)");
                entity.Property(d => d.CostoFinancieroTotal).HasColumnType("decimal(18,2)");

            });

        }
    }
}