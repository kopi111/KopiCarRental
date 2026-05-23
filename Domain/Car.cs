namespace KopiCarRental.Domain;

public record Car(
    int Id,
    string Make,
    string Model,
    int Year,
    CarCategory Category,
    int SeatCount,
    string Transmission,
    string FuelType,
    decimal PricePerDay,
    string ImageUrl,
    bool IsAvailable)
{
    public string DisplayName => $"{Make} {Model}";
}
