using System;
using System.Collections.Generic;

namespace BattleshipOOP
{
    class Ship
    {
        public string Type { get; set; }
        public int Size { get; set; }
        public bool IsHorizontal { get; set; }
        public bool IsAlive { get; set; }

        public List<int[]> FullCoordinates;
        public List<int[]> SafeZoneCoordinates;


        public Ship(string type) : this(type, true)
        {

        }

        public Ship(string type, bool ishorizontal)
        {
            Type = type;
            Size = GetShipLength(type);
            IsHorizontal = ishorizontal;
            IsAlive = true;
        }

        public void HitShip()
        {
            if (--Size == 0)
            {
                UI.AddComment($"Ship {Type} has turned into space debris...\n");
                IsAlive = false;
            }
        }



        private static int GetShipLength(string type)
        {
            if (type == "X-Wing" || type == "TIE Fighter") { return 1; }
            else if (type == "Millennium Falcon" || type == "Destroyer") { return 2; }
            else if (type == "Liberator" || type == "Dreadnaught") { return 3; }
            else if (type == "Nebulon-B2 Frigate" || type == "Deathstar") { return 4; }
            else
            {
                throw new ArgumentException("There is no such ship type.");
            }
        }

        public static bool GetRandomShipAlligment()
        {
            Random rand = new Random();
            return (rand.Next(2) == 1);
        }
    }
}
