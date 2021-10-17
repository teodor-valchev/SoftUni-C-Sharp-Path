using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class Stack<T>:IEnumerable<T>
    {
        private List<T> collection;

        public Stack()
        {
            collection = new List<T>();
        }


        public void Push(params T[] data)
        {
            foreach (var el in data)
            {
                if (collection.Count == 0)
                {
                    collection.Insert(collection.Count, el);
                }
                else
                {
                    collection.Insert(collection.Count - 1, el);
                }

            }

        }
        public T Pop()
        {


            if (collection.Any(element => collection.Count == 0)) 
            {
                throw new ArgumentException("No elements");
             
            }
            T element = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = collection.Count - 1; index >= 0; index--)
            {
                yield return collection[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
