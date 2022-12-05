using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            var aquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();

            if (aquarium.GetType().Name == nameof(FreshwaterAquarium) && fish.GetType().Name != nameof(FreshwaterFish))
            {
                return "Water not suitable.";
            }
            else if (aquarium.GetType().Name == nameof(SaltwaterAquarium) && fish.GetType().Name != nameof(SaltwaterFish))
            {
                return "Water not suitable.";
            }

            aquarium.AddFish(fish);
            return $"Successfully added {fishType} to {aquariumName}.";


        }

        public string CalculateValue(string aquariumName)
        {
            var findAquarium = aquariums.Where(x => x.Name == aquariumName);
            var sumOfAllDecor = findAquarium.Select(x => x.Decorations.Sum(x => x.Price)).ToList();
            var totalSumOFish = findAquarium.Select(x => x.Fish.Sum(x => x.Price));

            decimal total = 0;

            foreach (var decor in sumOfAllDecor)
            {
                total += decor;
            }
            foreach (var item in totalSumOFish)
            {
                total += item;
            }
            return $"The value of Aquarium {aquariumName} is {total}.";
        }

        public string FeedFish(string aquariumName)
        {
            var findAquarium = aquariums.Where(x => x.Name == aquariumName);
            int count = 0;
            foreach (var fish in findAquarium)
            {
                fish.Feed();
                count++;
            }

            return $"Fish fed: {count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var desiredDecor = decorations.FindByType(decorationType);
            var serchedAquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();

            if (desiredDecor == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            serchedAquarium.AddDecoration(desiredDecor);
            decorations.Remove(desiredDecor);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IAquarium aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo() + Environment.NewLine);
            }


            return sb.ToString().TrimEnd();

        }


    }
}
