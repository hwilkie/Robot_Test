using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Test
{
    class RobotControls
    {
        public static string[] PlaceRobotOnGrid(string[] table, int x, int y, ref int currentCell, ref string currentDirection)
        {
            int arrayToGrid = 0;

            arrayToGrid = ((x * 5) + y);

            if (!(arrayToGrid > 24))
            {
                table[arrayToGrid] = currentDirection.Substring(0, 1);
                currentCell = arrayToGrid;
            }
                
            return table;
        }

        public static string[] MoveRobot(string[] table, ref int currentCell ,string currentDirection)
        {
            switch (currentDirection.ToUpper()) {
                case "NORTH":
                    if ((currentCell - 5) <= 0)
                    {
                        table[currentCell - 5] = table[currentCell];
                        table[currentCell] = null;
                    }
                    break;

                case "SOUTH":
                    if((currentCell + 5) <= 24)
                    {
                        table[currentCell + 5] = table[currentCell];
                        table[currentCell] = null;
                    }
                    break;

                case "EAST":
                    if ((currentCell + 1) % 5 != 0)
                    {
                        table[currentCell + 1] = table[currentCell];
                        table[currentCell] = null;
                    } else { Console.Write("CANNOT MOVE WILL FALL OFF TABLE"); }
                    break;

                case "WEST":
                    if ((currentCell - 1) % 5 == 0)
                    {
                        table[currentCell + 5] = table[currentCell];
                        table[currentCell] = null;
                    }
                    break;
            }

            return table;
        }


        // used for file input type
        public static List<string> ReadInput()
        {
            List<string> input = new List<string>();

            string userInput = "";

            while (userInput != "REPORT")
            {
                userInput = Console.ReadLine().ToUpper();

                input.Add(userInput);
            }

            foreach (var word in input)
            {
                Console.WriteLine(word);
            }

            return input;

        }

    }
}
