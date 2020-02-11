using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class ShipsList
    {
        public Dictionary<string, int> ShipList { get; set; }
        
        //private List<Ship> Ships = new List<Ship>();

        private Dictionary<string, int> RebelShips = new Dictionary<string, int>
        {
            {"X-Wing", 1 },
            {"Millennium Falcon", 2 },
            {"Liberator", 3 },
            {"Nebulon-B2 Frigate", 4 }
        };

        private Dictionary<string, int> ImperialShips = new Dictionary<string, int>
        {
            {"TIE Fighter", 1 },
            {"Destroyer", 2 },
            {"Dreadnaught", 3 },
            {"Deathstar", 4 }
        };

        


        public ShipsList(bool isRebellion)
        {
            ShipList = (isRebellion) ? RebelShips : ImperialShips;
        }

        /*
        public void AddShip(string shipType, bool horizontal, List<int> coordinates)
        {
            if (IsRebellion) 
            {
                Ships.Add(new Ship(shipType, RebelShips[shipType], horizontal));
            }
            else
            {
                Ships.Add(new Ship(shipType, ImperialShips[shipType], horizontal));
            }
        }
        */
    }
}
