using System;

namespace BattleshipOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Space space = new Space();
            space.PrintBoard();

            //testing block start
            Ship xwing = new Ship("X-wing", 2, UI.GetShipAlignment()) ;
            var fullCoordinates = UI.GetCoordinatesForShipHead(xwing, space);
            foreach(int[] setOfCoordinates in fullCoordinates)
            {
                space.board[setOfCoordinates[0]][setOfCoordinates[1]].IsShip = true;
            }
            space.PrintBoard();
            //testing zone end
        }
    }
}
