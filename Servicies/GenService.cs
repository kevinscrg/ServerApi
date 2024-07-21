using AutoMapper;
using ServerApi.Dtos;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;
using ServerApi.Servicies.Interfaces;

namespace ServerApi.Servicies
{
    public class GenService : IGenService
    {
        private readonly IGenRepository _genRepository;
        private readonly IMapper _mapper;

        public GenService(IGenRepository genRepository, IMapper mapper)
        {
            _genRepository = genRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenDto>> GetAllGenuriAsync()
        {
            var genuri = await _genRepository.GetAllGenuriAsync();
            return _mapper.Map<IEnumerable<GenDto>>(genuri);
        }

        public async Task<GenDto> GetGenByIdAsync(int id)
        {
            var gen = await _genRepository.GetGenByIdAsync(id);
            return _mapper.Map<GenDto>(gen);
        }

        public async Task<GenDto> AddGenAsync(GenDto gen)
        {
            var genToAdd = _mapper.Map<Gen>(gen);
            var genAdded = await _genRepository.AddGenAsync(genToAdd);
            return _mapper.Map<GenDto>(genAdded);
        }

        public async Task UpdateGenAsync(GenDto gen)
        {
            var genToUpdate = _mapper.Map<Gen>(gen);
            await _genRepository.UpdateGenAsync(genToUpdate);
        }

        public async Task DeleteGenAsync(int id)
        {
            await _genRepository.DeleteGenAsync(id);
        }

    }
    
}
