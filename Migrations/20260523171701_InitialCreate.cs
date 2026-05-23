using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KopiCarRental.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    SeatCount = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FuelType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PricePerDay = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Reference = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerEmail = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PickUpDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReturnDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Category", "FuelType", "ImageUrl", "IsAvailable", "Make", "Model", "PricePerDay", "SeatCount", "Transmission", "Year" },
                values: new object[,]
                {
                    { 1, 0, "Petrol", "https://images.unsplash.com/photo-1623869675781-80aa31012a5a?w=900&q=80", true, "Toyota", "Corolla", 45m, 5, "Automatic", 2023 },
                    { 2, 1, "Petrol", "https://images.unsplash.com/photo-1606152421802-db97b9c7a11b?w=900&q=80", true, "Honda", "Civic", 58m, 5, "Automatic", 2022 },
                    { 3, 4, "Electric", "https://images.unsplash.com/photo-1560958089-b8a1929cea89?w=900&q=80", true, "Tesla", "Model 3", 95m, 5, "Automatic", 2024 },
                    { 4, 2, "Diesel", "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=900&q=80", true, "BMW", "X5", 130m, 7, "Automatic", 2023 },
                    { 5, 3, "Petrol", "https://images.unsplash.com/photo-1617814076367-b759c7d7e738?w=900&q=80", true, "Mercedes-Benz", "E-Class", 165m, 5, "Automatic", 2023 },
                    { 6, 2, "Petrol", "https://images.unsplash.com/photo-1606016159991-dfe4f2746ad5?w=900&q=80", true, "Jeep", "Wrangler", 110m, 5, "Manual", 2022 },
                    { 7, 3, "Petrol", "https://images.unsplash.com/photo-1584345604476-8ec5e12e42dd?w=900&q=80", true, "Ford", "Mustang", 150m, 4, "Manual", 2023 },
                    { 8, 4, "Electric", "https://images.unsplash.com/photo-1593941707882-a5bba14938c7?w=900&q=80", false, "Nissan", "Leaf", 70m, 5, "Automatic", 2023 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarId",
                table: "Bookings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Reference",
                table: "Bookings",
                column: "Reference",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
