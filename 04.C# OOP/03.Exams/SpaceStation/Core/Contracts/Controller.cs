using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SpaceStation.Core.Contracts
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanetsCount = 0;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();

        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
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
            var allAstrounauts = astronauts.Models.Where(x => x.Oxygen > 60).ToList();

            if (allAstrounauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            var mission = new Mission();
            mission.Explore(explorePlanet, allAstrounauts);
            exploredPlanetsCount++;
            return $"Planet: {planetName} was explored! Exploration finished with {allAstrounauts.Where(x => x.Oxygen == 0).Count()} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine("Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var retireAstronaut = astronauts.FindByName(astronautName);
            if (retireAstronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            astronauts.Remove(retireAstronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
