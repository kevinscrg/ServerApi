using Microsoft.AspNetCore.Identity;
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
                .Include(carte => carte.Recenzii)
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


        public async Task AddGenToCarteAsync(int carteId, int genId)
        {
            var carte = await _context.Carti.FindAsync(carteId);
            var gen = await _context.Genuri.FindAsync(genId);
            if(carte != null && gen != null)
            {
                carte.Genuri.Add(gen);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddGenuriToCarteAsync(int carteId, List<int> genuriId)
        {
            var carte = await _context.Carti.FindAsync(carteId);
            if(carte != null)
            {
                foreach (var genId in genuriId)
                {
                    var gen = await _context.Genuri.FindAsync(genId);
                    if(gen != null)
                    {
                        carte.Genuri.Add(gen);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddTropeToCarteAsync(int carteId, int tropeId)
        {
            var carte = await _context.Carti.FindAsync(carteId);
            var trope = await _context.Tropeuri.FindAsync(tropeId);
            if(carte != null && trope != null)
            {
                carte.Tropeuri.Add(trope);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddTropeuriToCarteAsync(int carteId, List<int> tropeuriId)
        {
            var carte = await _context.Carti.FindAsync(carteId);
            if(carte != null)
            {
                foreach (var tropeId in tropeuriId)
                {
                    var trope = await _context.Tropeuri.FindAsync(tropeId);
                    if(trope != null)
                    {
                        carte.Tropeuri.Add(trope);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteGenFromCarteAsync(int carteId, int genId)
        {
            var carte = await _context.Carti.FindAsync(carteId);
            var gen = await _context.Genuri.FindAsync(genId);
            if(carte != null && gen != null)
            {
                carte.Genuri.Remove(gen);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTropeFromCarteAsync(int carteId, int tropeId)
        {
            var carte = await _context.Carti.FindAsync(carteId);
            var trope = await _context.Tropeuri.FindAsync(tropeId);
            if(carte != null && trope != null)
            {
                carte.Tropeuri.Remove(trope);
                await _context.SaveChangesAsync();
            }
        }

    }
}
