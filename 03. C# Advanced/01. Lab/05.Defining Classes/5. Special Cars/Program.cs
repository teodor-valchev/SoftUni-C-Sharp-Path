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

        public static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command!= "No more tires")
            {
                string[] tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                
                for (int i = 0; i < tokens.Length; i++)
                {
                    int year = int.Parse(tokens[0]);
                    double pressure = double.Parse(tokens[1]);
                    Tire tire = new Tire(year, pressure);
                }


                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Engines done")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tokens.Length; i++)
                {
                    int horsePower = int.Parse(tokens[0]);
                    double cubicCapacity = double.Parse(tokens[1]);
                    Engine engine = new Engine(horsePower, cubicCapacity);
                }


                command = Console.ReadLine();
            }
        }
    }
}
