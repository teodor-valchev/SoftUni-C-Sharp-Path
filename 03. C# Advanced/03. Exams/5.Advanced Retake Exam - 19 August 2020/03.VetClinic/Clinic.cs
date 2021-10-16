using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = data.Find(p => p.Name == name);

            if (pet!=null)
            {
                data.Remove(pet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.Where(n => n.Name == name).Where(o => o.Owner == owner).FirstOrDefault();

            if (pet!=null)
            {
                return pet;
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            Pet oldestPet = data.OrderByDescending(x => x.Age).FirstOrDefault();

            if (oldestPet!=null)
            {

                return oldestPet;
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
