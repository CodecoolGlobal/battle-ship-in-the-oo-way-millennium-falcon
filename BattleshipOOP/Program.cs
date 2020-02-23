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
            StarWars.PrintBothBoards();
            UI.StartGameCountDown(Console.CursorLeft, Console.CursorTop);
            StarWars.HandleActions();
        }
    }
}
