using LocationsAPI.Resources.Context;
using LocationsAPI.Resources.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationsAPI.Dal.Pais
{
    public class PaisesDal(DataContext _context) : IPaisesDal
    {

        public async Task<List<PaisModel>> GetPaises()
        {
            var paises = await _context.Paises
                .Include(p => p.Departamentos)
                    .ThenInclude(d => d.Ciudades)
                .Select(p => new PaisModel
                {
                    PaisId = p.PaisId,
                    Nombre = p.Nombre,
                    Departamentos = p.Departamentos.Select(d => new DepartamentoModel
                    {
                        DepartamentoId = d.DepartamentoId,
                        Nombre = d.Nombre,
                        Ciudades = d.Ciudades.Select(c => new CiudadModel
                        {
                            CiudadId = c.CiudadId,
                            Nombre = c.Nombre
                        }).ToList()
                    }).ToList()
                }).ToListAsync();

            return paises;
        }

        public async Task<PaisModel> AddPais(PaisModel paisDto)
        {
            var pais = new PaisModel
            {
                Nombre = paisDto.Nombre
            };
            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();

            return pais;
        }

        public async Task<PaisModel> UpdatePais(int id, PaisModel paisDto)
        {
            var pais = await _context.Paises.FindAsync(id) ?? throw new Exception($"Pais with ID {id} not found.");
            pais.Nombre = paisDto.Nombre;
            await _context.SaveChangesAsync();

            return pais;
        }

        public async Task<PaisModel?> GetPaisById(int id)
        {
            return await _context.Paises
                .Include(p => p.Departamentos)
                    .ThenInclude(d => d.Ciudades)
                .FirstOrDefaultAsync(p => p.PaisId == id);
        }

        public async Task<bool> DeletePais(int id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
                return false;

            _context.Paises.Remove(pais);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
