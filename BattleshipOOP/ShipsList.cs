using System;
using System.Collections.Generic;
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

        public ShipsList()
        {

        }

        private void AddShip(string shipType, bool horizontal)
        {
            Ships.Add(new Ship(shipType, horizontal));
        }

        public void PopulatePlayerShipsList(bool isRebellion, Space board)
        {
            Dictionary<string, int> workingFleet = (isRebellion) ? RebelShips : ImperialShips;
            foreach (var ship in workingFleet)
            {
                for (int i = 0; i < ship.Value; i++)
                {
                    Ship newShip = new Ship(ship.Key, UI.GetShipAlignment(ship.Key, i));
                    newShip.FullCoordinates = UI.GetFullCoordinatesFromShipHead(newShip, board, i);
                    newShip.SafeZoneCoordinates = UI.GetSafeZoneCoordinates(newShip); 
                    Ships.Add(newShip);

                    Square.UpdateShipSquaresOnBoard(board, newShip);
                    Square.UpdateShipSafeZoneOnBoard(board, newShip);
                    Console.Clear();
                    board.PrintBoard();
                }
            }
        }
    }
}
