using LocationsAPI.Resources.Models;

namespace LocationsAPI.Dal.Pais
{
    public interface IPaisesDal
    {
        Task<List<PaisModel>> GetPaises();
        Task<PaisModel> AddPais(PaisModel paisDto);
        Task<PaisModel> UpdatePais(int id, PaisModel paisDto);
        Task<PaisModel?> GetPaisById(int id);
        Task<bool> DeletePais(int id);
    }
}
