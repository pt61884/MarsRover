using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovertest
{
    [TestClass]
    public class CommandTest
    {
        [TestInitialize]
        public void Setup()
        {
            Rover.Instance.Reset();
        }

        [TestMethod]
        public void TestLeftCommand_GivenRover_TurnedLeftCorrectly()
        {
            var plataeu = new Plateau(new Coordinate(0,0), new Coordinate(5, 5));
            var landingPosition = new RoverPosition(plataeu, new Coordinate(2, 2), Heading.North);

            var rover = Rover.Instance;
            rover.Position = landingPosition;
            var turnLeftCommand = new TurnLeftCommand(rover);
            turnLeftCommand.Execute();
            Assert.AreEqual(rover.Position.Heading,Heading.West);
        }


        [TestMethod]
        public void TestRightCommand_GivenRover_TurnedRightCorrectly()
        {
            var plataeu = new Plateau(new Coordinate(0,0), new Coordinate(5, 5));
            var landingPosition = new RoverPosition(plataeu, new Coordinate(2, 2), Heading.North);

            var rover = Rover.Instance;
            rover.Position = landingPosition;

            var turnRightCommand = new TurnRightCommand(rover);
            turnRightCommand.Execute();
            Assert.AreEqual( Heading.East,rover.Position.Heading);

        }

        [TestMethod]
        public void TestMoveCommand_GivenRover_MovedCorrectly()
        {
            var plataeu = new Plateau(new Coordinate(0,0), new Coordinate(5, 5));
            var landingPosition = new RoverPosition(plataeu, new Coordinate(2, 2), Heading.North);

            var rover = Rover.Instance;
            rover.Position = landingPosition;
            var moveCommand = new MoveCommand(rover);
            moveCommand.Execute();
            Assert.AreEqual(rover.Position.Coordinate.X, 2);
            Assert.AreEqual(rover.Position.Coordinate.Y, 3);
            Assert.AreEqual(rover.Position.Heading, Heading.North);
        }
    }
}