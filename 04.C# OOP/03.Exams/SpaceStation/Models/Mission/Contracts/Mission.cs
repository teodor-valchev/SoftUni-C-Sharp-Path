using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission.Contracts
{
   public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astr in astronauts)
            {
                if (astr.CanBreath==false)
                {
                    break;
                }
                var planetsItems = planet.Items.ToList();

                foreach (var item in planetsItems)
                {
                    astr.Bag.Items.Add(item);
                    astr.Breath();
                    planetsItems.Remove(item);

                    if (astr.CanBreath==false)
                    {
                        continue;
                    }
                }
              
            }
              
            
        }
    }
}
