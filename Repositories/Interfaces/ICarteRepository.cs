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

        Task AddGenToCarteAsync(int carteId, int genId);

        Task AddGenuriToCarteAsync(int carteId, List<int> genuriId);

        Task AddTropeToCarteAsync(int carteId, int tropeId);

        Task AddTropeuriToCarteAsync(int carteId, List<int> tropeuriId);

        Task DeleteGenFromCarteAsync(int carteId, int genId);

        Task DeleteTropeFromCarteAsync(int carteId, int tropeId);
    }
}
