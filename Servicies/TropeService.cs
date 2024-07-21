using AutoMapper;
using ServerApi.Dtos;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;
using ServerApi.Servicies.Interfaces;

namespace ServerApi.Servicies
{
    public class TropeService : ITropeService
    {
        private readonly ITropeRepository _tropeRepository;
        private readonly IMapper _mapper;

        public TropeService(ITropeRepository tropeRepository, IMapper mapper)
        {
            _tropeRepository = tropeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TropeDto>> GetAllTropeuriAsync()
        {
            var tropeuri = await _tropeRepository.GetAllTropeuriAsync();
            return _mapper.Map<IEnumerable<TropeDto>>(tropeuri);
        }

        public async Task<TropeDto> GetTropeByIdAsync(int id)
        {
            var trope = await _tropeRepository.GetTropeByIdAsync(id);
            return _mapper.Map<TropeDto>(trope);
        }

        public async Task<TropeDto> AddTropeAsync(TropeDto trope)
        {
            var tropeToAdd = _mapper.Map<Trope>(trope);
            var tropeAdded = await _tropeRepository.AddTropeAsync(tropeToAdd);
            return _mapper.Map<TropeDto>(tropeAdded);
        }

        public async Task UpdateTropeAsync(TropeDto trope)
        {
            var tropeToUpdate = _mapper.Map<Trope>(trope);
            await _tropeRepository.UpdateTropeAsync(tropeToUpdate);
        }

        public async Task DeleteTropeAsync(int id)
        {
            await _tropeRepository.DeleteTropeAsync(id);
        }
    }
}
