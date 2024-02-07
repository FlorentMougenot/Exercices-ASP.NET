using ToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        //protected ApplicationDbContext() // : base() // facultatif sur le ctor sans params
        //{
        //}

        // dans le cas où le ConnectionString est extérieur au dbContext
        // il sera passé à la construction du ApplicationDbContext => besoin des options pour le configurer
        // exemple :  dans une application ASP.NET core, il est préférable d'avoir le connectionString dans appsettings.json
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        // dans le cas où on utilise OnConfiguring pour le ConnectionString
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\AspMvc;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int lastIndex = 0;
            var todos = new List<Todo>()
            {
                new Todo() { Id=++lastIndex, Title = "Rangement", Description = "Préparer la venue de belle-maman" },
                new Todo() { Id=++lastIndex, Title = "Promenade", Description = "Promener Médor et faire attention au chien de la voisine" },
            };

            modelBuilder.Entity<Todo>().HasData(todos);

        }
    }
}