using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Game
    {
        private Player Player { get; set; }
        private ShipsList PlayerOneShips { get; set; }
        private ShipsList PlayerTwoShips { get; set; }

        public Game()
        {
            Player = new Player();
            PlayerOneShips = new ShipsList(Player.IsRebellion);
            PlayerTwoShips = new ShipsList(!Player.IsRebellion);


        }



    }
}
