

using ServerApi.Models;

namespace ServerApi.Repositories.Interfaces
{
    public interface IGenRepository
    {
        Task<IEnumerable<Gen>> GetAllGenuriAsync();
        Task<Gen> GetGenByIdAsync(int id);

    }
}
