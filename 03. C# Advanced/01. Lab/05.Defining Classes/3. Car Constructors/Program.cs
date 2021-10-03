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

            public Car()
            {
                Make = "VW";
                Model = "Golf";
                Year = 2025;
                FuelQuantity = 200;
                FuelConsumption = 10;
            }
            public Car(string make, string model, int year)
                : this()
            {
                Make = make;
                Model = model;
                Year = year;
            }
            public Car(string make, string model, int year,double fuelQuanity,double fuelConsumption)
             : this(make,model,year)
            {
                FuelConsumption = fuelConsumption;
                FuelQuantity = fuelQuanity;
            }


            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double FuelQuantity { get; set; }
            public double FuelConsumption { get; set; }
            
        }

        public static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());


            Car carOne = new Car();
            Car carTwo = new Car(make, model, year);
            Car carThree = new Car(make,model,year, fuelQuantity, fuelConsumption);
        }
    }
}
