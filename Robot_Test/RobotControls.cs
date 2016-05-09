using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Test
{
    public class RobotControls
    {
        public static string[] PlaceRobotOnGrid(string[] table, int x, int y, ref int currentCell, ref string currentDirection)
        {
            int arrayToGrid = 0;

            if (x >= 0 && x <= 4)
                if (y >= 0 && y <= 4) {

                    arrayToGrid = ((x * 5) + y);

                    table[currentCell] = null;

                    if (!(arrayToGrid > 24))
                    {
                        table[arrayToGrid] = currentDirection.Substring(0, 1);
                        currentCell = arrayToGrid;
                    }
                }

            return table;
        }

        public static string[] MoveRobot(string[] table, ref int currentCell ,string currentDirection)
        {
            switch (currentDirection.ToUpper()) {
                case "NORTH":
                    if ((currentCell + 5) <= 24)
                    {
                        table[currentCell + 5] = table[currentCell];
                        table[currentCell] = null;
                        currentCell = currentCell + 5;
                    }
                    break;

                case "SOUTH":
                    if((currentCell - 5) >= 0)
                    {
                        table[currentCell - 5] = table[currentCell];
                        table[currentCell] = null;
                        currentCell = currentCell - 5;
                    }
                    break;

                case "EAST":
                    if ((currentCell + 1) % 5 != 0)
                    {
                        table[currentCell + 1] = table[currentCell];
                        table[currentCell] = null;
                        currentCell = currentCell + 1;
                    }
                    break;

                case "WEST":
                    if ((currentCell - 1) % 5 == 0)
                    {
                        table[currentCell + 5] = table[currentCell];
                        table[currentCell] = null;
                        currentCell = currentCell - 1;
                    }
                    break;
            }

            return table;
        }

        public static string[] TurnRobot(string[] table, int currentCell, ref string currentDirection, string turnDirection)
        {


            switch (currentDirection) {

                case "NORTH":
                    if (turnDirection == "LEFT")
                        currentDirection = "WEST";
                    else
                        currentDirection = "EAST";
                    break;

                case "WEST":
                    if (turnDirection == "LEFT")
                        currentDirection = "SOUTH";
                    else
                        currentDirection = "NORTH";
                    break;

                case "SOUTH":
                    if (turnDirection == "LEFT")
                        currentDirection = "EAST";
                    else
                        currentDirection = "WEST";
                    break;

                case "EAST":
                    if (turnDirection == "LEFT")
                        currentDirection = "NORTH";
                    else
                        currentDirection = "SOUTH";
                    break;
            }

            table[currentCell] = currentDirection.Substring(0, 1);
            return table;
        }
    }
}
