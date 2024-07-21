using ServerApi.Data;
using ServerApi.Models;

namespace ServerApi.Repositories.Interfaces
{
    public interface ITropeRepository
    {
        Task<IEnumerable<Trope>> GetAllTropeuriAsync();
        Task<Trope> GetTropeByIdAsync(int id);
        Task<Trope> AddTropeAsync(Trope trope);
        Task UpdateTropeAsync(Trope trope);
        Task DeleteTropeAsync(int id);
    }
}
