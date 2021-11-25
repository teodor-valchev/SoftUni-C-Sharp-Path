using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories.Contracts
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astronauts;
        public IReadOnlyCollection<IAstronaut> Models => astronauts.AsReadOnly();

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }

        public void Add(IAstronaut astronaut)
        {
            astronauts.Add(astronaut);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronaut = astronauts.Where(x => x.Name == name).FirstOrDefault();
            if (astronaut!=null)
            {
                return astronaut;
            }
            return null;
        }

        public bool Remove(IAstronaut astronaut) => astronauts.Remove(astronaut);

    }
}
