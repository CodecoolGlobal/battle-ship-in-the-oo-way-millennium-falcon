using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    static class UI
    {
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

        public static int[] GetCoordinatesForShip()
        {
            string answer;
            int[] coordinates = new int[2];

            Console.WriteLine("Where do you want to place your ship?");
            answer = Console.ReadLine();
            //TODO 
            //validation for this answer needed -> valid letter, valid number, is this place occupied for all ship squares
            coordinates[0] = TranslateCoordinates(answer[0].ToString());
            coordinates[1] = int.Parse(answer.Substring(1))-1;

            return coordinates;
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
