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
                new User() { Id = 1,FirstName = "John", LastName = "Doe", UserName = "johndoe", EmailId = "johndoe@example.com", Password = "password123" },
                new User() { Id =2,  FirstName = "Jane", LastName = "Doe", UserName = "janedoe", EmailId = "janedoe@example.com", Password = "password456" }
            );

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
