using System;

namespace MarsRover
{
    public class Reciver
    {
        private readonly CommandFactory _commandFactory;
        private readonly Rover _rover = Rover.Instance ;
        public Reciver(): this(new CommandFactory())
        { }
        public Reciver(CommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public bool RecieveCommand(string commandText)
        {
            try
            {
                var commands = _commandFactory.CreateCommands(commandText, _rover);
                foreach (var roverCommand in commands)
                {
                    roverCommand.Execute();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}