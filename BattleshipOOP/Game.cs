using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Game
    {
        public Space Board { get; set; }
        public Space AIBoard { get; set; }
        public Player Player { get; set; }
        public Player AIOpponent { get; set; }

        //private ShipsList PlayerOneShips { get; set; }
        //private ShipsList PlayerTwoShips { get; set; }

        public Game()
        {
            Board = new Space();
            AIBoard = new Space();
            Player = new Player(UI.AskName(), UI.AskIfRebellion());
            AIOpponent = new Player("AI", !Player.IsRebellion);
            
            //PlayerOneShips = new ShipsList(Player.IsRebellion);
            //PlayerTwoShips = new ShipsList(!Player.IsRebellion);
        }
    }
}
