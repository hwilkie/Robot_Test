using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // storage
            string[] myTable = new string[25];
            int currentCell = 0;
            string currentDirection = "EAST";

            IntroMessage();
            myTable = RobotControls.PlaceRobotOnGrid(myTable, 0, 3, ref currentCell, ref currentDirection);
            //RobotControls.ReadInput();
            RobotOutput.OutputGrid(myTable);
            myTable = RobotControls.MoveRobot(myTable, ref currentCell, currentDirection);
            RobotOutput.OutputGrid(myTable);

            Console.ReadKey();
            
        }


        static void IntroMessage()
        {
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Hugh Wilkie - Robot Test - Sun 8 May, 2.32 pm");
            sb.AppendLine();
            sb.AppendLine("Controls");
            sb.AppendLine("PLACE - places the robot at the x,y,direction point on the table");
            sb.AppendLine("MOVE -  moves the robot forward one cell in the direction that it is facing");
            sb.AppendLine("LEFT - turns the robot to the left");
            sb.AppendLine("RIGHT - turns the robot to the left");
            sb.AppendLine("REPORT - finishes the input sequence and provides output");
            sb.AppendLine();
            Console.Write(sb.ToString());
        }



    }
}
