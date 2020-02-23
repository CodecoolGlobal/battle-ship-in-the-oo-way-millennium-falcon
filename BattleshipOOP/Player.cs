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
        public bool IsActivePlayer { get; set; }
        public bool IsLost { get; set; }
        public List<int[]> alreadySelected { get; set; }
        // private int[] last_hit { get; set; }

        public Player(string name, bool isRebellion, bool isActivePlayer)
        {
            Name = name;
            IsRebellion = isRebellion;
            PlayerShips = new ShipsList();
            IsActivePlayer = isActivePlayer;
            Board = new Space();
            IsLost = false;
            alreadySelected = new List<int[]>();
        }

        public bool HandleShooting(int[] coordinates)
        {
            bool correctShot = Board.HandleShotOnSquare(coordinates);

            if (Board.CheckIfShip(coordinates) && correctShot)
            {
                PlayerShips.HitShip(coordinates);
                UpdateZonesAfterDefeatingShip(coordinates);
            }

            return correctShot;
        }

        public void UpdateZonesAfterDefeatingShip(int[] coordinates)
        {
            Ship ship = PlayerShips.GetShipAtCoordinates(coordinates);
            if (!ship.IsAlive)
            {
                
                foreach (int[] zoneCoordinates in ship.SafeZoneCoordinates) 
                {
                    Board.board[zoneCoordinates[0]][zoneCoordinates[1]].IsHit = true;
                    alreadySelected.Add(zoneCoordinates);
                }
            }
        }



        public void PopulatePlayerShipList()
        {
            PlayerShips.PopulatePlayerShipsList(IsRebellion, Board);
        }

        public void AutomaticShipPopulation()
        {
            PlayerShips.AutomaticShipListPopulation(IsRebellion, Board);
        }

    // #TODO

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
