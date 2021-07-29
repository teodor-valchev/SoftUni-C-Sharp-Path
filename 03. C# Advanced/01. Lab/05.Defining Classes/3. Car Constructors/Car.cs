using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuanity = 200;
            FuelConsumption = 10;

        }
        public Car(string make, string model, int year)
            : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public Car(string make, string model, int year,double fuelquantuty,double fuelConsumption)
            : this(make, model, year)
        {
            
            FuelConsumption = fuelConsumption;
            FuelQuanity = fuelquantuty;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public double FuelQuanity { get; set; }
        public double FuelConsumption { get; set; }
    }
}
