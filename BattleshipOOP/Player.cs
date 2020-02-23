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

        public bool HandleShooting(int[] coordinates)
        {
            bool correctShot = Board.HandleShotOnSquare(coordinates);

            if (Board.CheckIfShip(coordinates) && correctShot)
            {
                PlayerShips.HitShip(coordinates);
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

        public bool CheckIfLost()
        {
            IsLost = true;
            foreach (Ship ship in PlayerShips.Ships)
            {
                if (ship.IsAlive)
                {
                    IsLost = false;
                    return IsLost;

                }
            }
            return IsLost;
        }

       

    }
}
