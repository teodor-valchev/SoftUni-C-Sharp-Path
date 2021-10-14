using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel { get => ingredients.Sum(x => x.Alcohol);}


        public void Add(Ingredient ingredient)
        {
            if (!ingredients.Contains(ingredient) && ingredients.Count < Capacity && ingredient.Quantity < MaxAlcoholLevel)
            {
                ingredients.Add(ingredient);
            }
        }
        public bool Remove(string ingredient)
        {
            Ingredient serchedIngridienr = ingredients.Where(x => x.Name == ingredient).FirstOrDefault();
            if (serchedIngridienr != null)
            {
                ingredients.Remove(serchedIngridienr);
                return true;
            }
            return false;
        }

        public string FindIngredient(string name)
        {
            Ingredient ingridient = ingredients.Where(x => x.Name == name).FirstOrDefault();

            if (ingridient != null)
            {
                return ingridient.Name;
            }
            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            int max = ingredients.Max(x => x.Alcohol);
            Ingredient ingridentMax = ingredients.Find(x => x.Alcohol == max);

            return ingridentMax;

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in ingredients)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
