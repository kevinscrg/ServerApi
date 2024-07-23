using AutoMapper;
using ServerApi.Dtos.CarteDtos;
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

        public async Task<CarteDto> AddCarteAsync(CreateCarteDto carte)
        {
            var carteToAdd = _mapper.Map<Carte>(carte);
            var carteAdded = await _carteRepository.AddCarteAsync(carteToAdd);
           
            await _carteRepository.AddGenuriToCarteAsync(carteAdded.Id, carte.GenuriId);
            
            await _carteRepository.AddTropeuriToCarteAsync(carteAdded.Id, carte.TropeuriId);
           
            var finalCarte = await _carteRepository.GetCarteByIdAsync(carteAdded.Id);
            return _mapper.Map<CarteDto>(finalCarte);
        }

        public async Task UpdateCarteAsync(UpdateCarteDto carte)
        {

            var carteToUpdate = await _carteRepository.GetCarteByIdAsync(carte.Id);

            if(carteToUpdate == null) throw new System.Exception("Carte not found");

            carteToUpdate.Genuri.Clear();
            carteToUpdate.Tropeuri.Clear();

            carteToUpdate.Descriere = carte.Descriere;
            carteToUpdate.Link = carte.Link;
            carteToUpdate.Pret = carte.Pret;

            await _carteRepository.UpdateCarteAsync(carteToUpdate);

            await _carteRepository.AddGenuriToCarteAsync(carte.Id, carte.GenuriId);
            await _carteRepository.AddTropeuriToCarteAsync(carte.Id, carte.TropeuriId);


        }

        public async Task DeleteCarteAsync(int id)
        {
            await _carteRepository.DeleteCarteAsync(id);
        }
    }
}
