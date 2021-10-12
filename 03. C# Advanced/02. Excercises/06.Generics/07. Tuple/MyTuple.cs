using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
   public class MyTuple<T,K>
    {

        public MyTuple(T itemOne,K itemTwo)
        {
            ItemOne = itemOne;
            ItemTwo = itemTwo;
        }
        public T ItemOne { get; set; }
        public K ItemTwo { get; set; }

        public override string ToString()
        {
            return $"{ItemOne} -> {ItemTwo}";

        }

    }
}
