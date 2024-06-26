using SinkShips.ConsoleApp.Models;
using SinkShips.ConsoleApp.Utility;
using System;

namespace SinkShips.ConsoleApp
{
    internal abstract class Program
    {
        private static readonly bool IsUpdated = true;

        private static void Main()
        {
            Prompter prompter = new Prompter();
            Radar radar = new Radar(prompter);
            GameActions gameActions = new GameActions();

            Initializer initializer = new Initializer(prompter, radar);
            initializer.PlaceShipsAutomatically();
            (Player player1, Player player2) players = initializer.GetPlayers();


            bool isPlayer1Turn = true;
            bool isWrongInput = false;

            while (true)
            {
                if (!IsUpdated) continue;

                Player currentPlayer = isPlayer1Turn ? players.player1 : players.player2;
                Player opponentPlayer = isPlayer1Turn ? players.player2 : players.player1;

                Board.Render(currentPlayer.AttackBoard.Surface, currentPlayer.Name);

                bool playerContinue = true;
                while (playerContinue)
                {
                    if (isWrongInput)
                    {
                        Board.Render(currentPlayer.AttackBoard.Surface, currentPlayer.Name);
                        Console.WriteLine("Invalid action!");
                        isWrongInput = false;
                    }

                    char action = prompter
                        .GetAlphabeticOrNumericKey("\nView (s) | Attack (x) | New (n) | End (e): ")
                        .KeyChar;

                    switch (action)
                    {
                        case 's':
                            gameActions.SwitchBoard(currentPlayer, prompter);
                            break;
                        case 'x':
                            playerContinue =
                                gameActions.PerformAttackAndRepeat(radar, currentPlayer, opponentPlayer);
                            break;
                        case 'n':
                            break;
                        case 'e':
                            gameActions.EndGame();
                            break;
                        default:
                            isWrongInput = true;
                            break;
                    }
                }

                isPlayer1Turn = !isPlayer1Turn;
            }
        }
    }
}

/* Game Flow
 * Create Board + Setup
 * => 2 Player, 4 Boards -> 2 Attack boards, 2 Placement boards (default field)
 * => 1x5; 1x4; 2x3; 1x2 = 5 ships
 *
 * Player1 & 2 turns
 * => Shoot (default = 0; hit = X; miss = o;)
 * => View Attack board OR Placement board
 *
 * Win condition
 * => All opponent ships sank
 */