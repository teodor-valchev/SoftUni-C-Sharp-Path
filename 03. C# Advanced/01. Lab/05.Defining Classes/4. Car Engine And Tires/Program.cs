using System;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1,2),
                new Tire(1,2.9),
                new Tire(1,2.54),
                new Tire(1,25),
            };
            var engine = new Engine(233, 4444.4);

            Car Lambo = new Car("Lamborgini", "Aventador", 2088, 343, 3, tires, engine);
            Console.WriteLine($"Horse power: "+ Lambo.Engine.HorsePower);

            foreach (var tire in Lambo.Tires)
            {
                Console.WriteLine($"{tire.Year} -- {tire.Pressuare}");
            }
        }
    }
}
