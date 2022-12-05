using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Generic_Box_of_String
{
    public class Box<T>
        where T:IComparable
    {
        private List<T> boxes;
        public Box()
        {
            boxes = new List<T>();
        }

        public void Add(T element)
        {
            boxes.Add(element);
        }
   
       public int Counter(T element)
        {
            int count = 0;

            foreach (var item in boxes)
            {
                if (item.CompareTo(element)>0)
                {
                    count++;
                }
            }
            return count;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);
            }
            string element = Console.ReadLine();
            int result = box.Counter(element);
            Console.WriteLine(result);
        }
    }
}
