using Microsoft.EntityFrameworkCore;
using ServerApi.Data;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;

namespace ServerApi.Repositories
{
    public class GenRepository : IGenRepository
    {
        private AppDbContext _context;

        public GenRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Gen>> GetAllGenuriAsync()
        {
            return await _context.Genuri.ToListAsync();
        }

        public async Task<Gen> GetGenByIdAsync(int id)
        {
            return await _context.Genuri.FindAsync(id);
        }
    }
}
