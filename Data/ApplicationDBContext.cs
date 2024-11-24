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
            //Property Configuration
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(15);

            modelBuilder.Entity<Car>()
                .Property(c => c.PricePerDay)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .HasMaxLength(5);

            modelBuilder.Entity<Reservation>()
                .Property(res => res.Amount)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Payment>()
               .Property(p => p.PaymentAmount)
               .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Reservation>()
               .Property(r => r.Status)
               .HasConversion<int>(); // Ensure EF maps the enum to an INT

            //Relationship between the model

            //User -> Reservation (One-to-Many)
            modelBuilder.Entity<Reservation>()
                .HasOne(res => res.user)
                .WithMany(u => u.reservations)
                .HasForeignKey(res => res.UserId);

            //User -> Admin (One-to-One)
            //modelBuilder.Entity<Admin>()
            //    .HasOne(a => a.User)
            //    .WithOne(u => u.admin);

            //User -> Review (One-to-Many)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.user)
                .WithMany(u => u.reviews)
                .HasForeignKey(r => r.UserId);

            //Car -> Reservation (One-to-Many)
            modelBuilder.Entity<Reservation>()
                .HasOne(res => res.car)
                .WithMany(c => c.reservations)
                .HasForeignKey(res => res.CarId);

            ////Car -> Location (Many-to-One)
            modelBuilder.Entity<Location>()
                .HasMany(l => l.cars)
                .WithOne(c => c.location)
                .HasForeignKey(c => c.LocationId);

            //Car -> Review (One-to-Many)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.car)
                .WithMany(c => c.reviews)
                .HasForeignKey(r => r.CarId);

            //Reservation -> Payment (One-to-Many)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.reservation)
                .WithMany(res => res.payments)
                .HasForeignKey(p => p.ReservationId);

            //Adding data
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, FirstName = "Zahabiya", LastName = "Kapadia", Email = "zahabiya@gmail.com", Password = "z123", PhoneNumber = "9128347653", roleType = "Admin" },
                new User() { UserId = 2, FirstName = "Tanya", LastName = "Patel", Email = "tanya@gmail.com", Password = "t123", PhoneNumber = "9827342651", roleType = "User" }
                );

            DateTime today = DateTime.Today;
            DateTime dateOnly = today.Date;

            modelBuilder.Entity<Car>().HasData(
                new Car() { CarId = 1, Make = "Honda", Model = "Honda City", year = 2020, Colour = "White", LicensePlate = "MP09CP7235", PricePerDay = 3000, Description = "5 Seater Car", AvailableStatus = true, AvailableDate = dateOnly, LocationId = 2 },
                new Car() { CarId = 2, Make = "Honda", Model = "Honda Amaze", year = 2018, Colour = "Red", LicensePlate = "MH50PS2184", PricePerDay = 3200, Description = "5 Seater Car", AvailableStatus = true, AvailableDate = dateOnly.AddDays(1), LocationId = 1 }
                );

            modelBuilder.Entity<Location>().HasData(
                new Location() { LocationId = 1, Address = "123,Honda Showroom", City = "Mumbai", State = "Maharshtra", Country = "India", ZipCode = "411912" },
                new Location() { LocationId = 2, Address = "711,Honda Showroom", City = "Indore", State = "Madhya Pradesh", Country = "India", ZipCode = "452014" }
                );
            //base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var configSection = configBuilder.GetSection("ConnectionStrings");
            var conn = configSection["DBConnStr"];

            optionsBuilder.UseSqlServer(conn);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}
