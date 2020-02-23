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
            UI.PrintTwoBoards(Player, AIOpponent);
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
                Console.WriteLine("\nWhich field do you want to shoot?");

                bool correctCoordinates = false;
                bool isShip = true;
                int[] cooridnates;

                while (!correctCoordinates && isShip && !AIOpponent.IsLost)
                {
                    cooridnates = UI.GetPairCoordinates();
                    correctCoordinates = AIOpponent.HandleShooting(cooridnates);
                    if (correctCoordinates)
                    {
                        isShip = AIOpponent.Board.CheckIfShip(cooridnates);
                        correctCoordinates = false;
                        AIOpponent.CheckIfLost();

                    } 

                    AIOpponent.PrintBoard();

                }

                isShip = true;
                correctCoordinates = false;

                while (!correctCoordinates && isShip && !AIOpponent.IsLost && !Player.IsLost)
                {
                    cooridnates = Handler.GetAICoordinates();
                    correctCoordinates = Player.HandleShooting(cooridnates);
                    if (correctCoordinates)
                    {
                        isShip = Player.Board.CheckIfShip(cooridnates);
                        correctCoordinates = false;
                        Player.CheckIfLost();
                    }
                    Player.PrintBoard();



                }
            }
        }
    }
}
