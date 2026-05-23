namespace KopiCarRental.Domain;

public record Booking(
    string Reference,
    Car Car,
    string CustomerName,
    string CustomerEmail,
    DateOnly PickUpDate,
    DateOnly ReturnDate)
{
    public int RentalDays => Math.Max(1, ReturnDate.DayNumber - PickUpDate.DayNumber);

    public decimal TotalPrice => RentalDays * Car.PricePerDay;
}
