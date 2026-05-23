using System.ComponentModel.DataAnnotations.Schema;

namespace KopiCarRental.Domain;

public class Car
{
    public int Id { get; set; }
    public string Make { get; set; } = "";
    public string Model { get; set; } = "";
    public int Year { get; set; }
    public CarCategory Category { get; set; }
    public int SeatCount { get; set; }
    public string Transmission { get; set; } = "";
    public string FuelType { get; set; } = "";
    public decimal PricePerDay { get; set; }
    public string ImageUrl { get; set; } = "";
    public bool IsAvailable { get; set; }

    [NotMapped]
    public string DisplayName => $"{Make} {Model}";
}
