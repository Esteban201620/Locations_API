using LocationsAPI.Resources.Context;
using LocationsAPI.Resources.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationsAPI.Dal.Departamento
{
    public class DepartamentosDal(DataContext _context) : IDepartamentosDal
    {
        public async Task<List<DepartamentoModel>> GetDepartamentos(int paisId)
        {
            return await _context.Departamentos
                .Where(d => d.PaisId == paisId)
                .Include(d => d.Ciudades)
                .ToListAsync();
        }

        public async Task<DepartamentoModel> AddDepartamento(DepartamentoModel departamentoDto)
        {
            var departamento = new DepartamentoModel
            {
                Nombre = departamentoDto.Nombre,
                PaisId = departamentoDto.PaisId
            };
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            return departamento;
        }

        public async Task<DepartamentoModel> ModifyDepartamento(int id, DepartamentoModel departamentoDto)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                throw new Exception($"Departamento with ID {id} not found.");
            }

            departamento.Nombre = departamentoDto.Nombre;
            await _context.SaveChangesAsync();

            return departamento;
        }

        public async Task<bool> DeleteDepartamento(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
                return false;

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
