using Microsoft.EntityFrameworkCore;
using ServerApi.Data;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;

namespace ServerApi.Repositories
{
    public class TropeRepository : ITropeRepository
    {
        private readonly AppDbContext _context;

        public TropeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trope>> GetAllTropeuriAsync()
        {
           return await _context.Tropeuri.ToListAsync();
        }

        public async Task<Trope> GetTropeByIdAsync(int id)
        {
            return await _context.Tropeuri.FindAsync(id);
        }

        public async Task<Trope> AddTropeAsync(Trope trope)
        {
            _context.Tropeuri.Add(trope);
            await _context.SaveChangesAsync();
            return trope;
        }

        public async Task UpdateTropeAsync(Trope trope)
        {
            _context.Entry(trope).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTropeAsync(int id)
        {
            var trope = await _context.Tropeuri.FindAsync(id);
            _context.Tropeuri.Remove(trope);
            await _context.SaveChangesAsync();
        }
    }
}
