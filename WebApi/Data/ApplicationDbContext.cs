using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
           public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int lastIndex = 0;
            var contacts = new List<Contact>()
            {
                new Contact() { Id=++lastIndex, Name = "Tituana", Lastname = "Le tahipouet", BirthDate = new DateTime(1982, 10, 8), Gender = "male" },
                new Contact() { Id=++lastIndex, Name = "Sylvie", Lastname = "Dalaloca", BirthDate = new DateTime(2002, 1, 1), Gender = "female" },
            };

            modelBuilder.Entity<Contact>().HasData(contacts);

        }
    }
}
