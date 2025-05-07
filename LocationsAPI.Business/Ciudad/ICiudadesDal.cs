using LocationsAPI.Resources.Models;

namespace LocationsAPI.Dal.Ciudad
{
    public interface ICiudadesDal
    {
        Task<List<CiudadModel>> GetCiudades(int departamentoId);
        Task<CiudadModel> AddCiudad(CiudadModel ciudadDto);
        Task<CiudadModel> ModifyCiudad(int id, CiudadModel ciudadDto);
        Task<bool> DeleteCiudad(int id);
    }
}
