using System;
using System.Collections.Generic;

namespace BattleshipOOP
{
    static class UI
    {
        public static string welcomeMessage = "Welcome to the Galaxy Battle Ship!";
// After Board remove, can be private
        public static string shortSeparator = " |";
        public static string longSeparator = "  |";
        public static string separatorLine = "--------------------------------------------";
        public static string topLine = "   | a | b | c | d | e | f | g | h | i | j |";
        public static string notHitShipMark = " # |";
        public static string notHitEmptyMark = "   |";
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



        public static void AskForPlacement(Ship ship, int i)
        {
            PrintMessage($"Where do you want to place your {numerals[i]} \"{ship.Type}\"?");
        }


        public static bool AskIfAutomaticFill()
        {
            PrintMessage("\nDo you want to fill your board automatically? (y/n)");
            string answer = "y";
            while (!Validation.CheckIfYesOrNo(answer))
            {
                answer = Console.ReadLine().ToLower();
                if (!Validation.CheckIfYesOrNo(answer))
                {
                    PrintMessage("Wrong answer");
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
            while (!Validation.CheckName(nameAnswer))
            {
                UI.PrintMessage(nameQuestion);
                //nameAnswer = Console.ReadLine();
                nameAnswer = "AAA";
                feedback = (!Validation.CheckName(nameAnswer)) ? notCorrectAnswerFeedback : $"Welcome captain {nameAnswer}!";
                UI.PrintMessage(feedback);
            }
            return nameAnswer;
        }

        public static bool AskIfRebellion()
        {
            string answer;
            bool isRebellion = false;
            bool correctAnswer = false;
            while (!correctAnswer)
            {
                UI.PrintMessage("\nDo you want to play Rebellion (r) or Empire (e)?");
                // answer = Console.ReadLine().ToLower();
                answer = "r";
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

                if (Validation.IsAnswerValid(coordinates))
                    correctAnswer = true;
                else
                    UI.PrintMessage("You are out of range!");
 
            }
            return coordinates;
        }

        public static void PrintTwoBoards(Player player, Player anotherPlayer)
        {
            
            string yourBoardMessage = "Your board:";
            string opponendBoardMessage = "Your opponent's board:";
            int columnOffset = 5;
            string spacesOffset = new string (' ', columnOffset);
            string yourBoardOffset = new string(' ', separatorLine.Length - yourBoardMessage.Length);
            int rowNumber = 1;
            string rowToPrint;
            Player currentPlayer = player;
            UI.PrintMessage(yourBoardMessage + yourBoardOffset + spacesOffset + opponendBoardMessage);
            UI.PrintMessage(topLine + spacesOffset + topLine);
            UI.PrintMessage(separatorLine + spacesOffset + separatorLine);

            for(int e = 0; e < currentPlayer.Board.board.Count; e++)
            {
                rowToPrint = "";
                for(int i = 0; i < 2; i++)
                {
                    if (rowNumber < 10)
                    {
                        rowToPrint += rowNumber.ToString() + longSeparator;
                    }
                    else
                    {
                        rowToPrint += rowNumber.ToString() + shortSeparator;
                    }  
                    foreach (Square square in currentPlayer.Board.board[e])
                    {
                        square.updateVisualRepresentation();
                        if (!currentPlayer.IsActivePlayer && square.visualRepresentation == notHitShipMark)
                        {
                            rowToPrint += notHitEmptyMark;
                        }
                        else
                        {
                            rowToPrint += square.visualRepresentation;
                        }
                    }
                    rowToPrint += (i == 0) ? spacesOffset : "";
                    currentPlayer = (i == 0) ? anotherPlayer : player;
                }
                UI.PrintMessage(rowToPrint);
                UI.PrintMessage(separatorLine + spacesOffset + separatorLine);
                rowNumber++;
            }  
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
