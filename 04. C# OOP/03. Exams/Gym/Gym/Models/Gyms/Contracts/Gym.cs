using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms.Contracts
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                name = value;
            }

        }

        public int Capacity { get; }

        public double EquipmentWeight => equipments.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => equipments.AsReadOnly();

        public ICollection<IAthlete> Athletes => athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == athletes.Count)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment) => equipments.Add(equipment);


        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {GetType().Name}:");
            if (athletes.Any())
            {
                var listOfAthletes = Athletes.Select(x => x.FullName).ToList();
                sb.AppendLine($"Athletes: {string.Join(", ", listOfAthletes)}");
            }
            else
            {
                sb.AppendLine("No athletes");
            }
            sb.AppendLine($"Equipment total count: {equipments.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();

        }

        public bool RemoveAthlete(IAthlete athlete) => athletes.Remove(athlete);

    }
}
