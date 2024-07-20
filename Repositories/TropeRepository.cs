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
    }
}
