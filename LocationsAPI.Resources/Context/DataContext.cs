using LocationsAPI.Resources.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationsAPI.Resources.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<PaisModel> Paises { get; set; }
        public DbSet<DepartamentoModel> Departamentos { get; set; }
        public DbSet<CiudadModel> Ciudades { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Configuración de País -> Departamentos
        //    modelBuilder.Entity<PaisModel>()
        //        .HasMany(p => p.Departamentos)
        //        .WithOne()
        //        .HasForeignKey(d => d.PaisId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // Configuración de Departamento -> Ciudades
        //    modelBuilder.Entity<DepartamentoModel>()
        //        .HasMany(d => d.Ciudades)
        //        .WithOne()
        //        .HasForeignKey(c => c.DepartamentoId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
