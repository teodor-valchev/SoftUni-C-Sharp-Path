using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;


namespace SpaceStation.Core.Contracts
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
          
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if ( type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type==nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException($"Astronaut type doesn't exists!");
            }
            astronauts.Add(astronaut);

            return $"Successfully added {type}: {astronautName}!";

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planets.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var explorePlanet = planets.FindByName(planetName);



            return "s";

        }

        public string Report()
        {
            return "s";
        }

        public string RetireAstronaut(string astronautName)
        {
            var retireAstronaut = astronauts.FindByName(astronautName);

            if (retireAstronaut==null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            astronauts.Remove(retireAstronaut);

            return $"Astronaut {astronautName} was retired!";


        }
    }
}
