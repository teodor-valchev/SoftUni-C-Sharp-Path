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
            var planetItems = planet.Items;
            foreach (var astr in astronauts)
            {
                if (astr.CanBreath == false)
                {
                    break;
                }

                while (planetItems.Count > 0)
                {
                    var item = planetItems.FirstOrDefault();
                    if (item == null)
                    {
                        return;
                    }
                    astr.Bag.Items.Add(item);
                    astr.Breath();
                    if (astr.CanBreath == false)
                    {
                        break;
                    }
                    planetItems.Remove(item);
                }


            }


        }
    }
}
