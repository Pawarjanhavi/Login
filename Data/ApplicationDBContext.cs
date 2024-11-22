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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> UserDB { get; set; }
    }
}
