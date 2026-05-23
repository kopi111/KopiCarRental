using KopiCarRental.Data;
using KopiCarRental.Domain;
using Microsoft.EntityFrameworkCore;

namespace KopiCarRental.Services;

public class CarCatalog : ICarCatalog
{
    private readonly RentalDbContext context;

    public CarCatalog(RentalDbContext context)
    {
        this.context = context;
    }

    public IReadOnlyList<Car> FindMatching(CarFilter filter)
    {
        return AllCars().Where(filter.Matches).ToList();
    }

    public IReadOnlyList<Car> FeaturedCars(int count)
    {
        return context.Cars.AsNoTracking()
            .Where(car => car.IsAvailable)
            .OrderBy(car => car.Id)
            .Take(count)
            .ToList();
    }

    public Car FindById(int carId)
    {
        Car? match = context.Cars.AsNoTracking().FirstOrDefault(car => car.Id == carId);
        if (match is null)
        {
            throw new CarNotFoundException(carId);
        }

        return match;
    }

    private IEnumerable<Car> AllCars()
    {
        return context.Cars.AsNoTracking().OrderBy(car => car.Id).ToList();
    }
}
