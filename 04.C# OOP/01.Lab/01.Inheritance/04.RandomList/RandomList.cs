using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomRandomList
{
    public class RandomList:List<string>
    {
        private Random rnd;
        public void RemoveRandomElement()
        {
           this.rnd = new Random();
            var randomNumber = rnd.Next(0, Count);
            RemoveAt(randomNumber);
        }

        public string ReturnRandomElement(List<string> list)
        {
            var randomNumber = rnd.Next(0, Count);
            return list.ElementAt(randomNumber);
            
        }
    }
}
