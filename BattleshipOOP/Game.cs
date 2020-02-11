using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Game
    {
        public Space Board { get; set; }
        public Player Player { get; set; }

        //private ShipsList PlayerOneShips { get; set; }
        //private ShipsList PlayerTwoShips { get; set; }

        public Game()
        {
            Board = new Space();
            Player = new Player();
            
            //PlayerOneShips = new ShipsList(Player.IsRebellion);
            //PlayerTwoShips = new ShipsList(!Player.IsRebellion);
        }
    }
}
