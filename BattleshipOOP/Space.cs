using System.Collections.Generic;

namespace BattleshipOOP
{
    class Space
    {

        public List<List<Square>> board = new List<List<Square>>();

        public Space()
        {
            for (int width = 0; width < 10; width++)
            {
                board.Add(new List<Square>());
                for (int lenght = 0; lenght < 10; lenght++)
                {
                    board[width].Add(new Square());
                }
            }
        }

        public void PrintBoard(bool isActivePlayer)
        {
            int rowNumber = 1;
            string rowToPrint;
            UI.PrintMessage(UI.topLine);
            UI.PrintMessage(UI.separatorLine);

            foreach (List<Square> element in board)
            {
                if (rowNumber < 10)
                {
                    rowToPrint = rowNumber.ToString() + UI.longSeparator;
                }
                else
                {
                    rowToPrint = rowNumber.ToString() + UI.shortSeparator;
                }
                
                foreach (Square square in element)
                {
                    square.updateVisualRepresentation();
                    if (!isActivePlayer && square.visualRepresentation == UI.notHitShipMark)
                    {
                        rowToPrint += UI.notHitEmptyMark;
                    }
                    else
                    {
                        rowToPrint += square.visualRepresentation;
                    }
                    
                }
                UI.PrintMessage(rowToPrint);
                UI.PrintMessage(UI.separatorLine);
                rowNumber++;
            }  
        }

        public bool CheckIfShip(int[] coordinates)
        {
            return board[coordinates[0]][coordinates[1]].IsShip;
        }

        public bool HandleShotOnSquare(int[] coordinates)
        {
            bool isCorrect = false;
            Square square = board[coordinates[0]][coordinates[1]];

            if (square.IsHit)
            {
                UI.PrintMessage("You have shot this field already!");
            }
            else 
            {
                if (square.IsShip)
                {
                    UI.PrintMessage("A ship was hit!");
                }
                else
                {
                    UI.PrintMessage("Miss!");
                }
                square.IsHit = true;
                square.updateVisualRepresentation();
                isCorrect = true;
            }
            return isCorrect;
        }

        internal void UpdateShipSquaresOnBoard(Ship newShip)
        {
            foreach (int[] setOfCoordinates in newShip.FullCoordinates)
            {
                board[setOfCoordinates[0]][setOfCoordinates[1]].IsShip = true;
            }
        }

        internal void UpdateShipSafeZoneOnBoard(Ship newShip)
        {
            foreach (int[] setOfCoordinates in newShip.SafeZoneCoordinates)
            {
                if (!(setOfCoordinates[0] < 0 || setOfCoordinates[0] > 9 || setOfCoordinates[1] < 0 || setOfCoordinates[1] > 9))
                {
                   board[setOfCoordinates[0]][setOfCoordinates[1]].IsTooClose = true;
                }
            }
        }
    }
}
