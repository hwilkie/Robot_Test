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
            //int position = 0;

            //foreach(var cell in table)
            //{
            //    Console.Write("|");
            //    if (cell != null)
            //        Console.Write(cell);
            //    else
            //        Console.Write("_");

            //    if (position % 5 == 0)
            //        Console.Write("|\n");

            //    position++;
            //}
            //Console.WriteLine();

            int arrayIdx = 20;
            int col = 0;

            while (arrayIdx != -5)
            {
                for (col = 0; col < 5; col++)
                {
                    Console.Write("|");
                    if (table[arrayIdx + col] != null)
                        Console.Write(table[arrayIdx + col]);
                    else
                        Console.Write("_");
                }
                Console.Write("|\n");
                arrayIdx = arrayIdx - 5;
            }
            Console.WriteLine();
        }


    }
}
