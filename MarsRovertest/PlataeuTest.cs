using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovertest
{
    [TestClass]
    public class PlataeuTest
    {
        [TestInitialize]
        public void Setup()
        {
            Rover.Instance.Reset();
        }

        [TestMethod]
        public void IsWithinn_CalledWithWithinCoordinate_ReturnsTrue()
        {
            var plataeu = new Plateau(new Coordinate(0, 0), new Coordinate(5, 5));

            Assert.IsTrue(plataeu.IsWithin(new Coordinate(2,3)));
        }

        [TestMethod]
        public void IsWithinn_CalledWithBeyondCoordinate_ReturnsFalse()
        {
            var plataeu = new Plateau(new Coordinate(0, 0), new Coordinate(5, 5));

            Assert.IsFalse(plataeu.IsWithin(new Coordinate(-2, 6)));
        }
    }
}