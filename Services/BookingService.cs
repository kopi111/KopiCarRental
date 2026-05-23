using System.Collections.Concurrent;
using KopiCarRental.Domain;

namespace KopiCarRental.Services;

public class BookingService : IBookingService
{
    private readonly ICarCatalog catalog;
    private readonly ConcurrentDictionary<string, Booking> bookings = new();

    public BookingService(ICarCatalog catalog)
    {
        this.catalog = catalog;
    }

    public Booking Reserve(BookingRequest request)
    {
        Car car = catalog.FindById(request.CarId);
        Booking booking = new(
            GenerateReference(),
            car,
            request.CustomerName,
            request.CustomerEmail,
            request.PickUpDate,
            request.ReturnDate);

        bookings[booking.Reference] = booking;
        return booking;
    }

    public Booking FindByReference(string reference)
    {
        if (bookings.TryGetValue(reference, out Booking? booking))
        {
            return booking;
        }

        throw new BookingNotFoundException(reference);
    }

    private static string GenerateReference()
    {
        return $"KOPI-{Guid.NewGuid().ToString("N")[..6].ToUpperInvariant()}";
    }
}
