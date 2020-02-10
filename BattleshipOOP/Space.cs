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

        //public void UpdateSpace(int[])
 

        public void PrintBoard()
        {
            string separatorLine = "--------------------------------------------";
            Console.WriteLine("   | a | b | c | d | e | f | g | h | i | j |");
            Console.WriteLine(separatorLine);
            int rowNumber = 1;
            string rowToPrint;

            foreach (List<Square> element in board)
            {
                if (rowNumber < 10)
                {
                    rowToPrint = rowNumber.ToString() + "  |";
                }
                else
                {
                    rowToPrint = rowNumber.ToString() + " |";
                }
                
                foreach (Square square in element)
                {
                    square.updateVisualRepresentation();
                    rowToPrint += square.visualRepresentation;
                }
                Console.WriteLine(rowToPrint);
                Console.WriteLine(separatorLine);
                rowNumber++;
            }  
        }
    }
}
