using System;
using System.Linq;

namespace BattleshipOOP
{
    static class UI
    {
        static readonly string[] VALIDCOLUMNS = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        static readonly int[] VALIDROWS = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static string AskName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        }

        public static bool AskIfRebellion()
        {
            string answer;
            bool isRebellion = false;
            bool correctAnswer = false;
            while (!correctAnswer)
            {
                Console.WriteLine("Do you want to play Rebellion (r) or Empire (e)?");
                answer = Console.ReadLine().ToLower();
                if (answer == "r")
                {
                    isRebellion = true;
                    correctAnswer = true;
                    Console.WriteLine("Yay! You play the Rebellion! You are breathtaking!\n");
                }
                else if (answer == "e")
                {
                    isRebellion = false;
                    correctAnswer = true;
                    Console.WriteLine("Seriously? You play the Empire. You will lose anyway...\n");
                }
                else
                {
                    Console.WriteLine("Wrong answer! You have to pick a \"light\"-(r) or \"dark\"-(e) side.");
                }
            }
            return isRebellion;
        }

        public static bool GetShipAlignment()
        {
            string answer;
            bool isHorizontal = false;
            bool correctAnswer = false;
            while (!correctAnswer)
            {
                Console.WriteLine("Do you want to place your ship horizontally? (y/n)");
                answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    isHorizontal = true;
                    correctAnswer = true;
                }
                else if (answer == "n")
                {
                    isHorizontal = false;
                    correctAnswer = true;
                }
                else
                {
                    Console.WriteLine("Wrong answer! You have to pick yes-(y) or no-(n).");
                }
            }
            return isHorizontal;
        }

        public static int[] GetCoordinatesForShipHead()
        {
            string answer;
            int[] coordinates = new int[2];   
   
            bool correctAnswer = false;
            while (!correctAnswer)
            {
                Console.WriteLine("Where do you want to place your ship?");
                answer = Console.ReadLine();
                //TODO 
                //validation for this answer needed -> is this place occupied for all ship squares
                if (isAnswerValid(answer))
                {
                    coordinates[0] = TranslateCoordinates(answer[0].ToString());
                    coordinates[1] = int.Parse(answer.Substring(1)) - 1;
                }
                else
                {
                    Console.WriteLine("Please enter valid coordinates");
                }
            }
            return coordinates;
        }

        private static bool isAnswerValid(string answer)
        {
            return (VALIDCOLUMNS.Contains(answer[0].ToString()) && VALIDROWS.Contains(int.Parse(answer.Substring(1)))) ? true : false;
        }

        private static int TranslateCoordinates(string column)
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
