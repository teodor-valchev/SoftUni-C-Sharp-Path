using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Core.Contracts
{
    public class Controller : IController
    {
        private EquipmentRepository equipments;
        private List<IGym> gyms;

        public Controller()
        {
            equipments = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            var serchedGym = gyms.Find(x => x.Name == gymName);

            if (athleteType == nameof(Boxer))
            {
                if (serchedGym.GetType().Name == nameof(WeightliftingGym))
                {
                    return "The gym is not appropriate.";
                }
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                if (serchedGym.GetType().Name == nameof(BoxingGym))
                {
                    return "The gym is not appropriate.";
                }
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }
            serchedGym.AddAthlete(athlete);
            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;
            if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
            equipments.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;
            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            gyms.Add(gym);
            return $"Successfully added {gymType}.";

        }

        public string EquipmentWeight(string gymName)
        {
            var serchedGym = gyms.Find(x => x.Name == gymName);

            return $"The total weight of the equipment in the gym {gymName} is {serchedGym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var desiredEquipment = equipments.FindByType(equipmentType);
            var desiredGym = gyms.Find(x => x.Name == gymName);
            if (desiredEquipment == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}");
            }
            desiredGym.AddEquipment(desiredEquipment);
            equipments.Remove(desiredEquipment); // potentialBug
            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var serchedGym = gyms.Find(x => x.Name == gymName);
            serchedGym.Exercise();
            return $"Exercise athletes: {serchedGym.Athletes.Count}.";
        }
    }
}
