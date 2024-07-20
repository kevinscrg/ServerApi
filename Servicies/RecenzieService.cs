using AutoMapper;
using ServerApi.Dtos;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;
using ServerApi.Servicies.Interfaces;

namespace ServerApi.Servicies
{
    public class RecenzieService : IRecenzieService
    {
        private readonly IRecenzieRepository _recenzieRepository;
        private readonly IMapper _mapper;

        public RecenzieService(IRecenzieRepository recenzieRepository, IMapper mapper)
        {
            _recenzieRepository = recenzieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecenzieDto>> GetAllRecenziiAsync()
        {
            var recenzii = await _recenzieRepository.GetAllRecenziiAsync();
            return _mapper.Map<IEnumerable<RecenzieDto>>(recenzii);
        }

        public async Task<RecenzieDto> GetRecenzieByIdAsync(int id)
        {
            var recenzie = await _recenzieRepository.GetRecenzieByIdAsync(id);
            return _mapper.Map<RecenzieDto>(recenzie);
        }

        public async Task<RecenzieDto> AddRecenzieAsync(RecenzieDto recenzie)
        {
            var recenzieToAdd = _mapper.Map<Recenzie>(recenzie);
            var recenzieAdded = await _recenzieRepository.AddRecenzieAsync(recenzieToAdd);
            return _mapper.Map<RecenzieDto>(recenzieAdded);
        }

        public async Task UpdateRecenzieAsync(RecenzieDto recenzie)
        {
            var recenzieToUpdate = _mapper.Map<Recenzie>(recenzie);
            await _recenzieRepository.UpdateRecenzieAsync(recenzieToUpdate);
        }

        public async Task DeleteRecenzieAsync(int id)
        {
            await _recenzieRepository.DeleteRecenzieAsync(id);
        }
    }
}
