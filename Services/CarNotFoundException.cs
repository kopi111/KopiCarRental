namespace KopiCarRental.Services;

public class CarNotFoundException : Exception
{
    public CarNotFoundException(int carId)
        : base($"No car exists with id {carId}.")
    {
    }
}
