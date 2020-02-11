using System;
using System.Collections.Generic;

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

        public static List<int[]> GetCoordinatesForShipHead(Ship ship, Space space)
        {
            string userPlacement;
            int[] coordinates = {-1, -1};   
   
            bool correctAnswer = false;
            while (!correctAnswer)
            {
                Console.WriteLine("Where do you want to place your ship?");
                userPlacement = Console.ReadLine();

                coordinates[0] = int.Parse(userPlacement.Substring(1)) - 1; 
                coordinates[1] = Validation.TranslateCoordinates(userPlacement[0].ToString());

                if (Validation.isAnswerValid(coordinates) && !Validation.IsThereAShip(space, ship, coordinates))
                {
                    correctAnswer = true;
                }
                else
                {
                    Console.WriteLine("Please enter valid coordinates.");
                }
            }
            return GetFullShipCoordinates(ship, coordinates);
        }

        private static List<int[]> GetFullShipCoordinates(Ship ship, int[] headCoordinates)
        {
            List<int[]> fullCoordinatesList = new List<int[]>();
            for (int i = 0; i < ship.Lenght; i++)
            {
                int[] shipSegment = new int[2];
                if(ship.Horizontal)
                {
                    shipSegment[0] = headCoordinates[0];
                    shipSegment[1] = headCoordinates[1] + i;
                }
                else
                {
                    shipSegment[0] = headCoordinates[0] + i;
                    shipSegment[1] = headCoordinates[1];
                }
                fullCoordinatesList.Add(shipSegment);
            }
            return fullCoordinatesList;
        }
    }
}
