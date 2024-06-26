using System;

namespace SinkShips.ConsoleApp.Utility
{
    public static class ColorPrinter
    {
        public static void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void PrintColoredState(string shipState, string displayFormat)
        {
            switch (shipState)
            {
                case "0":
                    Print(displayFormat, ConsoleColor.Blue);
                    break;
                case "X":
                    Print(displayFormat, ConsoleColor.Red);
                    break;
                case "o":
                    Print(displayFormat, ConsoleColor.Yellow);
                    break;
                case "*":
                    Print(displayFormat, ConsoleColor.Cyan);
                    break;
                default:
                    throw new Exception("Some wrong ship state was entered!");
            }
            
        }
    }
}