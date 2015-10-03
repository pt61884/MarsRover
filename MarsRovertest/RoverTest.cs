using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovertest
{
    [TestClass]
    public class RoverTest
    {
        [TestInitialize]
        public void Setup()
        {
            Rover.Instance.Reset();
        }

        [TestMethod]
        public void TurnLeft_Called_RoverTurnedLeft()
        {
            IRover rover= Rover.Instance;
            rover.Position = new RoverPosition(new Plateau(new Coordinate(0, 0), new Coordinate(5, 5)),
                new Coordinate(2, 3), Heading.North);
            rover.TurnLeft();
            Assert.AreEqual(Heading.West,rover.Position.Heading);
        }

        [TestMethod]
        public void TurnRight_Called_RoverTurnedRight()
        {
            IRover rover = Rover.Instance;
            rover.Position = new RoverPosition(new Plateau(new Coordinate(0, 0), new Coordinate(5, 5)),
                new Coordinate(2, 3), Heading.North);
            rover.TurnRight();
            Assert.AreEqual(Heading.East, rover.Position.Heading);
        }

        [TestMethod]
        public void Move_Called_RoverMoverOneStep()
        {
            IRover rover = Rover.Instance;
            rover.Position = new RoverPosition(new Plateau(new Coordinate(0, 0), new Coordinate(5, 5)),
                new Coordinate(2, 3), Heading.North);
            rover.Move();
            Assert.AreEqual(Heading.North, rover.Position.Heading);
            Assert.AreEqual(2,rover.Position.Coordinate.X);
            Assert.AreEqual(4,rover.Position.Coordinate.Y);
        }
    }
}