using LocationsAPI.Resources.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationsAPI.Resources.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<PaisModel> Paises { get; set; }
        public DbSet<DepartamentoModel> Departamentos { get; set; }
        public DbSet<CiudadModel> Ciudades { get; set; }
    }
}
