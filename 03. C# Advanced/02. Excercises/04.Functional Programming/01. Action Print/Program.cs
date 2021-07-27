using System; 
using System.Collections.Generic;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
        
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<List<string>> print = names => Console.WriteLine(string.Join(Environment.NewLine,names));
            print(names);
           
        }
    }
}
