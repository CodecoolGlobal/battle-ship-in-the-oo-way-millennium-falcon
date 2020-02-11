using System;

namespace BattleshipOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Game StarWars = new Game();

            Console.Clear();
            StarWars.Board.PrintBoard();
            StarWars.Player.PlayerShips.PopulatePlayerShipsList(StarWars.Player.IsRebellion, StarWars.Board);
            StarWars.Board.PrintBoard();


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
