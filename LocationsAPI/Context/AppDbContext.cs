
using LocationsAPI.Resources.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationsAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<Pais> Paises { get; set; }
        //public DbSet<Departamento> Departamentos { get; set; }
        //public DbSet<Ciudad> Ciudades { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Pais>()
        //        .HasKey(p => p.PaisId);

        //    modelBuilder.Entity<Departamento>()
        //        .HasKey(d => d.DepartamentoId);

        //    modelBuilder.Entity<Departamento>()
        //        .HasOne<Pais>()
        //        .WithMany()
        //        .HasForeignKey(d => d.PaisId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Ciudad>()
        //        .HasKey(c => c.CiudadId);

        //    modelBuilder.Entity<Ciudad>()
        //        .HasOne<Departamento>()
        //        .WithMany()
        //        .HasForeignKey(c => c.DepartamentoId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
