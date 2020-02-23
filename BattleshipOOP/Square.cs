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

        public Square()
        {
            IsShip = false;
            IsHit = false;
            IsTooClose = false;
            updateVisualRepresentation();
        }

        public void updateVisualRepresentation()
        {
            string hitShipMark = " X |";
            string hitEmptyMark = " + |";

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
                visualRepresentation = UI.notHitShipMark;
            }
            else
            {
                visualRepresentation = UI.notHitEmptyMark;
            }
        }
    }
}
