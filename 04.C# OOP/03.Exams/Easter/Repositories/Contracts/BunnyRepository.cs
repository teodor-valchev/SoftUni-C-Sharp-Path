using Easter.Models.Bunnies.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Repositories.Contracts
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies;

        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => bunnies.AsReadOnly();

        public void Add(IBunny Bunny) => bunnies.Add(Bunny);
        

        public IBunny FindByName(string name)
        {
            var serchedBunny = bunnies.Find(x => x.Name == name);

            if (serchedBunny==null)
            {
                return null;
            }
            return serchedBunny;
        }

        public bool Remove(IBunny Bunny) => bunnies.Remove(Bunny);
        
    }
}
