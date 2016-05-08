using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Test
{
    class RobotOutput
    {
        public void OutputGrid(string[] table)
        {
            int position = 0;

            string rowsplit = ("__________");

            Console.Write(rowsplit);

            foreach(var cell in table)
            {
                Console.Write(cell);
                Console.Write("|");
                if (position % 4 == 0)
                    Console.WriteLine(rowsplit);

                position++;
            }


        }


    }
}
