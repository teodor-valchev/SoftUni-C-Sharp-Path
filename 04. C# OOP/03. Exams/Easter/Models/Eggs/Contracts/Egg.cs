using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs.Contracts
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }
                name = value;
            }

        }

        public int EnergyRequired
        {
            get => energyRequired;
            private set
            {
                if (value<0)
                {
                    value = 0;
                }
                energyRequired = value;
            }

        }


        public void GetColored()
        {
            EnergyRequired -= 10;
            if (EnergyRequired<0)
            {
                return;
            }
        }

        public bool IsDone() => EnergyRequired == 0;
       
    }
}
