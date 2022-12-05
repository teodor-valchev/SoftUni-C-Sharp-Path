using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Contracts
{
   public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> drivers;

        public DriverRepository()
        {
            drivers = new List<IDriver>();
        }
        public void Add(IDriver model)
        {
           drivers.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll() => drivers.AsReadOnly();


        public IDriver GetByName(string name) => drivers.FirstOrDefault(x => x.Name == name);


        public bool Remove(IDriver model) => drivers.Remove(model);
      
    }
}
