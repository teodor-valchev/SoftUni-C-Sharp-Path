using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participents;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)

        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participents = new List<Car>();
        }
        public int Count => Participents.Count;
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public void Add(Car car)
        {
            if (Capacity > Participents.Count && car.HorsePower <= MaxHorsePower)
            {
                if (Participents.All(p=>p.LicensePlate!=car.LicensePlate))
                {
                    Participents.Add(car);
                }
                
            }
        }
        public bool Remove(string licensePlate)
        {
            Car car = Participents.Where(c => c.LicensePlate == licensePlate).FirstOrDefault();
            if (car != null)
            {
                Participents.Remove(car);
                return true;
            }

            return false;
        }
        public string FindParticipant(string licensePlate)
        {
            Car car = Participents.Where(c => c.LicensePlate == licensePlate).FirstOrDefault();
            if (car != null)
            {
                return $"{car.LicensePlate}";
            }
            return null;
        }
        public string GetMostPowerfulCar()
        {
            int maxHorsePower = 0;
            foreach (var particepent in Participents)
            {
                if (particepent.HorsePower > maxHorsePower)
                {
                    maxHorsePower = particepent.HorsePower;
                }
            }
            if (maxHorsePower != 0)
            {
                
                foreach (var participent in Participents.Where(p => p.HorsePower == maxHorsePower))
                {
                    return participent.ToString();
              
                }              
            }
            return null;
        }
        public string Report()
        {
            return $"Race: {Name} - Type: {Type} (Laps: {Laps})" +Environment.NewLine+ string.Join(Environment.NewLine,Participents);        
        }
    }
}
