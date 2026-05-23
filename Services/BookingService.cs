using KopiCarRental.Data;
using KopiCarRental.Domain;
using Microsoft.EntityFrameworkCore;

namespace KopiCarRental.Services;

public class BookingService : IBookingService
{
    private readonly RentalDbContext context;

    public BookingService(RentalDbContext context)
    {
        this.context = context;
    }

    public Booking Reserve(BookingRequest request)
    {
        Car car = FindCar(request.CarId);
        Booking booking = new()
        {
            Reference = GenerateReference(),
            CarId = car.Id,
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            PickUpDate = request.PickUpDate,
            ReturnDate = request.ReturnDate,
            CreatedAtUtc = DateTime.UtcNow
        };

        context.Bookings.Add(booking);
        context.SaveChanges();

        booking.Car = car;
        return booking;
    }

    public Booking FindByReference(string reference)
    {
        Booking? booking = context.Bookings.AsNoTracking()
            .Include(b => b.Car)
            .FirstOrDefault(b => b.Reference == reference);

        if (booking is null)
        {
            throw new BookingNotFoundException(reference);
        }

        return booking;
    }

    private Car FindCar(int carId)
    {
        Car? car = context.Cars.FirstOrDefault(c => c.Id == carId);
        if (car is null)
        {
            throw new CarNotFoundException(carId);
        }

        return car;
    }

    private static string GenerateReference()
    {
        return $"KOPI-{Guid.NewGuid().ToString("N")[..6].ToUpperInvariant()}";
    }
}
