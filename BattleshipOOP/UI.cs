using System;

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
                if (Validation.isAnswerValid(answer))
                {
                    coordinates[0] = Validation.TranslateCoordinates(answer[0].ToString());
                    coordinates[1] = int.Parse(answer.Substring(1)) - 1;
                }
                else
                {
                    Console.WriteLine("Please enter valid coordinates");
                }
            }
            return coordinates;
        }
    }
}
