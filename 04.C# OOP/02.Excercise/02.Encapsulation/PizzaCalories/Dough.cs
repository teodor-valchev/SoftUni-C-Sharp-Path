using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> doughType = new Dictionary<string, double>()
        {
            {"white",1.5 },
            {"wholegrain",1.0 }
        };
        private Dictionary<string, double> bakingTeachnique = new Dictionary<string, double>()
        {
            {"crispy",0.9 },
            {"chewy",1.1 },
            {"homemade",1.0 }
        };
        private string type;
        private string teachnique;
        private double weight;

        public Dough(string doughType,string baikingTeacnique,int weight)
        {
            DoughType = doughType;
            BeackingTeachnique = baikingTeacnique;
            Weight = weight;
        }
        public string DoughType
        {
            get
            {
                return type;
            }
           private  set
            {
                if (!doughType.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");                  
                }
                type = value;
            }
        }

        public double Calories => (2 * Weight) * doughType[DoughType.ToLower()] * bakingTeachnique[BeackingTeachnique.ToLower()];
         public string BeackingTeachnique
        {
            get
            {
                return teachnique;
            }
            private set
            {
                if (!bakingTeachnique.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");                                                      
                }
                teachnique = value;

            }

        }
        public double Weight {
            get {
                return weight;
            }
            private set 
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
    }
}
