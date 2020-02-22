using System;
using System.Collections.Generic;

namespace BattleshipOOP
{
    static class UI
    {
        public static string welcomeMessage = "Welcome to the Galaxy Battle Ship!";
        private static Dictionary<int, string> numerals = new Dictionary<int, string>()
        {
            {0, "first" },
            {1, "second" },
            {2, "third" },
            {3, "fourth" }
        };

        public static void PrintMessage(string myMessage)
        {
            Console.WriteLine(myMessage);
        }

        public static bool AskIfAutomaticFill()
        {
            UI.PrintMessage("\nDo you want to fill your board automatically? (y/n)");
            string answer = "";
            while (answer != "y" && answer != "n")
            {
                answer = Console.ReadLine().ToLower();
                if (answer != "y" && answer != "n")
                {
                    UI.PrintMessage("Wrong answer");
                }

            }

            return (answer == "y");

        }


        public static string AskName()
        {
            string nameAnswer = "";
            string nameQuestion = "\nWhat is your name, challenger?";
            string feedback;
            string notCorrectAnswerFeedback = "Ooops! It looks like you have not provided any answer. Try again!";
            while (!CheckName(nameAnswer))
            {
                UI.PrintMessage(nameQuestion);
                nameAnswer = Console.ReadLine();
                feedback = (!CheckName(nameAnswer)) ? notCorrectAnswerFeedback : $"Welcome captain {nameAnswer}!";
                UI.PrintMessage(feedback);
            }

            return nameAnswer;
        }

        public static bool CheckName(string name)
        {
            return (name.Length > 0 ? true : false);
        }

        public static bool AskIfRebellion()
        {
            string answer;
            bool isRebellion = false;
            bool correctAnswer = false;
            while (!correctAnswer)
            {
                UI.PrintMessage("\nDo you want to play Rebellion (r) or Empire (e)?");
                answer = Console.ReadLine().ToLower();
                if (answer == "r")
                {
                    isRebellion = true;
                    correctAnswer = true;
                    UI.PrintMessage("Yay! You play the Rebellion! You are breathtaking!");
                }
                else if (answer == "e")
                {
                    isRebellion = false;
                    correctAnswer = true;
                    UI.PrintMessage("Seriously? You play the Empire. You will lose anyway...");
                }
                else
                {
                    UI.PrintMessage("Wrong answer! You have to pick a \"light\"-(r) or \"dark\"-(e) side.");
                }
            }
            return isRebellion;
        }

        public static bool GetShipAlignment(string shipType, int i)
        {
            bool isHorizontal = false;
            string answer;
            bool correctAnswer = false;
            while (!correctAnswer)
            {
                UI.PrintMessage($"Do you want to place {numerals[i]} \"{shipType}\" horizontally? (y/n)");
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
                    UI.PrintMessage("Wrong answer! You have to pick yes-(y) or no-(n).");
                }
            }
            return isHorizontal;
        }

        public static int[] GetPairCoordinates()
        {
            int[] coordinates = { -1, -1 };
            bool correctAnswer = false;
            while (!correctAnswer)
            {
                string userPlacement = Console.ReadLine();

                try
                {
                    coordinates[0] = int.Parse(userPlacement.Substring(1)) - 1;
                    coordinates[1] = Validation.TranslateCoordinates(userPlacement[0]);
                }
                catch (FormatException)
                {
                    UI.PrintMessage("Wrong coordinates format. First enter column letter, than row number. For example \"a1\".");
                    continue;
                }
                catch (ArgumentException error)
                {
                    UI.PrintMessage(error.Message);
                    continue;
                }

                if (Validation.isAnswerValid(coordinates))
                    correctAnswer = true;
                else
                    UI.PrintMessage("You are out of range!");
 
            }
            return coordinates;
        }

        public static List<int[]> GetFullCoordinatesFromShipHead(Ship ship, Space space, int i)
        {
            int[] coordinates = { -1, -1 };

            bool correctAnswer = false;
            while (!correctAnswer)
            {
                UI.PrintMessage($"Where do you want to place your {numerals[i]} \"{ship.Type}\"?");
                coordinates = GetPairCoordinates();

             
                if (Validation.isAnswerValid(coordinates) && !Validation.IsThereAShip(space, ship, coordinates))
                {
                    correctAnswer = true;
                }
                else
                {
                    UI.PrintMessage("Please enter valid coordinates. You are too close!");
                }
            }
            return GetFullShipCoordinates(ship, coordinates);
        }

        public static List<int[]> GetFullShipCoordinates(Ship ship, int[] headCoordinates)
        {
            List<int[]> fullCoordinatesList = new List<int[]>();
            for (int i = 0; i < ship.Size; i++)
            {
                int[] shipSegment = new int[2];
                if(ship.IsHorizontal)
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

        public static int[] RandomShipHeadCoordinates()
        {
            Random rand = new Random();
            int[] randomHeadCoordiantes = {rand.Next(10), rand.Next(10)};
            return randomHeadCoordiantes;
        }

        internal static List<int[]> GetSafeZoneCoordinates(Ship newShip)
        {
            List<int[]> safeZoneCoordinates = new List<int[]>();
            foreach (var shipCoordinate in newShip.FullCoordinates)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int[] safeCoordinate = new int[2];
                        safeCoordinate[0] = shipCoordinate[0] - 1 + i;
                        safeCoordinate[1] = shipCoordinate[1] - 1 + j;
                        safeZoneCoordinates.Add(safeCoordinate);
                    }
                }  
            }
            return safeZoneCoordinates;
        }

        public static void StartGameCountDown(int positionX, int positionY)
        {
            int counter = 3;
            string countMessage = "Good luck! The Game will start in {0} ";
            string emptyMessage = new string (' ', countMessage.Length);

            for (int a = counter; a > 0; a--)
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(countMessage, a);  // Override complete previous contents
                System.Threading.Thread.Sleep(1000);
            }
            
            
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(emptyMessage);  // Override complete previous contents
            System.Threading.Thread.Sleep(1000);
        }
    }
}
