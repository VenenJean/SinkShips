using SinkShips.ConsoleApp.Models;
using SinkShips.ConsoleApp.Utility;
using System;

namespace SinkShips.ConsoleApp
{
    public class Initializer
    {
        private Player Player1 { get; } = new Player("Player 1");
        private Player Player2 { get; } = new Player("Player 2");
        private Player[] Players { get; }

        private Prompter Prompter { get; }
        private Radar Radar { get; }
        private ShipManager ShipManager { get; } = new ShipManager();

        public Initializer(Prompter prompter, Radar radar)
        {
            Prompter = prompter;
            Radar = radar;
            Players = new Player[]
            {
                Player1, Player2
            };
        }

        public void PlaceShipsAutomatically()
        {
            Player1.PlacementBoard.Surface = new string[,]
            {
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "0", "*", "0", "0", "0", "0", "*", "*", "*", "0" },
                { "0", "*", "0", "0", "*", "0", "0", "0", "0", "0" },
                { "0", "*", "0", "0", "*", "0", "0", "0", "0", "0" },
                { "0", "*", "0", "0", "0", "0", "0", "*", "0", "0" },
                { "0", "*", "0", "0", "0", "0", "0", "*", "0", "0" },
                { "0", "0", "0", "0", "0", "0", "0", "*", "0", "0" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "0", "*", "*", "*", "*", "0", "0", "0", "0", "0" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" }
            };

            Player2.PlacementBoard.Surface = new string[,]
            {
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "0", "0", "0", "0", "*", "*", "*", "*", "*", "0" },
                { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "0", "0", "*", "*", "*", "*", "0", "*", "0", "0" },
                { "0", "0", "0", "0", "0", "0", "0", "*", "0", "0" },
                { "*", "0", "0", "0", "0", "0", "0", "*", "0", "0" },
                { "*", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "*", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                { "0", "0", "0", "0", "*", "*", "0", "0", "0", "0" }
            };
        }

        public void Init()
        {
            foreach (var player in Players)
            {
                foreach (var ship in player.Ships)
                {
                    Board.Render(player.PlacementBoard.Surface, player.Name);
                    Console.WriteLine("\n---------------Ships--------------");
                    for (int i = 0; i < player.Ships.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {player.Ships[i].Name} - {player.Ships[i].Length}");
                    }

                    char position = new char();
                    while (position != 'h' && position != 'v')
                    {
                        position = Prompter
                            .GetAlphabeticOrNumericKey($"\nPlace {ship.Name} vertically or horizontally? (v/h) ")
                            .KeyChar;
                    }

                    var location = Radar.GetCoordinate();
                    if (position == 'v')
                    {
                        ShipManager.PlaceShipVertically(player.PlacementBoard.Surface, ship.Length, location);
                    }
                    else
                    {
                        ShipManager.PlaceShipHorizontally(player.PlacementBoard.Surface, ship.Length, location);
                    }

                    Board.Render(player.PlacementBoard.Surface, player.Name);
                }
            }
        }

        public (Player player1, Player player2) GetPlayers() => (Player1, Player2);
    }
}