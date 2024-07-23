using ServerApi.Dtos.OtherDtos;

namespace ServerApi.Servicies.Interfaces
{
    public interface ITropeService
    {
        Task<IEnumerable<TropeDto>> GetAllTropeuriAsync();
        Task<TropeDto> GetTropeByIdAsync(int id);
        Task<TropeDto> AddTropeAsync(TropeDto trope);
        Task UpdateTropeAsync(TropeDto trope);
        Task DeleteTropeAsync(int id);
    }
}
