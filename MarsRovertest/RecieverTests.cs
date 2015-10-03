using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovertest
{
    [TestClass]
    public class RecsieverTests
    {
        [TestInitialize]
        public void Setup()
        {
            Rover.Instance.Reset();
        }

        [TestMethod]
        public void Recieve_ProvidedValidCommand_RecieveAndExecuteCommandSuccessfuly()
        {
            var reciver= new Reciver();
            const string command = "MMR";// Move, Move and Turn right

            var roverInitialPosition = Rover.Instance.Position;
            var recievedAndExecuted = reciver.RecieveCommand(command);
            Assert.IsTrue(recievedAndExecuted);
            Assert.AreNotEqual(roverInitialPosition.Coordinate,Rover.Instance.Position.Coordinate);
            Assert.AreNotEqual(roverInitialPosition.Heading,Rover.Instance.Position.Heading);
        }

        [TestMethod]
        public void Recieve_ProvidedInValidCommand_RecieveAndReturnFalse()
        {
            var reciver = new Reciver();
            const string command = "ABCD";// invalid command text

            var roverInitialPosition = Rover.Instance.Position;
            var recievedAndExecuted = reciver.RecieveCommand(command);
            Assert.IsFalse(recievedAndExecuted);
            // No change in the Rover position as the command was invalid, no execution of command.
            Assert.AreEqual(roverInitialPosition, Rover.Instance.Position);
        }

        [TestMethod]
        public void Recieve_ProvidedInValidCommandWithOutSideTheLimitMove_RecieveAndReturnFalse()
        {
            var reciver = new Reciver();
            const string command = "MMMMMMMMMMM"; // valid command text but out side limit move

            var recievedAndExecuted = reciver.RecieveCommand(command);

            Assert.IsFalse(recievedAndExecuted);
        }
    }
}
