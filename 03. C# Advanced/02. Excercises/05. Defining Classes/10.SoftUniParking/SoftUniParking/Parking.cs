using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public int capacity;
        public List<Car> cars;

        public int Count => cars.Count;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (cars.Count > capacity)
            {
                return "Parking is full!";
            }
            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string RegistrationNumber)
        {
            if (cars.Any(x => x.RegistrationNumber == RegistrationNumber))
            {
                cars.RemoveAll(x => x.RegistrationNumber == RegistrationNumber);
                return $"Successfully removed {RegistrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public string GetCar(string RegistrationNumber)
        {
            Car car = cars.Find(x => x.RegistrationNumber == RegistrationNumber);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {car.Make}");
            sb.AppendLine($"Model: {car.Model}");
            sb.AppendLine($"HorsePower: {car.HorsePower}");
            sb.AppendLine($"RegistrationNumber: {car.RegistrationNumber}");
            return sb.ToString().TrimEnd();
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            this.cars = cars.Where(c => !RegistrationNumbers.Contains(c.RegistrationNumber))
                .ToList();
        }
    }
}
