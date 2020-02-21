using System;
using System.Collections.Generic;
using System.Text;

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

        private string separatorLine = "--------------------------------------------";
        private string topLine = "   | a | b | c | d | e | f | g | h | i | j |";
        private string shortSeparator = " |";
        private string longSeparator = "  |";

        private void PrintTopLines()
        {
            Console.WriteLine(topLine);
            Console.WriteLine(separatorLine);
        }


        public void PrintBoard(bool isActivePlayer)
        {

            int rowNumber = 1;
            string rowToPrint;
            PrintTopLines();

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
                Console.WriteLine(rowToPrint);
                Console.WriteLine(separatorLine);
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
                Console.WriteLine("You have shot this field already!");
            }
            else if (square.IsShip)
            {
                Console.WriteLine("You hit a ship!");
                square.IsHit = true;
                square.updateVisualRepresentation();
                isCorrect = true;
            }
            else
            {
                Console.WriteLine("You hit nothing!");
                square.IsHit = true;
                square.updateVisualRepresentation();
                isCorrect = true;
            }

            return isCorrect;
        }

   
    }
}
