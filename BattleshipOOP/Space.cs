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

        public bool CheckIfShip(int[] coordinates)
        {
            return board[coordinates[0]][coordinates[1]].IsShip;
        }

        public bool IsAlreadyUsed(int[] coordinates)
        {
            bool isCorrect = false;
            Square square = board[coordinates[0]][coordinates[1]];

            if (square.IsHit)
            {
                UI.PrintMessage("You have shot this field already!");
            }
            else
            {
                isCorrect = true;
            }
            return isCorrect;
        }

        public void HandleShotOnSquare(int[] coordinates)
        {
            Square square = board[coordinates[0]][coordinates[1]];
            
            if (square.IsShip)
            {
                UI.AddComment("A ship was hit! Extra shoot!\n");
                // UI.PrintMessage("A ship was hit! You can shoot again :)");
            }
            else
            {
                UI.AddComment("Miss!\n");
            }
            square.IsHit = true;
            square.updateVisualRepresentation();

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
