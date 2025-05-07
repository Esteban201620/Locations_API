using LocationsAPI.Resources.Models;

namespace LocationsAPI.Dal.Departamento
{
    public interface IDepartamentosDal
    {
        Task<List<DepartamentoModel>> GetDepartamentos(int paisId);
        Task<DepartamentoModel> AddDepartamento(DepartamentoModel departamentoDto);
        Task<DepartamentoModel> ModifyDepartamento(int id, DepartamentoModel departamentoDto);
        Task<bool> DeleteDepartamento(int id);
    }
}
