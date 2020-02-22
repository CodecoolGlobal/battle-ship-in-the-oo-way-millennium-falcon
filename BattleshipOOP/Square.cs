using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Square
    {
        public bool IsHit { get; set; }
        public bool IsShip { get; set; }
        public bool IsTooClose { get; set; }

        public string visualRepresentation;
        public string hitShipMark = " X |";
        public string hitEmptyMark = " + |";
        public string notHitShipMark = " # |";
        public string notHitEmptyMark = "   |";

        public Square()
        {
            IsShip = false;
            IsHit = false;
            IsTooClose = false;
            visualRepresentation = notHitEmptyMark;
        }

        public void updateVisualRepresentation()
        {
            if (IsHit && IsShip)
            {
                visualRepresentation = hitShipMark;
            }
            else if (IsHit && !IsShip)
            {
                visualRepresentation = hitEmptyMark;
            }
            else if (!IsHit && IsShip)
            {
                visualRepresentation = notHitShipMark;
            }
            else
            {
                visualRepresentation = notHitEmptyMark;
            }
        }
    }
}
