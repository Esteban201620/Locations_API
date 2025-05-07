using LocationsAPI.Resources.Context;
using LocationsAPI.Resources.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationsAPI.Dal.Ciudad
{
    public class CiudadesDal(DataContext _context) : ICiudadesDal
    {
        public async Task<List<CiudadModel>> GetCiudades(int departamentoId)
        {
            return await _context.Ciudades
                .Where(c => c.DepartamentoId == departamentoId)
                .ToListAsync();
        }

        public async Task<CiudadModel> AddCiudad(CiudadModel ciudadDto)
        {
            var ciudad = new CiudadModel
            {
                Nombre = ciudadDto.Nombre,
                DepartamentoId = ciudadDto.DepartamentoId
            };
            _context.Ciudades.Add(ciudad);
            await _context.SaveChangesAsync();

            return ciudad;
        }

        public async Task<CiudadModel> ModifyCiudad(int id, CiudadModel ciudadDto)
        {
            var ciudad = await _context.Ciudades.FindAsync(id);
            if (ciudad == null)
            {
                throw new Exception($"Ciudad with ID {id} not found.");
            }

            ciudad.Nombre = ciudadDto.Nombre;
            await _context.SaveChangesAsync();

            return ciudad;
        }

        public async Task<bool> DeleteCiudad(int id)
        {
            var ciudad = await _context.Ciudades.FindAsync(id);
            if (ciudad == null)
                return false;

            _context.Ciudades.Remove(ciudad);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
