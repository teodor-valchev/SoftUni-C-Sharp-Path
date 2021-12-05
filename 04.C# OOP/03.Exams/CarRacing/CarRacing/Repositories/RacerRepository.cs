using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racers;

        public RacerRepository()
        {
            racers = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => racers.AsReadOnly();

        public void Add(IRacer racer)
        {
            if (racer == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }
            racers.Add(racer);
        }

        public IRacer FindBy(string property)
        {
            var serchedPlayer = racers.Find(r => r.Username == property);
            if (serchedPlayer == null)
            {
                return null;
            }
            return serchedPlayer;
        }

        public bool Remove(IRacer racer) => racers.Remove(racer);
      
    }
}
