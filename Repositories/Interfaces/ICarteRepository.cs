using ServerApi.Models;

namespace ServerApi.Repositories.Interfaces
{
    public interface ICarteRepository
    {
        Task<IEnumerable<Carte>> GetAllCartiAsync();
        Task<Carte> GetCarteByIdAsync(int id);
        Task<Carte> AddCarteAsync(Carte carte);
        Task UpdateCarteAsync(Carte carte);
        Task DeleteCarteAsync(int id);
    }
}
