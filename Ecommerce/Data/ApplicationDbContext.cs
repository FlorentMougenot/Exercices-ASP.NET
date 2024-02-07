using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ecommerce> Ecommerces { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int lastIndex = 0;
            var ecommerce = new List<Ecommerce>()
            {
                new Ecommerce() { Id=++lastIndex, Name = "Lait Meumeu", Description = "(モーモーミルク en japonais). Un lait très nourrissant. Restaure 100 PV d'un Pokémon.", Price = 500, Quantity = 10, Category = "Objet de soin" },
                new Ecommerce() { Id=++lastIndex, Name = "Pokeball", Description = "Un objet semblable à une capsule, qui capture les Pokémon sauvages. Il suffit pour cela de le lancer comme une balle.", Price = 200, Quantity = 20, Category = "Ball" },
                new Ecommerce() { Id=++lastIndex, Name = "Superball", Description = "Version améliorée de la pokeball.", Price = 600, Quantity = 10, Category = "Ball" },
            };

            modelBuilder.Entity<Ecommerce>().HasData(ecommerces);

        }
    }
}

