using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BikeComp.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BikeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfService = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BikeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BikeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "BikeName", "BikeType", "DateOfService", "Manufacturer" },
                values: new object[,]
                {
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "V10", "Downhill", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Santa Cruz" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Hightower CC", "Trail", new DateTimeOffset(new DateTime(2024, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Santa Cruz" },
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), "Mega", "Enduro", new DateTimeOffset(new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Nukeproof" },
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), "Status 160", "Super Enduro", new DateTimeOffset(new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Specialized" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "Firebird 429", "Downcountry", new DateTimeOffset(new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Pivot" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "StuntJumper Carbon Expert", "Trail", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Specialized" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Fuel Ex 8.9", "Enduro", new DateTimeOffset(new DateTime(2023, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Trek" }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Id", "BikeId", "ComponentName", "Description", "Manufacturer", "ManufacturerId", "ServiceDate" },
                values: new object[,]
                {
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Rear shock", "Fox Float DPS 130mm", "Fox", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Suspension Fork", "Fox Float 34 Performance Elite 140mm", "Fox", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Wheelset", "Roval 30mm Wheelset", "Specialized", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Brakes", "SRAM Guide RSC Brakeset", "SRAM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_BikeId",
                table: "Components",
                column: "BikeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Bikes");
        }
    }
}
