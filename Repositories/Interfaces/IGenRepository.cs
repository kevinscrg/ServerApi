

using ServerApi.Models;

namespace ServerApi.Repositories.Interfaces
{
    public interface IGenRepository
    {
        Task<IEnumerable<Gen>> GetAllGenuriAsync();
        Task<Gen> GetGenByIdAsync(int id);
        Task<Gen> AddGenAsync(Gen gen);
        Task UpdateGenAsync(Gen gen);
        Task DeleteGenAsync(int id);

    }
}
