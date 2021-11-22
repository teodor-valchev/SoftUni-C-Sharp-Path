using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;


namespace SpaceStation.Models.Astronauts.Contracts
{
    public abstract class Astronaut : IAstronaut,IBag
    {
        private string name;
        private double oxygen;
        private List<string> items;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            items = new List<string>();
        }

        public string Name
        {
            get
            {
                return name;
            }


            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                name = value;
            }
        }

        public virtual double Oxygen
        {
            get
            {
                return oxygen;
            }


            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                oxygen = value;
            }
        }

        public bool CanBreath => Oxygen > 0;
        public ICollection<string> Items => items;



     public Backpack  Bag {get;}

        public virtual void Breath()
        {
            if (CanBreath)
            {
                Oxygen -= 10;
            }        
            
        }
    }
}
