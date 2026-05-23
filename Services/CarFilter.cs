using KopiCarRental.Domain;

namespace KopiCarRental.Services;

public record CarFilter(
    string SearchTerm = "",
    CarCategory? Category = null,
    decimal? MaxPricePerDay = null)
{
    public static CarFilter None => new();

    public bool Matches(Car car)
    {
        return MatchesSearchTerm(car)
            && MatchesCategory(car)
            && MatchesPrice(car);
    }

    private bool MatchesSearchTerm(Car car)
    {
        if (string.IsNullOrWhiteSpace(SearchTerm))
        {
            return true;
        }

        return car.DisplayName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase);
    }

    private bool MatchesCategory(Car car)
    {
        return Category is null || car.Category == Category;
    }

    private bool MatchesPrice(Car car)
    {
        return MaxPricePerDay is null || car.PricePerDay <= MaxPricePerDay;
    }
}
