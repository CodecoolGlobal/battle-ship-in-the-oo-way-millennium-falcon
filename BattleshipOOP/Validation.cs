using System;
using System.Linq;

namespace BattleshipOOP
{
    static class Validation
    {
        static private readonly int[] VALIDROWS = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

        public static bool IsAnswerValid(int[] coordinates)
        {
            return (VALIDROWS.Contains(coordinates[0]) && VALIDROWS.Contains(coordinates[1]));
        }
        
        // it converts a character to integer based on its char code, example: 'B' - 'A' == 1
        public static int TranslateCoordinates(char column)
        {
            int index = char.ToUpper(column) - 'A';
            return index;
        }

        public static bool CheckName(string name)
        {
            return (name.Length > 0);
        }

        static public bool CheckIfYesOrNo(string answer)
        {
            answer = answer.ToLower();
            return (answer == "y" || answer == "n");

        }


        public static bool IsThereAShip(Space space, Ship ship, int[] coordinates)
        {
            bool isThereAShip = false;
            for (int i = 0; i < ship.Size; i++)
            {
                try
                {
                    if (ship.IsHorizontal)
                    {
                        if (space.board[coordinates[0]][coordinates[1] + i].IsTooClose)
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else 
                    {
                        if (space.board[coordinates[0] + i][coordinates[1]].IsTooClose)
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                catch(ArgumentOutOfRangeException)
                {
                    isThereAShip = true;
                }
            }
            return isThereAShip;
        }
    }
}
