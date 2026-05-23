using KopiCarRental.Components;
using KopiCarRental.Data;
using KopiCarRental.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

string connectionString = builder.Configuration.GetConnectionString("RentalDatabase")
    ?? throw new InvalidOperationException("Connection string 'RentalDatabase' is not configured.");

builder.Services.AddDbContext<RentalDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 45))));

builder.Services.AddScoped<ICarCatalog, CarCatalog>();
builder.Services.AddScoped<IBookingService, BookingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
