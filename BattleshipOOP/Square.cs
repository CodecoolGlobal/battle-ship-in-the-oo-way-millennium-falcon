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
        //private int[] Coordinates { get; set; }

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

        public static void UpdateShipSquaresOnBoard(Space board, Ship newShip)
        {
            foreach (int[] setOfCoordinates in newShip.FullCoordinates)
            {
                board.board[setOfCoordinates[0]][setOfCoordinates[1]].IsShip = true;
            }
        }
    }
}
