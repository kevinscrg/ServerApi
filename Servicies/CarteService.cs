using AutoMapper;
using ServerApi.Dtos;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;
using ServerApi.Servicies.Interfaces;

namespace ServerApi.Servicies
{
    public class CarteService : ICarteService
    {
        private readonly ICarteRepository _carteRepository;
        private readonly IMapper _mapper;
       
        public CarteService(ICarteRepository carteRepository, IMapper mapper)
        {
            _carteRepository = carteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarteDto>> GetAllCartiAsync()
        {
            var carti = await _carteRepository.GetAllCartiAsync();
            return _mapper.Map<IEnumerable<CarteDto>>(carti);
        }

        public async Task<CarteDto> GetCarteByIdAsync(int id)
        {
            var carte = await _carteRepository.GetCarteByIdAsync(id);
            return _mapper.Map<CarteDto>(carte);
        }

        public async Task<CarteDto> AddCarteAsync(CarteDto carte)
        {
            var carteToAdd = _mapper.Map<Carte>(carte);
            var carteAdded = await _carteRepository.AddCarteAsync(carteToAdd);
            return _mapper.Map<CarteDto>(carteAdded);
        }

        public async Task UpdateCarteAsync(CarteDto carte)
        {
            var carteToUpdate = _mapper.Map<Carte>(carte);
            await _carteRepository.UpdateCarteAsync(carteToUpdate);
        }

        public async Task DeleteCarteAsync(int id)
        {
            await _carteRepository.DeleteCarteAsync(id);
        }
    }
}
