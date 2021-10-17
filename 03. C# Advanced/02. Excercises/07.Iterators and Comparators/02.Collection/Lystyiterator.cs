using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T>:IEnumerable<T>
    {

        private List<T> collecion;
        private int currIndex;

        public ListyIterator(params T[] data)
        {
            collecion = new List<T>(data);
            currIndex = 0;
        }

        public bool HasNext()
        {
            return currIndex < collecion.Count - 1;
        }
        public void Print()
        {
            if (collecion.Count == 0)
            {
                throw new ArgumentException("InvalidOperation!");
            }
            Console.WriteLine(collecion[currIndex]);
        }

        public bool Move()
        {
            bool canMove = HasNext();

            if (canMove)
            {
                currIndex++;
                return true;
            }
            return false;
        }

        public void PrintAll()
        {
            foreach (var element in collecion)
            {
                Console.Write($"{element}" +" ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < collecion.Count; index++)
            {
                yield return collecion[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
