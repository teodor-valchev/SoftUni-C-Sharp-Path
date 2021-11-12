using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }


        public void Draw()
        {
            Console.WriteLine(new string('*', Width));

            for (int i = 0; i < Height-1; ++i)
            {
               
            }

            Console.WriteLine(new string('*', Width));

        }
    }
}
