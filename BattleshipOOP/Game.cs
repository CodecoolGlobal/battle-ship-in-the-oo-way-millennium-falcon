using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Game
    {

        public Player Player { get; set; }
        public Player AIOpponent { get; set; }

        public Game()
        {
            UI.PrintMessage(UI.welcomeMessage);
            Player = new Player(UI.AskName(), UI.AskIfRebellion(), true);
            AIOpponent = new Player("AI", !Player.IsRebellion, false);
        }
        
        public void PrintBothBoards()
        {
            Console.Clear();
            UI.PrintMessage("This is your board:\n");
            Player.PrintBoard();
            UI.PrintMessage("\nThis is oponent's board:\n");
            AIOpponent.PrintBoard();

        }

        public void PopulateAllShips()
        {
            if (UI.AskIfAutomaticFill())
            {
                Player.AutomaticShipPopulation();
            }
            else
            {
                Player.PopulatePlayerShipList();
            }

            AIOpponent.AutomaticShipPopulation();
        }

        public void HandleActions()
        {
            int[] coordinates = new int[2];
            bool[] correctCoordinates = new bool[2];
            int isCorrectIndex = 0;
            int isShipIndex = 1;
            
            Random random = new Random();
            int n = random.Next(0, 2);
            bool isPlayerTurn = (random.Next(0, 2) % 2 == 0) ? false: true;
            

            Console.Clear();
            UI.PrintMessage("This is opponent's board:");
            AIOpponent.PrintBoard();

            while (!Player.IsLost && !AIOpponent.IsLost)
            {
                correctCoordinates[isCorrectIndex] = false;

                if (isPlayerTurn == true)
                {
                    UI.PrintMessage("\nWhich field do you want to shoot?");

                    while (!correctCoordinates[isCorrectIndex])
                    {
                        coordinates = UI.GetPairCoordinates();
                        Console.Clear();
                        bool[] response = AIOpponent.HandleShooting(coordinates);
                        correctCoordinates[isCorrectIndex] = response[isCorrectIndex];
                        AIOpponent.PrintBoard();

                        isPlayerTurn = response[isShipIndex];
                    }
                } 
                else
                {
                    UI.PrintMessage("\nAI turn:");

                    while (!correctCoordinates[isCorrectIndex])
                    {
                        
                        coordinates = Player.GetAICoordinates();
                        bool[] response = Player.HandleShooting(coordinates);
                        correctCoordinates[isCorrectIndex] = response[isCorrectIndex];
                        Player.PrintBoard();
                        isPlayerTurn = !(response[isShipIndex]);
                    }
                }

            }
        }
    }
}
