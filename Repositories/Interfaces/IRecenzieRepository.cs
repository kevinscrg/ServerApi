using ServerApi.Models;

namespace ServerApi.Repositories.Interfaces
{
    public interface IRecenzieRepository
    {
        Task<IEnumerable<Recenzie>> GetAllRecenziiAsync();
        Task<Recenzie> GetRecenzieByIdAsync(int id);
        Task<Recenzie> AddRecenzieAsync(Recenzie recenzie);
        Task UpdateRecenzieAsync(Recenzie recenzie);
        Task DeleteRecenzieAsync(int id);

        Task AddRecenzieToCarteAsync(int recenzieId, int carteId);
        
        Task AddRecenzieToUserAsync(int recenzieId, int userId);

        Task UpdateRecenzieStatusAsync(int recenzieId, string status);
    }
}
