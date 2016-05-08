using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            IntroMessage();
            RobotController();

        }

        static void RobotController()
        {
            // storage
            string[] myTable = new string[25];
            int currentCell = 0;
            string currentDirection = null;
            string nextInst = null;

            RobotOutput.OutputGrid(myTable);

            while (nextInst != "REPORT")
            {
                nextInst = Console.ReadLine();

                if (nextInst.Substring(0, 5) == "PLACE")
                {
                    int x;
                    int.TryParse(nextInst.Substring(6, 1), out x);
                    int y;
                    int.TryParse(nextInst.Substring(8, 1), out y);

                    validateInput(nextInst.Substring(0, 4));
                    myTable = RobotControls.PlaceRobotOnGrid(myTable, 0, 3, ref currentCell, ref currentDirection);
                }
                else if (nextInst.Substring(0, 4) == "MOVE"){
                    RobotControls.MoveRobot(myTable, ref currentCell, currentDirection);
                    
                }
                else if (nextInst.Substring(0, 4) == "LEFT") {
                    RobotControls.
                }
                else if (nextInst.Substring(0, 5) == "RIGHT")
                {

                }
                else if (nextInst.Substring(0, 6) == "REPORT")
                {
                    Console.WriteLine("REPOT GOES HERE");
                }

                
                RobotOutput.OutputGrid(myTable);
                myTable = RobotControls.MoveRobot(myTable, ref currentCell, currentDirection);
                RobotOutput.OutputGrid(myTable);

                string initialInput = Console.ReadLine();

                List<string> valid = validateInput(initialInput);

                if (valid.Count > 0)
                {
                    string command = valid[0];

                    currentDirection = valid[3];
                    RobotControls.PlaceRobotOnGrid(myTable, int.Parse(valid[1]), int.Parse(valid[2]), ref currentCell, ref currentDirection);
                }



                Console.Read();

            }

        public static List<string> validateInput(string input)
        {
            StringBuilder errorMessage = null;
            List<string> avaliableDirections = new List<string>() { "NORTH", "SOUTH", "EAST", "WEST" };
            List<string> avaliableCommands = new List<string>() { "PLACE", "LEFT", "RIGHT", "REPORT" };
            List<string> output = new List<string>();

            List<string> cmds = new List<string>(input.Split(' '));

            if (cmds.Count > 2)
            {
                Console.WriteLine("Invalid Place Statement");
                return null;
            }

            string command = cmds[0];
            string tail = cmds[1];
            string[] splitTail = tail.Split(',');

            string xStr = null;
            string yStr = null;
            string direction = null;

            if (splitTail.Count() == 3)
            {
                xStr = splitTail[0];
                yStr = splitTail[1];
                direction = splitTail[2];
            }
            else
            {
                Console.WriteLine("Invalid Place Statement");
                return null;

            }
            int x, y;


            if (!avaliableCommands.Contains(command))
                errorMessage.AppendLine("Command is invalid, please try again");

            if (command == "PLACE")
            {
                if (!int.TryParse(xStr, out x))
                    errorMessage.AppendLine("x value is invalid, please try again");
                else if (x > 5)
                    errorMessage.AppendLine("x value is invalid, please try again");
                if (!int.TryParse(yStr, out y))
                    errorMessage.AppendLine("y value is invalid, please try again");
                else if (y > 5)
                    errorMessage.AppendLine("y value is invalid, please try again");

                if (!avaliableDirections.Contains(direction))
                    errorMessage.AppendLine("direction value is invalid, please try again");
            }

            if (errorMessage == null)
            {
                output.Add(command);
                output.Add(xStr);
                output.Add(yStr);
                output.Add(direction);
                return output;
            }


            Console.WriteLine(errorMessage.ToString());

            return null;
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
