using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Ship
    {
        private string Type { get; set; }
        private int Lenght { get; set; }
        private bool Horizontal { get; set; }
        private List<int> Coordinates { get; set; }

        public Ship(string type, int lenght, bool horizontal, List<int> coordinates)
        {
            Type = type;
            Lenght = lenght;
            Horizontal = horizontal;
            Coordinates = coordinates;

        }



    }
}
