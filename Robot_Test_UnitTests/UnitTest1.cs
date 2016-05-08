using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot_Test;

namespace Robot_Test_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValidMove()
        {
            int currentCell = 2;

            string[] table = new string[25];
            table[2] = "N";

            string[] expected = new string[25];
            expected[7] = "N";

            string[] actual = RobotControls.MoveRobot(table, ref currentCell, "NORTH");

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestInvalidMove()
        {
            int currentCell = 2;

            string[] table = new string[25];
            table[4] = "E";

            string[] expected = new string[25];
            expected[4] = "E";

            string[] actual = RobotControls.MoveRobot(table, ref currentCell, "EAST");

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestPlaceRobotOnGrid1()
        {
            int currentCell = 0;
            string currentDirection = "NORTH";

            string[] table = new string[25];

            string[] expected = new string[25];
            expected[0] = "N";

            string[] actual = RobotControls.PlaceRobotOnGrid(table, 0, 0, ref currentCell, ref currentDirection);

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestPlaceRobotOnGrid2()
        {
            int currentCell = 0;
            string currentDirection = "WEST";

            string[] table = new string[25];

            string[] expected = new string[25];
            expected[7] = "W";

            string[] actual = RobotControls.PlaceRobotOnGrid(table, 1, 2, ref currentCell, ref currentDirection);

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestInvalidPlaceRobotOnGrid1()
        {
            int currentCell = 0;
            string currentDirection = "NORTH";

            string[] table = new string[25];

            string[] expected = new string[25];

            string[] actual = RobotControls.PlaceRobotOnGrid(table, -2, 17, ref currentCell, ref currentDirection);

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestInvalidPlaceRobotOnGrid2()
        {
            int currentCell = 0;
            string currentDirection = "NORTH";

            string[] table = new string[25];

            string[] expected = new string[25];

            string[] actual = RobotControls.PlaceRobotOnGrid(table, 2, -17, ref currentCell, ref currentDirection);

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
