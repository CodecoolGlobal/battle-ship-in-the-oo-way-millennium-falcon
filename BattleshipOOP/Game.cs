using System;
using System.Linq;
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
                UI.PrintTwoBoards(Player, AIOpponent);
                UI.PrintComments();
                UI.PrintMessage("\nWhich field do you want to shoot?");

                bool correctCoordinates = false;
                bool isShip = true;
                int[] coordinates;
                char charRepresentation;

                while (!correctCoordinates && isShip && !AIOpponent.IsLost)
                {
                    coordinates = UI.GetPairCoordinates();
                    correctCoordinates = AIOpponent.IsAlreadyUsed(coordinates);
                    if (correctCoordinates)
                    {
                        AIOpponent.HandleShooting(coordinates);
                        isShip = AIOpponent.Board.CheckIfShip(coordinates);
                        correctCoordinates = false;
                        AIOpponent.CheckIfLost();
                        if (isShip)
                        {
                            UI.PrintTwoBoards(AIOpponent, AIOpponent);
                            UI.PrintComments();
                        }
                    } 
                }

                isShip = true;
                correctCoordinates = false;

                while (!correctCoordinates && isShip && !AIOpponent.IsLost && !Player.IsLost)
                {
                    coordinates = Handler.GetRandomCoordinates();
                    while (Player.alreadySelected.Any(x => x[0] == coordinates[0] && x[1] == coordinates[1]))
                    {
                        coordinates = Handler.GetRandomCoordinates(); 
                    }
                    charRepresentation = Convert.ToChar(('A' + coordinates[1]));
                    UI.AddComment($"\nAI shoots at: {charRepresentation}{coordinates[0] + 1}\n");
                    Player.alreadySelected.Add(coordinates);
                    correctCoordinates = Player.IsAlreadyUsed(coordinates);
                    if (correctCoordinates)
                    {
                        Player.HandleShooting(coordinates);
                        isShip = Player.Board.CheckIfShip(coordinates);
                        correctCoordinates = false;
                        Player.CheckIfLost();
                    }

                }
            }
        }
    }
}
