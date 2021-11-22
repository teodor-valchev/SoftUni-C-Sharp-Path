using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories.Contracts
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets = new List<IPlanet>();
        public IReadOnlyCollection<IPlanet> Models => planets.AsReadOnly();

        public void Add(IPlanet planet)
        {
            planets.Add(planet);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = planets.Where(x => x.Name == name).FirstOrDefault();
            if (planet != null)
            {
                return planet;
            }
            return null;
        }

        public bool Remove(IPlanet planet) => planets.Remove(planet);
   
    }
}
