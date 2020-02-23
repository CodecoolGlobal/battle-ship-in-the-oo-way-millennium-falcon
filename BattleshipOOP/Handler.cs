using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipOOP
{
    static class Handler
    {

        public static List<int[]> GetSafeZoneCoordinates(Ship newShip)
        {
            List<int[]> safeZoneCoordinates = new List<int[]>();
            foreach (var shipCoordinate in newShip.FullCoordinates)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int[] safeCoordinate = new int[2];
                        safeCoordinate[0] = shipCoordinate[0] - 1 + i;
                        safeCoordinate[1] = shipCoordinate[1] - 1 + j;
                        if (safeCoordinate[0] >= 0 && safeCoordinate[0] < 10 && safeCoordinate[1] >= 0 && safeCoordinate[1] < 10 && !(safeZoneCoordinates.Any(x => x[0] == safeCoordinate[0] && x[1] == safeCoordinate[1])))
                            safeZoneCoordinates.Add(safeCoordinate);
                    }
                }
            }
            return safeZoneCoordinates;
        }

        public static int[] GetRandomCoordinates()
        {
            Random rand = new Random();
            int[] randomHeadCoordiantes = { rand.Next(10), rand.Next(10) };
            return randomHeadCoordiantes;
        }

        public static List<int[]> GetFullShipCoordinates(Ship ship, int[] headCoordinates)
        {
            List<int[]> fullCoordinatesList = new List<int[]>();
            for (int i = 0; i < ship.Size; i++)
            {
                int[] shipSegment = new int[2];
                if (ship.IsHorizontal)
                {
                    shipSegment[0] = headCoordinates[0];
                    shipSegment[1] = headCoordinates[1] + i;
                }
                else
                {
                    shipSegment[0] = headCoordinates[0] + i;
                    shipSegment[1] = headCoordinates[1];
                }
                fullCoordinatesList.Add(shipSegment);
            }
            return fullCoordinatesList;
        }

        public static List<int[]> GetFullCoordinatesFromShipHead(Ship ship, Space space, int i)
        {
            int[] coordinates = { -1, -1 };

            bool correctAnswer = false;
            while (!correctAnswer)
            {
                UI.AskForPlacement(ship, i);
                coordinates = UI.GetPairCoordinates();


                if (Validation.IsAnswerValid(coordinates) && !Validation.IsThereAShip(space, ship, coordinates))
                {
                    correctAnswer = true;
                }
                else
                {
                    UI.PrintMessage("Please enter valid coordinates. You are too close!");
                }
            }
            return Handler.GetFullShipCoordinates(ship, coordinates);
        }
    }


}
