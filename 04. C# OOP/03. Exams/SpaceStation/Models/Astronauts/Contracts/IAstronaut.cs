namespace SpaceStation.Models.Astronauts.Contracts
{
    using Bags;
    using Bags.Contracts;

    public interface IAstronaut
    {
        string Name { get; }

        double Oxygen { get; }

        bool CanBreath { get; }

        Backpack Bag { get; }

        void Breath();
    }
}