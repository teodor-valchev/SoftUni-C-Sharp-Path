using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
   public class Parking
    {
        private List<Car> cars;


        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            cars = new List<Car>();
        }

        public string Type { get; set; }
        public int  Capacity { get; set; }
        public int Count => cars.Count;

        public void Add(Car car)
        {
            if (Capacity!=cars.Count)
            {
                cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var serchedCar = cars.Find(x => x.Manufacturer == manufacturer && x.Model == model);
            if (serchedCar==null)
            {
                return false;
            }
            cars.Remove(serchedCar);
            return true;
        }

        public Car GetLatestCar()
        {
            if (!cars.Any())
            {
                return null;
            }
            var latestCar = cars.OrderByDescending(x => x.Year).FirstOrDefault();
            return latestCar;
        }
        public string  GetStatistics()
        {
            var sb = new StringBuilder();
            Console.WriteLine($"The cars are parked in {Type}:");
            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString()); 
            }
            return sb.ToString().TrimEnd();
        }
        public Car GetCar(string manufacturer, string model)
        {
            var serchedCar = cars.Find(x => x.Manufacturer == manufacturer && x.Model == model);

            if (serchedCar==null)
            {
                return null;
            }
            return serchedCar;
        }

    }
}
