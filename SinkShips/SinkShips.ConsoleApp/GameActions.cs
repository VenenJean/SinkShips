using System;
using System.Threading;
using SinkShips.ConsoleApp.Models;
using SinkShips.ConsoleApp.Utility;

namespace SinkShips.ConsoleApp
{
    public class GameActions
    {
        public void SwitchBoard(Player player, Prompter prompter)
        {
            Board.Render(player.PlacementBoard.Surface, player.Name);
            prompter.GetAlphabeticOrNumericKey("Press any key...");
            Board.Render(player.AttackBoard.Surface, player.Name);
        }

        public bool PerformAttackAndRepeat(Radar radar, Player currentPlayer, Player opponentPlayer)
        {
            (int xAxisStartPoint, int yAxisStartPoint) coordinates = radar.GetCoordinate();
            int xCoordinate = coordinates.xAxisStartPoint;
            int yCoordinate = coordinates.yAxisStartPoint;

            string[,] playerOnTurnAttackBoard = currentPlayer.AttackBoard.Surface;
            string[,] opponentPlayerBoard = opponentPlayer.PlacementBoard.Surface;

            bool keepAttacking = false;

            if (opponentPlayerBoard[yCoordinate, xCoordinate] == "*")
            {
                playerOnTurnAttackBoard[yCoordinate, xCoordinate] = opponentPlayerBoard[yCoordinate, xCoordinate] = "X";
                Board.Render(playerOnTurnAttackBoard, currentPlayer.Name);
                Console.WriteLine("Ship hit!");
                keepAttacking = true;
            }

            playerOnTurnAttackBoard[yCoordinate, xCoordinate] = opponentPlayerBoard[yCoordinate, xCoordinate] = "o";
            Board.Render(playerOnTurnAttackBoard, currentPlayer.Name);
            Console.WriteLine("Ship missed!");
            Thread.Sleep(2000);
            return keepAttacking;
        }

        public void EndGame()
        {
            Console.WriteLine("\nGame stopped!\n");
            Environment.Exit(0);
        }
    }
}