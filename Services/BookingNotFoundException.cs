namespace KopiCarRental.Services;

public class BookingNotFoundException : Exception
{
    public BookingNotFoundException(string reference)
        : base($"No booking exists with reference {reference}.")
    {
    }
}
