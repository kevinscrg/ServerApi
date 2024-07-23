using AutoMapper;
using ServerApi.Dtos.CreateDtos;
using ServerApi.Dtos.ReceznieDtos;
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

        public async Task<RecenzieDto> AddRecenzieAsync(CreateRecenzieDto recenzie)
        {
            var recenzieToAdd = _mapper.Map<Recenzie>(recenzie);
            var recenzieAdded = await _recenzieRepository.AddRecenzieAsync(recenzieToAdd);

            await _recenzieRepository.AddRecenzieToCarteAsync(recenzieToAdd.Id, recenzie.CarteId);
            await _recenzieRepository.AddRecenzieToUserAsync(recenzieToAdd.Id, recenzie.UserId);
            await _recenzieRepository.UpdateRecenzieStatusAsync(recenzieToAdd.Id, StatusRecenzie.InAsteptare.ToString());

            return _mapper.Map<RecenzieDto>(recenzieAdded);
        }

        public async Task UpdateRecenzieAsync(UpdateRecenzieDto recenzie)
        {
            var recenzieToUpdate = await _recenzieRepository.GetRecenzieByIdAsync(recenzie.Id);
            if(recenzieToUpdate == null)             {
                throw new Exception("Recenzie not found");
            }
            recenzieToUpdate.Text = recenzie.Text;
            recenzieToUpdate.Rating = recenzie.Rating;

            await _recenzieRepository.UpdateRecenzieAsync(recenzieToUpdate);
        }

        public async Task DeleteRecenzieAsync(int id)
        {
            await _recenzieRepository.DeleteRecenzieAsync(id);
        }
    }
}
