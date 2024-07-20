using Microsoft.EntityFrameworkCore;
using ServerApi.Data;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;

namespace ServerApi.Repositories
{
    public class CarteRepository : ICarteRepository
    {
        private AppDbContext _context;

        public CarteRepository(AppDbContext context)
        {
            _context = context;
        }

         public async Task<IEnumerable<Carte>> GetAllCartiAsync()
        {
            return await _context.Carti
                .Include(carte => carte.Genuri) 
                .Include(carte => carte.Tropeuri)
                .AsSplitQuery()
                .ToListAsync();
       
        }

        public async Task<Carte> GetCarteByIdAsync(int id)
        {
            return await _context.Carti.FindAsync(id);
        }


        public async Task<Carte> AddCarteAsync(Carte carte)
        {
            _context.Carti.Add(carte);
            await _context.SaveChangesAsync();
            return carte;
        }

        public async Task DeleteCarteAsync(int id)
        {
            var carte = await _context.Carti.FindAsync(id);
            if(carte != null)
            {
                _context.Carti.Remove(carte);
                await _context.SaveChangesAsync();
            }
        }

       
        public async Task UpdateCarteAsync(Carte carte)
        {
           _context.Entry(carte).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
