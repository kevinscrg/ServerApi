using Microsoft.EntityFrameworkCore;
using ServerApi.Data;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;

namespace ServerApi.Repositories
{
    public class RecenzieRepository : IRecenzieRepository
    {
        private AppDbContext _context;

        public RecenzieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recenzie>> GetAllRecenziiAsync()
        {
            return await _context.Recenzii.ToListAsync();
        }

        public async Task<Recenzie> GetRecenzieByIdAsync(int id)
        {
            return await _context.Recenzii.FindAsync(id);
        }

        public async Task<Recenzie> AddRecenzieAsync(Recenzie recenzie)
        {
            _context.Recenzii.Add(recenzie);
            await _context.SaveChangesAsync();
            return recenzie;
        }

        public async Task DeleteRecenzieAsync(int id)
        {
            var recenzie = await _context.Recenzii.FindAsync(id);
            if(recenzie != null)
            {
                _context.Recenzii.Remove(recenzie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateRecenzieAsync(Recenzie recenzie)
        {
            _context.Entry(recenzie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddRecenzieToCarteAsync(int recenzieId, int carteId)
        {
            var recenzie = await _context.Recenzii.FindAsync(recenzieId);
            var carte = await _context.Carti.FindAsync(carteId);
            if(recenzie != null && carte != null)
            {
                carte.Recenzii.Add(recenzie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddRecenzieToUserAsync(int recenzieId, int userId)
        {
            var recenzie = await _context.Recenzii.FindAsync(recenzieId);
            var user = await _context.Users.FindAsync(userId);
            if(recenzie != null && user != null)
            {
                user.Recenzii.Add(recenzie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateRecenzieStatusAsync(int recenzieId, string status)
        {
            var recenzie = await _context.Recenzii.FindAsync(recenzieId);
            if(recenzie != null)
            {
                recenzie.Status = status;
                await _context.SaveChangesAsync();
            }
        }
    }
}
