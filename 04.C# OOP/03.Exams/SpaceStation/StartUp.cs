namespace SpaceStation
{
    using Core;
    using Core.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
         
            IEngine engine = new Engine();
            engine.Run();
           
        }
    }
}