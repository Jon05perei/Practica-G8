namespace Practica_1.DAL
{
    using Microsoft.EntityFrameworkCore;
    using Practica_1.DAL;

    namespace Practica_1.DAL.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Telefono> Telefonos { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Relación 1 a N: un Cliente tiene muchos Telefonos
                modelBuilder.Entity<Cliente>()
                    .HasMany(c => c.Telefonos)
                    .WithOne()
                    .HasForeignKey(t => t.ClienteId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
}
