using BikeComp.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BikeComp.API.DbContexts
{
    public class BikeCompContext : DbContext
    {
        public BikeCompContext(DbContextOptions<BikeCompContext> options)
           : base(options)
        {
        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Components> Components { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Bike>().HasData(
                new Bike()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    BikeName = "StuntJumper Carbon Expert",
                    Manufacturer = "Specialized",
                    DateOfService = new DateTime(2025, 1, 01),
                    BikeType = "Trail"
                },
                new Bike()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    BikeName = "Fuel Ex 8.9",
                    Manufacturer = "Trek",
                    DateOfService = new DateTime(2023, 11, 21),
                    BikeType = "Enduro"
                },
                new Bike()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    BikeName = "Hightower CC",
                    Manufacturer = "Santa Cruz",
                    DateOfService = new DateTime(2024, 12, 16),
                    BikeType = "Trail"
                },
                new Bike()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    BikeName = "V10",
                    Manufacturer = "Santa Cruz",
                    DateOfService = new DateTime(2025, 1, 1),
                    BikeType = "Downhill"
                },
                new Bike()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    BikeName = "Firebird 429",
                    Manufacturer = "Pivot",
                    DateOfService = new DateTime(2022, 11, 23),
                    BikeType = "Downcountry"
                },
                new Bike()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    BikeName = "Mega",
                    Manufacturer = "Nukeproof",
                    DateOfService = new DateTime(2022, 4, 5),
                    BikeType = "Enduro"
                },
                new Bike()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    BikeName = "Status 160",
                    Manufacturer = "Specialized",
                    DateOfService = new DateTime(2024, 10, 11),
                    BikeType = "Super Enduro"
                }
                );

            modelBuilder.Entity<Components>().HasData(
               new Components
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   BikeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Description = "Fox Float 34 Performance Elite 140mm",
                   ServiceDate = new DateTime(2024,11,10),
                   ComponentName = "Suspension Fork",
                   Manufacturer = "Fox"
               },
               new Components
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   BikeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Description = "SRAM Guide RSC Brakeset",
                   ServiceDate = new DateTime(2024,11,10),
                   ComponentName = "Brakes",
                   Manufacturer = "SRAM"
               },
               new Components
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   BikeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Description = "Roval 30mm Wheelset",
                   ServiceDate = new DateTime(2024,11,10),
                   ComponentName = "Wheelset",
                   Manufacturer = "Specialized"
               },
               new Components
               {
                   Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                   BikeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Description = "Fox Float DPS 130mm",
                   ServiceDate = new DateTime(2024,11,10),
                   ComponentName = "Rear shock",
                   Manufacturer = "Fox"
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
