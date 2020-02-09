using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Square
    {
        private bool IsHit { get; set; }
        private bool IsShip { get; set; }

        public string visualRepresentation;

        public Square()
        {
            IsShip = false;
            IsHit = false;
            visualRepresentation = "   |";
        }

        public void updateVisualRepresentation()
        {
            if (IsHit && IsShip)
            {
                visualRepresentation = " X |";
            }
            else if (IsHit && !IsShip)
            {
                visualRepresentation = " + |";
            }
            else if (!IsHit && IsShip)
            {
                visualRepresentation = " # |";
            }
            else
            {
                visualRepresentation = "   |";
            }
        }

    }
}
