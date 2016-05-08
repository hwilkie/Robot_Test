using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Test
{
    class RobotOutput
    {
        public static void OutputGrid(string[] table)
        {
            int position = 1;

            foreach(var cell in table)
            {
                Console.Write("|");
                if (cell != null)
                    Console.Write(cell);
                else
                    Console.Write("_");

                if (position % 5 == 0)
                    Console.Write("|\n");
                
                position++;
            }
            Console.WriteLine();

        }


    }
}
