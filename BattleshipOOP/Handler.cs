using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    static class Handler
    {
        public static int[] GetAICoordinates()
        {
            int minBoardCoord = 0;
            int maxBoardCoord = 9;
            int[] AIcoordinates = new int[2];
            Random random = new Random();

            AIcoordinates[0] = random.Next(minBoardCoord, maxBoardCoord);
            AIcoordinates[1] = random.Next(minBoardCoord, maxBoardCoord);

            char charRepresentation = Convert.ToChar(('A' + AIcoordinates[1]));
            UI.PrintMessage($"Coordinates: {charRepresentation}{AIcoordinates[0] + 1}");

            return AIcoordinates;
        }
    }
}
