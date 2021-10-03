using System;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private int horsePower;
        private double cubicCapacity;
        private double pressure;


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
        public Car(string make, string model, int year, double fuelQuanity, double fuelConsumption)
         : this(make, model, year)
        {
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuanity;
        }

        public Car(string make, string model, int year, double fuelQuanity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuanity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;

        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

    }
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;
        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
    }
    public class Tire
    {
        private int year;
        private double pressure;

        public Tire(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }
        public int Year { get; set; }
        public double Pressure { get; set; }
    }

    public class StartUp
    {

        public static void Main(string[] args)
        {
       
            var tires = new Tire[4]
                {
                    new Tire(1,2.5),
                    new Tire(1,2.1),
                    new Tire(1,0.5),
                    new Tire(1,2.3),
                };

            Engine engine = new Engine(560, 6300);

            Car car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);
         
           
        }
    }
}
