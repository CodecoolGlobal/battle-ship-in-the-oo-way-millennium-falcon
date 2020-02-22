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

            while (!Player.IsLost && !AIOpponent.IsLost)
            {
                if (isPlayerTurn == true)
                {
                    UI.PrintMessage("Which field do you want to shoot?");

                    bool correctCoordinates = false;
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
                    UI.PrintMessage("AI shoot!");
                    isPlayerTurn = true;
                }

            }
        }
    }
}
