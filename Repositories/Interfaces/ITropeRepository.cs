using ServerApi.Data;
using ServerApi.Models;

namespace ServerApi.Repositories.Interfaces
{
    public interface ITropeRepository
    {
        Task<IEnumerable<Trope>> GetAllTropeuriAsync();
        Task<Trope> GetTropeByIdAsync(int id);
    }
}
