using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Tire
    {
        public Tire(int year,double pressuare)
        {
            Year = year;
            Pressuare = pressuare;

        }
        public int Year { get; set; }
        public double Pressuare { get; set; }
    }
}
