using ExerciceOrnithorynque.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciceOrnithorynque.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<Platypus> PlatypusOriginal { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog = Playtypus;User ID=SA;Password=192Panda;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }
    }
}
