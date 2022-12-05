using System;

namespace BoxOfT
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            box.Add("papp");
            box.Add("ada");
            box.Add("adas");
          
        }
    }
}
