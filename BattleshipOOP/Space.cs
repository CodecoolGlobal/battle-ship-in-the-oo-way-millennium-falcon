using System.Collections.Generic;

namespace BattleshipOOP
{
    class Space
    {

        public List<List<Square>> board = new List<List<Square>>();
        static string shortSeparator = " |";
        static string longSeparator = "  |";
        static string separatorLine = "--------------------------------------------";
        static string topLine = "   | a | b | c | d | e | f | g | h | i | j |";

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
            UI.PrintMessage(topLine);
            UI.PrintMessage(separatorLine);

            foreach (List<Square> element in board)
            {
                if (rowNumber < 10)
                {
                    rowToPrint = rowNumber.ToString() + longSeparator;
                }
                else
                {
                    rowToPrint = rowNumber.ToString() + shortSeparator;
                }
                
                foreach (Square square in element)
                {
                    square.updateVisualRepresentation();
                    if (!isActivePlayer && square.visualRepresentation == square.notHitShipMark)
                    {
                        rowToPrint += square.notHitEmptyMark;
                    }
                    else
                    {
                        rowToPrint += square.visualRepresentation;
                    }
                    
                }
                UI.PrintMessage(rowToPrint);
                UI.PrintMessage(separatorLine);
                rowNumber++;
            }  
        }

        public static void PrintTwoBoards(Player player, Player anotherPlayer)
        {
            
            string yourBoardMessage = "Your board:";
            string opponendBoardMessage = "Your opponent's board:";
            int columnOffset = 5;
            string spacesOffset = new string (' ', columnOffset);
            string yourBoardOffset = new string(' ', separatorLine.Length - yourBoardMessage.Length);
            int rowNumber = 1;
            string rowToPrint;
            Player currentPlayer = player;
            UI.PrintMessage(yourBoardMessage + yourBoardOffset + spacesOffset + opponendBoardMessage);
            UI.PrintMessage(topLine + spacesOffset + topLine);
            UI.PrintMessage(separatorLine + spacesOffset + separatorLine);

            for(int e = 0; e < currentPlayer.Board.board.Count; e++)
            {
                rowToPrint = "";
                for(int i = 0; i < 2; i++)
                {
                    if (rowNumber < 10)
                    {
                        rowToPrint += rowNumber.ToString() + longSeparator;
                    }
                    else
                    {
                        rowToPrint += rowNumber.ToString() + shortSeparator;
                    }  
                    foreach (Square square in currentPlayer.Board.board[e])
                    {
                        square.updateVisualRepresentation();
                        if (!currentPlayer.IsActivePlayer && square.visualRepresentation == square.notHitShipMark)
                        {
                            rowToPrint += square.notHitEmptyMark;
                        }
                        else
                        {
                            rowToPrint += square.visualRepresentation;
                        }
                    }
                    rowToPrint += (i == 0) ? spacesOffset : "";
                    currentPlayer = (i == 0) ? anotherPlayer : player;
                }
                UI.PrintMessage(rowToPrint);
                UI.PrintMessage(separatorLine + spacesOffset + separatorLine);
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
