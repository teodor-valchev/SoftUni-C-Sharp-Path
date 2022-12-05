using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Generic_Box_of_String
{
    public class Box<T>
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in boxes)
            {
                sb.AppendLine($"System.Int32: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Add(input);


            }
            Console.WriteLine(box);
        }
    }
}
