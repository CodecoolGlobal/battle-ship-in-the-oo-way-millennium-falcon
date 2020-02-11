using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Ship
    {
        private string Type { get; set; }
        public int Lenght { get; set; }
        public bool Horizontal { get; set; }

        public Ship(string type, bool horizontal)
        {
            Type = type;
            Lenght = GetShipLength(type);
            Horizontal = horizontal;
        }

        private static int GetShipLength(string type)
        {
            if (type == "X-wing" || type == "TIE fighter") { return 1; }
            else if (type == "Millennium Falcon" || type == "Destroyer") { return 2; }
            else if (type == "X-wing" || type == "Dreadnaught") { return 3; }
            else if (type == "Nebulon-B2 Frigate" || type == "Deathstar") { return 4; }
            else
            {
                throw new ArgumentException("There is no such ship type.");
            }
        }
    }
}
