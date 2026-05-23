using System.ComponentModel.DataAnnotations;
using KopiCarRental.Domain;

namespace KopiCarRental.Services;

public class BookingRequest
{
    public int CarId { get; set; }

    [Required(ErrorMessage = "Please tell us your name.")]
    public string CustomerName { get; set; } = "";

    [Required(ErrorMessage = "Please provide an email address.")]
    [EmailAddress(ErrorMessage = "That email address does not look valid.")]
    public string CustomerEmail { get; set; } = "";

    [Required(ErrorMessage = "Choose a pick-up date.")]
    public DateOnly PickUpDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    [Required(ErrorMessage = "Choose a return date.")]
    public DateOnly ReturnDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddDays(3));
}
