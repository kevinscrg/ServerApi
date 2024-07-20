using ServerApi.Models;
using ServerApi.Repositories.Interfaces;

namespace ServerApi.Repositories
{
    public class CarteRepository : ICarteRepository
    {
        public Task<Carte> AddCarteAsync(Carte carte)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCarteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Carte>> GetAllCartiAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Carte> GetCarteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCarteAsync(Carte carte)
        {
            throw new NotImplementedException();
        }
    }
}
