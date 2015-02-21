using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovertest
{
    [TestClass]
    public class CommandFactoryTests
    {
        [TestMethod]
        public void CreateCommand_GivenCommandTextForSingleCommandL_ReturnsTheCorrectRoverCommandsCommands()
        {
            var commands = GetRoverCommands("L");
            Assert.IsTrue(commands[0] is TurnLeftCommand);
        }

        private static IRoverCommand[] GetRoverCommands(string commandText)
        {
            var commandfacrory = new CommandFactory();
            var coordinate = new Coordinate(0, 0);

            var commands = commandfacrory.CreateCommands(commandText,
                new Rover(new RoverPosition(new Plateau(coordinate, coordinate), coordinate, Heading.North)));
            return commands;
        }

        [TestMethod]
        public void CreateCommand_GivenCommandTextForSingleCommandR_ReturnsTheCorrectRoverCommandsCommands()
        {
            var commands = GetRoverCommands("R");
            Assert.IsTrue(commands[0] is TurnRightCommand);
        }

        [TestMethod]
        public void CreateCommand_GivenCommandTextForSingleCommandM_ReturnsTheCorrectRoverCommandsCommands()
        {
            var commands = GetRoverCommands("M");
            Assert.IsTrue(commands[0] is MoveCommand);
        }

        [TestMethod]
        public void CreateCommand_GivenCommandTextForSingleCommands_ReturnsTheCorrectRoverCommandsCommands()
        {
            var commands = GetRoverCommands("LMRL");

            Assert.IsTrue(commands[0] is TurnLeftCommand);
            Assert.IsTrue(commands[1] is MoveCommand);
            Assert.IsTrue(commands[2] is TurnRightCommand);
            Assert.IsTrue(commands[3] is TurnLeftCommand);
        }

        [TestMethod]
        [ExpectedException(typeof (NotSupportedCommandException))]
        public void CreateCommand_WithUnsupportedCommandText_ThrowsException()
        {
            GetRoverCommands("LMRK");
        }
    }
}