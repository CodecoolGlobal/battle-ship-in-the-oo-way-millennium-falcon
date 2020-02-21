using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Square
    {
        private bool IsHit { get; set; }
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

        internal static void UpdateShipSquaresOnBoard(Space board, Ship newShip)
        {
            foreach (int[] setOfCoordinates in newShip.FullCoordinates)
            {
                board.board[setOfCoordinates[0]][setOfCoordinates[1]].IsShip = true;
            }
        }

        internal static void UpdateShipSafeZoneOnBoard(Space board, Ship newShip)
        {
            foreach (int[] setOfCoordinates in newShip.SafeZoneCoordinates)
            {
                if(!(setOfCoordinates[0]<0 || setOfCoordinates[0]>9 ||setOfCoordinates[1] <0 || setOfCoordinates[1] > 9))
                {
                    board.board[setOfCoordinates[0]][setOfCoordinates[1]].IsTooClose = true;
                }
            }
        }
    }
}
