namespace SinkShips.ConsoleApp.Models
{
    public class Ship
    {
        public string Name { get; }
        public int Length { get; }

        public Ship(string name, int length)
        {
            Name = name;
            Length = length;
        }
    }
}