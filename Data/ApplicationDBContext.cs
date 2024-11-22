using Microsoft.EntityFrameworkCore;
using Login.Model;

namespace Login.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can set up default data, constraints, etc.
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, FirstName = "John", LastName = "Doe", UserName = "johndoe", EmailId = "johndoe@example.com", Password = "password123" },
                new User() { Id = 2, FirstName = "Jane", LastName = "Doe", UserName = "janedoe", EmailId = "janedoe@example.com", Password = "password456" },
                new User() { Id = 3, FirstName = "Michael", LastName = "Smith", UserName = "michaelsmith", EmailId = "michael.smith@example.com", Password = "michael123" },
                new User() { Id = 4, FirstName = "Emily", LastName = "Johnson", UserName = "emilyj", EmailId = "emily.johnson@example.com", Password = "emily2024" },
                new User() { Id = 5, FirstName = "William", LastName = "Brown", UserName = "william_b", EmailId = "william.brown@example.com", Password = "william@321" },
                new User() { Id = 6, FirstName = "Olivia", LastName = "Taylor", UserName = "olivia_t", EmailId = "olivia.taylor@example.com", Password = "olivia@123" },
                new User() { Id = 7, FirstName = "James", LastName = "Martinez", UserName = "james_m", EmailId = "james.martinez@example.com", Password = "james456" },
                new User() { Id = 8, FirstName = "Sophia", LastName = "Davis", UserName = "sophia.d", EmailId = "sophia.davis@example.com", Password = "sophia789" }

            );

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
    }
}
