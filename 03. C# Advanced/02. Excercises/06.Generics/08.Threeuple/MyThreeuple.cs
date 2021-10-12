using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
   public class MyThreeuple<T,K,M>
    {

        public MyThreeuple(T itemOne, K itemTwo,M itemThree)
        {
            ItemOne = itemOne;
            ItemTwo = itemTwo;
            ItemThree = itemThree;
        }
        public T ItemOne { get; set; }
        public K ItemTwo { get; set; }
        public M ItemThree { get; set; }

        public override string ToString()
        {
            return $"{ItemOne} -> {ItemTwo} -> {ItemThree}";

        }
    }
}
