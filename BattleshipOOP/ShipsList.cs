using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipOOP
{
    class ShipsList
    {
        public List<Ship> Ships = new List<Ship>();

        public static Dictionary<string, int> RebelShips = new Dictionary<string, int>
        {
            {"X-Wing", 4 },
            {"Millennium Falcon", 3 },
            {"Liberator", 2 },
            {"Nebulon-B2 Frigate", 1 }
        };

        public static Dictionary<string, int> ImperialShips = new Dictionary<string, int>
        {
            {"TIE Fighter", 4 },
            {"Destroyer", 3 },
            {"Dreadnaught", 2 },
            {"Deathstar", 1 }
        };

        public ShipsList() { }

        public Ship GetShipAtCoordinates(int[] coordinates)
        {
            foreach (Ship ship in Ships)
                if (ship.FullCoordinates.Any(x => x[0] == coordinates[0] && x[1] == coordinates[1]))
                    return ship;

            return null;
        }

        public void HitShip(int[] coordinates)
        {
            Ship hitShip = GetShipAtCoordinates(coordinates);
            hitShip.HitShip();
        }

        public void PopulatePlayerShipsList(bool isRebellion, Space board)
        {
            Dictionary<string, int> workingFleet = (isRebellion) ? RebelShips : ImperialShips;

            foreach (var ship in workingFleet)
            {
                for (int i = 0; i < ship.Value; i++)
                {
                    board.PrintBoard(true);
                    Ship newShip = (ship.Key == "X-Wing" || ship.Key == "TIE Fighter") ? 
                        new Ship(ship.Key) : new Ship(ship.Key, UI.GetShipAlignment(ship.Key, i));

                    newShip.FullCoordinates = UI.GetFullCoordinatesFromShipHead(newShip, board, i);
                    newShip.SafeZoneCoordinates = UI.GetSafeZoneCoordinates(newShip); 
                    Ships.Add(newShip);

                    Square.UpdateShipSquaresOnBoard(board, newShip);
                    Square.UpdateShipSafeZoneOnBoard(board, newShip);
                }
            }
        }

        public void AutomaticShipListPopulation(bool isRebellion, Space board)
        {
            Dictionary<string, int> workingFleet = (isRebellion) ? RebelShips : ImperialShips;
            foreach (var ship in workingFleet)
            {
                for (int i = 0; i < ship.Value; i++)
                {
                    Ship newShip = new Ship(ship.Key, Ship.randomShipAlligment());

                    int[] randomHeadCoordinates = new int[2];

                    bool correctRandomHeadCoordiantes = false;
                    while (!correctRandomHeadCoordiantes)
                    {
                        randomHeadCoordinates = UI.RandomShipHeadCoordinates();
                        if (!Validation.IsThereAShip(board, newShip, randomHeadCoordinates))
                        {
                            correctRandomHeadCoordiantes = true;
                        }
                    }
                    newShip.FullCoordinates = UI.GetFullShipCoordinates(newShip, randomHeadCoordinates);
                    newShip.SafeZoneCoordinates = UI.GetSafeZoneCoordinates(newShip);
                    Ships.Add(newShip);

                    Square.UpdateShipSquaresOnBoard(board, newShip);
                    Square.UpdateShipSafeZoneOnBoard(board, newShip);
                }
            }
        }

    }
}
