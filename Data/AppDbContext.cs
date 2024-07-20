using Microsoft.EntityFrameworkCore;
using ServerApi.Models;
namespace ServerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Recenzie> Recenzii { get; set; }
        public DbSet<Gen> Genuri { get; set; }
        public DbSet<Trope> Tropeuri { get; set; }
        public DbSet<Carte> Carti { get; set; } 
        public DbSet<User> Users { get; set; }
        
    
    }
}
