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
                Console.WriteLine("Do you want to play Rebellion (r) or Imperium (i)?");
                answer = Console.ReadLine().ToLower();
                if (answer == "r")
                {
                    isRebellion = true;
                    correctAnswer = true;
                    Console.WriteLine("Yay! You play the Rebellion! You are breathtaking!\n");
                }
                else if (answer == "i")
                {
                    isRebellion = false;
                    correctAnswer = true;
                    Console.WriteLine("Seriously? You play the Imperium. You will lose anyway\n");
                }
                else
                {
                    Console.WriteLine("Wrong answer!");
                }

            }

            return isRebellion;

        }
    }
}
