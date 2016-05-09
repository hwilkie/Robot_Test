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
            int x = 0, y = 0;
            string currentDirection = null;
            string nextInst = null;

            bool showTable = false;
            bool placed = false;

            // show table?
            Console.WriteLine("Would you like to see the table? (Y/N)");
            string ans = Console.ReadLine();
            if(ans.ToUpper() == "Y") 
                showTable = true;

             

            while (nextInst != "REPORT")
            {
                nextInst = Console.ReadLine();
                nextInst = nextInst.ToUpper();

                List<string> validInput = validateInput(nextInst);

                if (validInput != null)
                {
                    if (validInput.Count == 4)
                    {
                        x = int.Parse(validInput[1]);
                        y = int.Parse(validInput[2]);
                        currentDirection = validInput[3];
                    }
                    if (validInput[0].ToUpper() == "PLACE")
                    {
                        myTable = RobotControls.PlaceRobotOnGrid(myTable, x, y, ref currentCell, ref currentDirection);
                        placed = true;
                    }
                    if (placed)
                    {
                        if (validInput[0].ToUpper() == "MOVE")
                        {
                            RobotControls.MoveRobot(myTable, ref currentCell, currentDirection);
                        }
                        else if (validInput[0].ToUpper() == "LEFT")
                        {
                            RobotControls.TurnRobot(myTable, currentCell, ref currentDirection, "LEFT");
                        }
                        else if (validInput[0].ToUpper() == "RIGHT")
                        {
                            RobotControls.TurnRobot(myTable, currentCell, ref currentDirection, "RIGHT");
                        }
                        else if (validInput[0].ToUpper() == "REPORT")
                        {
                            int xReport = currentCell % 5;
                            int yReport = currentCell / 5;

                            Console.WriteLine(xReport + "," + yReport + "," + currentDirection);
                        } 
                    }
                    
                    if (showTable && validInput[0].ToUpper() != "REPORT")
                        RobotOutput.OutputGrid(myTable);

                    validInput.Clear();
                }
            }
            Console.Read();

        }

        public static List<string> validateInput(string input)
        {
            StringBuilder errorMessage = new StringBuilder();
            List<string> avaliableDirections = new List<string>() { "NORTH", "SOUTH", "EAST", "WEST" };
            List<string> avaliableCommands = new List<string>() { "PLACE", "LEFT", "RIGHT", "MOVE", "REPORT" };
            List<string> output = new List<string>();

            List<string> cmds = new List<string>(input.Split(' '));

            if (!avaliableCommands.Contains(cmds[0].ToUpper()))
            {
                errorMessage.AppendLine("Command is invalid, please try again");
                return null;
            }
            else if (input.Contains(" "))
            {
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

                if (!int.TryParse(xStr, out x))
                    errorMessage.AppendLine("x value is invalid, please try again");
                else if (x > 4)
                    errorMessage.AppendLine("x value is invalid, please try again");
                if (!int.TryParse(yStr, out y))
                    errorMessage.AppendLine("y value is invalid, please try again");
                else if (y > 4)
                    errorMessage.AppendLine("y value is invalid, please try again");
                else if (!avaliableDirections.Contains(direction.ToUpper()))
                    errorMessage.AppendLine("direction is invalid, please try again");

                if (errorMessage.ToString() == "")
                {
                    output.Add(command);
                    output.Add(xStr);
                    output.Add(yStr);
                    output.Add(direction.ToUpper());
                    return output;
                }
                else
                {
                    Console.WriteLine(errorMessage.ToString());
                    return null;
                }
            }
            output.Add(input);
            return output;
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
