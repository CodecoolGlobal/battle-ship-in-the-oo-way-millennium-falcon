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
            UI.PrintWelcomeMessage();
            Player = new Player(UI.AskName(), UI.AskIfRebellion(), true);
            AIOpponent = new Player("AI", !Player.IsRebellion, false);
            // UI.StartGameCountDown(Console.CursorLeft, Console.CursorTop);
            
        }
        
        public void PrintBothBoards()
        {
            Console.Clear();
            Console.WriteLine("This is your board:\n");
            Player.PrintBoard();
            Console.WriteLine("\nThis is oponent's board:\n");
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
            while (!Player.IsLost && !AIOpponent.IsLost)
            {
                Console.WriteLine("Which field do you want to shoot?");

                bool correctCoordinates = false;
                while (!correctCoordinates)
                {
                    int[] cooridnates = UI.GetPairCoordinates();
                    Console.Clear();
                    correctCoordinates = AIOpponent.HandleShooting(cooridnates);
                    AIOpponent.PrintBoard();

                }
            }
        }
    }
}
