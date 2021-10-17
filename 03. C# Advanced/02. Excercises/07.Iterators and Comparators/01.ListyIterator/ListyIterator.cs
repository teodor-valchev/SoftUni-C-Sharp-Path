using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
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
            if (collecion.Count==0)
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
      
    }
}
