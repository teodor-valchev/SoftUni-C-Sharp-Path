using System;

namespace CustomRandomList
{
  public class StartUp 
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("boi");
            list.Add("bos");
            list.Add("bddda");
            list.Add("ada");
            list.Add("dawd");
            
            Console.WriteLine(list.ReturnRandomElement(list));
        }
    }
}
