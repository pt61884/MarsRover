using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovertest
{
    [TestClass]
    public class PlataeuTest
    {
        [TestMethod]
        public void IsWithinn_CalledWithWithinCoordinate_ReturnsTrue()
        {
            var plataeu = new Plateau(new Coordinate(5, 5), new Coordinate(0, 0));

            Assert.IsTrue(plataeu.IsWithin(new Coordinate(2,3)));
        }

        [TestMethod]
        public void IsWithinn_CalledWithBeyondCoordinate_ReturnsFalse()
        {
            var plataeu = new Plateau(new Coordinate(5, 5), new Coordinate(0, 0));

            Assert.IsFalse(plataeu.IsWithin(new Coordinate(-2, 6)));
        }
    }
}