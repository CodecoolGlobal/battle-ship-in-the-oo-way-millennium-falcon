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
            Random random = new Random();
            int n = random.Next(0, 2);
            bool isPlayerTurn = (random.Next(0, 2) % 2 == 0) ? false: true;
            bool correctCoordinates = false;
     

            Console.Clear();
            UI.PrintMessage("This is opponent's board:");
            AIOpponent.PrintBoard();

            while (!Player.IsLost && !AIOpponent.IsLost)
            {
                correctCoordinates = false;

                if (isPlayerTurn == true)
                {
                    UI.PrintMessage("\nWhich field do you want to shoot?");

                    while (!correctCoordinates)
                    {
                        int[] coordinates = UI.GetPairCoordinates();
                        Console.Clear();
                        correctCoordinates = AIOpponent.HandleShooting(coordinates);

                        AIOpponent.PrintBoard();

                    }
                    isPlayerTurn = false;
                } 
                else
                {
                    // Game.AITurn();

                    while (!correctCoordinates)
                    {
                        int[] coordinates = Game.GetAICoordinates();
                        UI.PrintMessage("\nAI shoot!");
                        correctCoordinates = Player.HandleShooting(coordinates);
                        Player.PrintBoard();
                        isPlayerTurn = true;
                    }
                }

            }
        }

        public static int[] GetAICoordinates()
        {
            int[] AIcoordinates = new int[2];
            Random random = new Random();
            int x = random.Next(0, 10);
            int y = random.Next(0, 10);

            AIcoordinates[0] = x;
            AIcoordinates[1] = y;
            UI.PrintMessage($"X: {x} \nY: {y}");

            return AIcoordinates;
        }
    }
}
