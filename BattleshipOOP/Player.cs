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

        public Player()
        {
            Name = UI.AskName();
            IsRebellion = UI.AskIfRebellion();
            PlayerShips = new ShipsList();
        }
    }
}
