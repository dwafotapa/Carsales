using System;
using System.Linq;
using Carsales.Core.Domain;

namespace Carsales.Web
{
    public static class DbInitializer
    {
        public static void Initialize(CarsalesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cars.Any()) return;

            var cars = new Car[]
            {
                new Car
                {
                    Make = "Audi",
                    Model = "A3",
                    Year = 2015,
                    PriceType = PriceType.EGC,
                    EgcPrice = 30000,
                    DapPrice = null,
                    Email = "carsales@example.com",
                    ContactName = null,
                    Phone = null,
                    DealerABN = "44162162162",
                    Comments = @"Brand new Audi A3.
Only 10000kms and unmarked.
Cleaned every fortnight.
Quality second-hand purchase."
                },
                new Car
                {
                    Make = "Audi",
                    Model = "A5",
                    Year = 2016,
                    PriceType = PriceType.DAP,
                    EgcPrice = null,
                    DapPrice = 50000,
                    Email = "bobby.sixkiller@example.com",
                    ContactName = "Bobby Sixkiller",
                    Phone = "0279279279",
                    DealerABN = null,
                    Comments = @"This beautiful car is stylish and contemporary in design, the 2010 Audi A5 cannot be missed.

Stay protected with these features:
- Rear parking sensors
- Driver airbag
- ABS brakes
- Parking assist graphical display
- Brake assist
- Side airbags
- Passenger airbag"
                },
                new Car
                {
                    Make = "Ford",
                    Model = "Mustang",
                    Year = 1969,
                    PriceType = PriceType.POA,
                    EgcPrice = null,
                    DapPrice = null,
                    Email = "jack.bauer@example.com",
                    ContactName = "Jack Bauer",
                    Phone = "0435435435",
                    DealerABN = null,
                    Comments = "Classic. Just do it."
                }
            };
            
            context.AddRange(cars);
            context.SaveChanges();
        }
    }
}