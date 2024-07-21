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

        public async Task<Gen> AddGenAsync(Gen gen)
        {
            _context.Genuri.Add(gen);
            await _context.SaveChangesAsync();
            return gen;
        }

        public async Task UpdateGenAsync(Gen gen)
        {
            _context.Entry(gen).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenAsync(int id)
        {
            var gen = await _context.Genuri.FindAsync(id);
            _context.Genuri.Remove(gen);
            await _context.SaveChangesAsync();
        }
    }
}
