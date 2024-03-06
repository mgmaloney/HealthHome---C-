using Microsoft.EntityFrameworkCore;
using HealthHome.Models;

namespace HealthHome
{
    public class HealthHomeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public HealthHomeDbContext(DbContextOptions<HealthHomeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User
                {
                    Id = 1,
                    FirstName = "Gregory",
                    LastName = "House",
                    Email = "house@malpractice.com",
                    Address = "12 Princeton Ln, Plainsboro, NJ 08512",
                    PhoneNumber = "555-555-5555",
                    Gender = "he/him",
                    Sex = "male",
                    Provider = true,
                    Credential = "MD",
                },
                new User
                {
                    Id = 3,
                    FirstName = "June",
                    LastName = "Bloom",
                    Email = "junejune22@gmail.com",
                    Address = "125 Witchy Lane",
                }
            });

           
        }

    }
}