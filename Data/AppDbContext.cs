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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Gen>().HasData(
                new { Id = 1, Nume = "Thriller" },
                new { Id = 2, Nume = "Romance" },
                new { Id = 3, Nume = "Drama" },
                new { Id = 4, Nume = "Politist" }
            );
            modelBuilder.Entity<Trope>().HasData(
                new { Id = 1, Nume = "enemies to lovers" },
                new { Id = 2, Nume = "so many lies" },
                new { Id = 3, Nume = "twist ending" },
                new { Id = 4, Nume = "undercover mission" }
            );

        }

    }
}
