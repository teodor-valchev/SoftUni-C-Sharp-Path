using System;

namespace CarManufacturer
{
    public class StartUp
    {

        public class Car
        {
            private string make;
            private string model;
            private int year;
            private double fuelQuantity;
            private double fuelConsumption;


            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double FuelQuanity { get; set; }
            public double FuelConsumption { get; set; }
            public string WhoAmI()
            {
                return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuanity:F2}L";
            }
            public void Drive(double distance)
            {
                var consmuption = distance * (FuelConsumption / 100.0);

                if (consmuption <= fuelQuantity)
                {
                    FuelQuanity -= consmuption;
                }
                else
                {
                    Console.WriteLine("Not enough fuel to perform this trip!");
                }
            }

        }

        public static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuanity = 200;
            car.FuelConsumption = 200;
            car.Drive(2000);
            Console.WriteLine(car.WhoAmI());


        }
    }
}
