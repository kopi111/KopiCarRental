using KopiCarRental.Domain;

namespace KopiCarRental.Services;

public interface IBookingService
{
    Booking Reserve(BookingRequest request);

    Booking FindByReference(string reference);
}
