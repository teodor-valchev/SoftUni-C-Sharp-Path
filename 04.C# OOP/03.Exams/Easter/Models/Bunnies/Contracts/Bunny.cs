using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies.Contracts
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        protected List<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes = new List<IDye>();
        }
        

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bunny name cannot be null or empty.");
                }
                name = value;
            }

        }

        public int Energy
        {
            get => energy;
            protected set
            {
                if (value<0)
                {
                    value = 0;
                }
                energy = value;
            }

        }

        public ICollection<IDye> Dyes => dyes;

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }

        public virtual  void Work()
        {
            Energy -= 10;
            if (Energy<0)
            {
                Energy = 0;
            }
        }
      
    }
}
