namespace SinkShips.ConsoleApp.Models
{
    public class Player
    {
        public string Name { get; }
        public Board PlacementBoard { get; } = new();
        public Board AttackBoard { get; } = new();

        public Player(string name)
        {
            Name = name;
        }

        public Ship[] Ships { get; } = new Ship[]
        {
            new Ship("Carrier", 5),
            new Ship("Battle Ship", 4),
            new Ship("Cruiser", 3),
            new Ship("Submarine", 3),
            new Ship("Destroyer", 2)
        };
    }
}