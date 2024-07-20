using AutoMapper;
using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;
using ServerApi.Servicies.Interfaces;

namespace ServerApi.Servicies
{
    public class CarteService : ICarteService
    {
        private readonly ICarteRepository _carteRepository;
        private readonly IGenRepository _genRepository;
        private readonly ITropeRepository _tropeRepository;
        private readonly IMapper _mapper;
       
        public CarteService(ICarteRepository carteRepository,IGenRepository genRepository, ITropeRepository tropeRepository, IMapper mapper)
        {
            _carteRepository = carteRepository;
            _genRepository = genRepository;
            _tropeRepository = tropeRepository;
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

        public async Task<CarteDto> AddCarteAsync(CreateCarteDto carte)
        {
            var carteToAdd = _mapper.Map<Carte>(carte);
            foreach (var genId in carte.GenuriId)
            {
                var gen = await _genRepository.GetGenByIdAsync(genId);
                carteToAdd.Genuri.Add(gen);
            }
            foreach (var tropeId in carte.TropeuriId)
            {
                var trope = await _tropeRepository.GetTropeByIdAsync(tropeId);
                carteToAdd.Tropeuri.Add(trope);
            }
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
