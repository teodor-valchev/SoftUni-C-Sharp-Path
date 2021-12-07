using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core.Contracts
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private int eggcounter;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }
            bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var serchedBunny = bunnies.FindByName(bunnyName);
            if (serchedBunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }
            var dye = new Dye(power);
            serchedBunny.AddDye(dye);
            return $"Successfully added dye with power {dye.Power} to bunny {serchedBunny.Name}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            var serchedEggName = eggs.FindByName(eggName);
            var bunniesAboveFiftyEnergy = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();

            if (bunniesAboveFiftyEnergy == null)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }
            var workshop = new Workshop();

            foreach (var bunnie in bunniesAboveFiftyEnergy)
            {
                workshop.Color(serchedEggName, bunnie);
                if (bunnie.Energy == 0)
                {
                    bunnies.Remove(bunnie);
                }
            }
            if (serchedEggName.IsDone())
            {
                eggcounter++;
                return $"Egg {eggName} is done.";
            }
            else
            {
                return $"Egg {eggName} is not done.";
            }

        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{eggcounter} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunnie in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunnie.Name}");
                sb.AppendLine($"Energy: {bunnie.Energy}");
                sb.AppendLine($"Dyes: {bunnie.Dyes.Where(x => x.Power > 0).Count()} not finished");
            }
            return sb.ToString().TrimEnd();

        }
    }
}
