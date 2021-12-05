using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;
        public CarRepository()
        {
            cars = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => cars.AsReadOnly();

        public void Add(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            cars.Add(car);
        }

        public ICar FindBy(string property)
        {
            var serchedCar = cars.Find(x => x.VIN == property);

            if (serchedCar==null)
            {
                return null;
            }
            return serchedCar;
        }

        public bool Remove(ICar car) => cars.Remove(car);
       
    }
}
