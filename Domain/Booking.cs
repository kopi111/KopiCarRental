using System.ComponentModel.DataAnnotations.Schema;

namespace KopiCarRental.Domain;

public class Booking
{
    public int Id { get; set; }
    public string Reference { get; set; } = "";
    public int CarId { get; set; }
    public Car Car { get; set; } = default!;
    public string CustomerName { get; set; } = "";
    public string CustomerEmail { get; set; } = "";
    public DateOnly PickUpDate { get; set; }
    public DateOnly ReturnDate { get; set; }
    public DateTime CreatedAtUtc { get; set; }

    [NotMapped]
    public int RentalDays => Math.Max(1, ReturnDate.DayNumber - PickUpDate.DayNumber);

    [NotMapped]
    public decimal TotalPrice => RentalDays * Car.PricePerDay;
}
