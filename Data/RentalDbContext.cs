using KopiCarRental.Domain;
using Microsoft.EntityFrameworkCore;

namespace KopiCarRental.Data;

public class RentalDbContext : DbContext
{
    public RentalDbContext(DbContextOptions<RentalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureCar(modelBuilder);
        ConfigureBooking(modelBuilder);
        SeedFleet(modelBuilder);
    }

    private static void ConfigureCar(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(car =>
        {
            car.HasKey(c => c.Id);
            car.Property(c => c.Make).HasMaxLength(60).IsRequired();
            car.Property(c => c.Model).HasMaxLength(60).IsRequired();
            car.Property(c => c.Transmission).HasMaxLength(20).IsRequired();
            car.Property(c => c.FuelType).HasMaxLength(20).IsRequired();
            car.Property(c => c.ImageUrl).HasMaxLength(500).IsRequired();
            car.Property(c => c.Category).HasConversion<int>();
            car.Property(c => c.PricePerDay).HasColumnType("decimal(10,2)");
        });
    }

    private static void ConfigureBooking(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(booking =>
        {
            booking.HasKey(b => b.Id);
            booking.Property(b => b.Reference).HasMaxLength(16).IsRequired();
            booking.HasIndex(b => b.Reference).IsUnique();
            booking.Property(b => b.CustomerName).HasMaxLength(120).IsRequired();
            booking.Property(b => b.CustomerEmail).HasMaxLength(160).IsRequired();
            booking.Property(b => b.PickUpDate).HasColumnType("date");
            booking.Property(b => b.ReturnDate).HasColumnType("date");
            booking.Property(b => b.CreatedAtUtc).HasColumnType("datetime");

            booking.HasOne(b => b.Car)
                .WithMany()
                .HasForeignKey(b => b.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void SeedFleet(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2023, Category = CarCategory.Economy, SeatCount = 5, Transmission = "Automatic", FuelType = "Petrol", PricePerDay = 45m, ImageUrl = "https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=900&q=80", IsAvailable = true },
            new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2022, Category = CarCategory.Sedan, SeatCount = 5, Transmission = "Automatic", FuelType = "Petrol", PricePerDay = 58m, ImageUrl = "https://images.unsplash.com/photo-1606152421802-db97b9c7a11b?w=900&q=80", IsAvailable = true },
            new Car { Id = 3, Make = "Tesla", Model = "Model 3", Year = 2024, Category = CarCategory.Electric, SeatCount = 5, Transmission = "Automatic", FuelType = "Electric", PricePerDay = 95m, ImageUrl = "https://images.unsplash.com/photo-1560958089-b8a1929cea89?w=900&q=80", IsAvailable = true },
            new Car { Id = 4, Make = "BMW", Model = "X5", Year = 2023, Category = CarCategory.Suv, SeatCount = 7, Transmission = "Automatic", FuelType = "Diesel", PricePerDay = 130m, ImageUrl = "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=900&q=80", IsAvailable = true },
            new Car { Id = 5, Make = "Mercedes-Benz", Model = "E-Class", Year = 2023, Category = CarCategory.Luxury, SeatCount = 5, Transmission = "Automatic", FuelType = "Petrol", PricePerDay = 165m, ImageUrl = "https://images.unsplash.com/photo-1617814076367-b759c7d7e738?w=900&q=80", IsAvailable = true },
            new Car { Id = 6, Make = "Jeep", Model = "Wrangler", Year = 2022, Category = CarCategory.Suv, SeatCount = 5, Transmission = "Manual", FuelType = "Petrol", PricePerDay = 110m, ImageUrl = "https://images.unsplash.com/photo-1606016159991-dfe4f2746ad5?w=900&q=80", IsAvailable = true },
            new Car { Id = 7, Make = "Ford", Model = "Mustang", Year = 2023, Category = CarCategory.Luxury, SeatCount = 4, Transmission = "Manual", FuelType = "Petrol", PricePerDay = 150m, ImageUrl = "https://images.unsplash.com/photo-1584345604476-8ec5e12e42dd?w=900&q=80", IsAvailable = true },
            new Car { Id = 8, Make = "Nissan", Model = "Leaf", Year = 2023, Category = CarCategory.Electric, SeatCount = 5, Transmission = "Automatic", FuelType = "Electric", PricePerDay = 70m, ImageUrl = "https://images.unsplash.com/photo-1593941707882-a5bba14938c7?w=900&q=80", IsAvailable = false });
    }
}
