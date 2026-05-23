using KopiCarRental.Domain;

namespace KopiCarRental.Services;

public class CarCatalog : ICarCatalog
{
    private readonly IReadOnlyList<Car> cars = SeedCars();

    public IReadOnlyList<Car> FindMatching(CarFilter filter)
    {
        return cars.Where(filter.Matches).ToList();
    }

    public IReadOnlyList<Car> FeaturedCars(int count)
    {
        return cars.Where(car => car.IsAvailable).Take(count).ToList();
    }

    public Car FindById(int carId)
    {
        Car? match = cars.FirstOrDefault(car => car.Id == carId);
        if (match is null)
        {
            throw new CarNotFoundException(carId);
        }

        return match;
    }

    private static IReadOnlyList<Car> SeedCars()
    {
        return new List<Car>
        {
            new(1, "Toyota", "Corolla", 2023, CarCategory.Economy, 5, "Automatic", "Petrol", 45m,
                "https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=900&q=80", true),
            new(2, "Honda", "Civic", 2022, CarCategory.Sedan, 5, "Automatic", "Petrol", 58m,
                "https://images.unsplash.com/photo-1606152421802-db97b9c7a11b?w=900&q=80", true),
            new(3, "Tesla", "Model 3", 2024, CarCategory.Electric, 5, "Automatic", "Electric", 95m,
                "https://images.unsplash.com/photo-1560958089-b8a1929cea89?w=900&q=80", true),
            new(4, "BMW", "X5", 2023, CarCategory.Suv, 7, "Automatic", "Diesel", 130m,
                "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=900&q=80", true),
            new(5, "Mercedes-Benz", "E-Class", 2023, CarCategory.Luxury, 5, "Automatic", "Petrol", 165m,
                "https://images.unsplash.com/photo-1617814076367-b759c7d7e738?w=900&q=80", true),
            new(6, "Jeep", "Wrangler", 2022, CarCategory.Suv, 5, "Manual", "Petrol", 110m,
                "https://images.unsplash.com/photo-1606016159991-dfe4f2746ad5?w=900&q=80", true),
            new(7, "Ford", "Mustang", 2023, CarCategory.Luxury, 4, "Manual", "Petrol", 150m,
                "https://images.unsplash.com/photo-1584345604476-8ec5e12e42dd?w=900&q=80", true),
            new(8, "Nissan", "Leaf", 2023, CarCategory.Electric, 5, "Automatic", "Electric", 70m,
                "https://images.unsplash.com/photo-1593941707882-a5bba14938c7?w=900&q=80", false)
        };
    }
}
