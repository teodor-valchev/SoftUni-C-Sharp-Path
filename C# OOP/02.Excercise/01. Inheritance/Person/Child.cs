using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child:Person
    {
        public Child(string name,int age)
            :base(name,age)
        {
            if (age<15 && age>0)
            {
                base.Age = age;
            }
            else
            {
                base.Age = 0;
            }
           
        }
    }
}
