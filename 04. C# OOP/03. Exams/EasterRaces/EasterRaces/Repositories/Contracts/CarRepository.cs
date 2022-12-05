using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Contracts
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }
        public void Add(ICar model)
        {
            cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll() => cars.AsReadOnly();


        public ICar GetByName(string name) => cars.FirstOrDefault(x => x.Model == name);


        public bool Remove(ICar model) => cars.Remove(model);

    }
}
