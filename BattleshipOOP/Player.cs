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

        public Player(string name, bool isRebellion, bool isActivePlayer)
        {
            Name = name;
            IsRebellion = isRebellion;
            PlayerShips = new ShipsList();
            IsActivePlayer = isActivePlayer;
            Board = new Space();
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
    }
}
