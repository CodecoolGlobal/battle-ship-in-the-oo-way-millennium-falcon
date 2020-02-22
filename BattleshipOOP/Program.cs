using System;

namespace BattleshipOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Game StarWars = new Game();
            StarWars.PopulateAllShips();
            UI.StartGameCountDown(Console.CursorLeft, Console.CursorTop);
            StarWars.HandleActions();


            /*testing block start
            Ship xwing = new Ship("X-wing", UI.GetShipAlignment()) ;
            var fullCoordinates = UI.GetCoordinatesForShipHead(xwing, space);
            foreach(int[] setOfCoordinates in fullCoordinates)
            {
                space.board[setOfCoordinates[0]][setOfCoordinates[1]].IsShip = true;
            }
            space.PrintBoard();
            testing zone end*/
        }
    }
}
