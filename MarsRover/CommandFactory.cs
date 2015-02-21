using System.Collections.Generic;

namespace MarsRover
{
    public class CommandFactory : ICommandFactory
    {
        public IRoverCommand[] CreateCommands(string commandText, IRover rover)
        {
            var commandChars = commandText.ToCharArray();
            var commands= new List<IRoverCommand>();

            foreach (var commandChar in commandChars)
            {
                switch (commandChar)
                {
                    case 'L':
                        commands.Add(new TurnLeftCommand(rover));
                        break;
                    case 'R':
                        commands.Add(new TurnRightCommand(rover));
                        break;
                    case 'M':
                        commands.Add(new MoveCommand(rover));
                        break;
                    default:
                        throw new NotSupportedCommandException(string.Format("Invalid command text with not suppoted car {0}",commandChar));

                }
            }

            return commands.ToArray();
        }
    }
}