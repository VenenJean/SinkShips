using System.Linq;
using SinkShips.ConsoleApp.Utility;

namespace SinkShips.ConsoleApp.Models
{
    public class Radar
    {
        private Prompter Prompter { get; }

        public Radar(Prompter prompter)
        {
            Prompter = prompter;
        }

        public (int xAxisStartPoint, int yAxisStartPoint) GetCoordinate()
        {
            int xAxis = GetXAxis();
            int yAxis = GetYAxis();

            return (xAxis, yAxis);
        }

        private int GetXAxis()
        {
            int xAxis = Prompter.GetAlphabeticOrNumericKey("X-Axis location (0-9): ", true).KeyChar;
            return xAxis - '0';
        }

        private int GetYAxis()
        {
            char yAxis = '!';
            char[] acceptableInput = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
            char[] acceptableInput2 = new char[]
                { 'A', 'B', 'C', 'D', 'E', 'F', 'H', 'I', 'J', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

            while (!acceptableInput.Contains(yAxis))
            {
                yAxis = Prompter.GetAlphabeticOrNumericKey("Y-Axis location (A-F): ").KeyChar;
            }

            return yAxis - 'a';
        }
    }
}