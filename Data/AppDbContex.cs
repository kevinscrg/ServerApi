using Microsoft.EntityFrameworkCore;
using ServerApi.Models;
namespace ServerApi.Data
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options) { }

        public DbSet<Carte> Carti { get; set; } 
        public DbSet<Recenzie> Recenzii { get; set; }
        public DbSet<User> Useri { get; set; }
    
    }
}
