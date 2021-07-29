using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public double FuelQuanity { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            bool isConsumed = (FuelQuanity - distance) * FuelConsumption > 0;
            double consumation =  distance * FuelConsumption;

            if (isConsumed)
            {
                FuelQuanity -= consumation;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuanity:F2}L";
        }

    }


}
