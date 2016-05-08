using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Test
{
    class RobotControls
    {
        public static string[] PlaceRobotOnGrid(string[] table, int x, int y, string direction)
        {
            int arrayToGrid = 0;

            arrayToGrid = ((x * 5) + y);

            if (!(arrayToGrid > 24))
            {
                table[arrayToGrid] = direction.Substring(0, 1);
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
