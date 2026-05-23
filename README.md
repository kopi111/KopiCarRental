# KOPI Car Rental

A car rental browse-and-book web app built with **.NET 8 Blazor Web App** (interactive
server rendering). Browse a fleet, filter it, view a car, and reserve it — getting an
instant booking reference you can look up later.

## Run

```bash
dotnet run
```

Then open the URL printed in the console (e.g. `http://localhost:5199`).

## Features

- **Home** (`/`) — hero, featured cars, how-it-works.
- **Browse** (`/cars`) — live search + category + price filters.
- **Car detail + booking** (`/cars/{id}`) — specs, live price quote, validated booking form.
- **Confirmation** (`/confirmation/{reference}`) — booking summary and reference.
- **Lookup** (`/lookup`) — find an existing booking by reference.

## Structure

```
Domain/        Car, Booking, CarCategory (immutable records / enum)
Services/      ICarCatalog + CarCatalog (seed data), IBookingService + BookingService,
               CarFilter, BookingRequest, typed not-found exceptions
Components/
  Layout/      NavMenu (top bar), MainLayout (+ footer)
  Shared/      CarCard reusable component
  Pages/       Home, Cars, CarDetails, Confirmation, Lookup
```

Data is in-memory (seeded fleet + bookings held for the app lifetime). No database yet —
the service interfaces are the seam to add one (EF Core, etc.) without touching the UI.
