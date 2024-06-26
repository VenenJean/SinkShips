using System;
using SinkShips.ConsoleApp.Utility;

namespace SinkShips.ConsoleApp.Models
{
    public class Board
    {
        private const int Rows = 10;
        private const int Columns = 10;
        public string[,] Surface { get; set; } = new string[Rows, Columns];

        public Board()
        {
            ResetBoard(Surface);
        }

        public void ResetBoard(string[,] gameBoard)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    gameBoard[i, j] = "0";
                }
            }
        }

        private static void PrintXAxis()
        {
            Console.Write("    ");
            for (int col = -1; col < 9; col++)
            {
                ColorPrinter.Print($"{col + 1} ", ConsoleColor.DarkGreen);
            }

            Console.WriteLine();
        }

        public static void Render(string[,] gameBoard, string playerName)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            Console.WriteLine($"---Your move: {playerName}---");
            PrintXAxis();

            for (int i = 0; i < Rows; i++)
            {
                // A = 65; 65 = A
                ColorPrinter.Print($"{(char)('A' + i)}", ConsoleColor.DarkGreen);
                Console.Write(" [ ");
                for (int j = 0; j < Columns; j++)
                {
                    string shipState = gameBoard[i, j];
                    string displayFormat = $"{shipState} ";
                    ColorPrinter.PrintColoredState(shipState, displayFormat);
                }

                Console.WriteLine("]");
            }
        }
    }
}