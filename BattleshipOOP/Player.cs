using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Player
    {
        private string Name { get; set; }
        public bool IsRebellion { get; set; }
        public ShipsList PlayerShips { get; set; }
        public Space Board { get; set; }
        private bool IsActivePlayer { get; set; }
        public bool IsLost { get; set; }
        // private int[] last_hit { get; set; }

        public Player(string name, bool isRebellion, bool isActivePlayer)
        {
            Name = name;
            IsRebellion = isRebellion;
            PlayerShips = new ShipsList();
            IsActivePlayer = isActivePlayer;
            Board = new Space();
            IsLost = false;
        }

        public bool[] HandleShooting(int[] coordinates)
        {
            bool[] correctShot = new bool[2];
            correctShot[0] = Board.HandleShotOnSquare(coordinates);

            if (Board.CheckIfShip(coordinates) && correctShot[0])
            {
                PlayerShips.HitShip(coordinates);
                correctShot[1] = true;
            }

            return correctShot;
        }

 
        public void PopulatePlayerShipList()
        {
            PlayerShips.PopulatePlayerShipsList(IsRebellion, Board);
        }

        public void AutomaticShipPopulation()
        {
            PlayerShips.AutomaticShipListPopulation(IsRebellion, Board);
        }

        public void PrintBoard()
        {
            Board.PrintBoard(IsActivePlayer);
        }

        public static int[] GetAICoordinates()
        {
            int minBoardCoord = 0;
            int maxBoardCoord = 10;
            int[] AIcoordinates = new int[2];
            Random random = new Random();
            int x = random.Next(minBoardCoord, maxBoardCoord);
            int y = random.Next(minBoardCoord, maxBoardCoord);

            AIcoordinates[0] = x;
            AIcoordinates[1] = y;
            UI.PrintMessage($"X: {x} Y: {y}");

            return AIcoordinates;
        }

    }
}
