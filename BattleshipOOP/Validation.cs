using System;
using System.Linq;

namespace BattleshipOOP
{
    static class Validation
    {
        static private readonly string[] VALIDCOLUMNS = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        static private readonly int[] VALIDROWS = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static bool isAnswerValid(string answer)
        {
            return (VALIDCOLUMNS.Contains(answer[0].ToString()) && VALIDROWS.Contains(int.Parse(answer.Substring(1)))) ? true : false;
        }

        public static int TranslateCoordinates(string column)
        {
            switch (column.ToUpper())
            {
                case "A":
                    return 0;
                case "B":
                    return 1;
                case "C":
                    return 2;
                case "D":
                    return 3;
                case "E":
                    return 4;
                case "F":
                    return 5;
                case "G":
                    return 6;
                case "H":
                    return 7;
                case "I":
                    return 8;
                case "J":
                    return 9;
                default:
                    throw new ArgumentException("Entered column number does not match any available field.");
            }
        }
    }
}
