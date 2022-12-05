using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
   public class Box<T>
    {
        public Box()
        {
            Store = new List<T>();
        }   
        public List<T> Store { get; set; }
        public int Count => Store.Count;
        public T Remove()
        {
            T element = Store[Store.Count - 1];
            Store.RemoveAt(Store.Count - 1); 

            return element;
            
        }
        public void Add(T element)
        {
            Store.Add(element);
        }

        public override string ToString()
        {
            return $"{Store}";
        }
    }
}
