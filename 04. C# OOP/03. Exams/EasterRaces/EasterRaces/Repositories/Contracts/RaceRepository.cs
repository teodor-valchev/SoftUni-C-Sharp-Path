using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Contracts
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }
        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll() => races.AsReadOnly();


        public IRace GetByName(string name) => races.FirstOrDefault(x => x.Name == name);


        public bool Remove(IRace model) => races.Remove(model);


    }
}
