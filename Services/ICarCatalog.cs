using KopiCarRental.Domain;

namespace KopiCarRental.Services;

public interface ICarCatalog
{
    IReadOnlyList<Car> FindMatching(CarFilter filter);

    IReadOnlyList<Car> FeaturedCars(int count);

    Car FindById(int carId);
}
