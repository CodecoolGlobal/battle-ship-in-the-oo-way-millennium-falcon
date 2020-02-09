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

        }
    }
}
