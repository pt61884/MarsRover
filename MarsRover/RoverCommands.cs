namespace MarsRover
{

    public class MoveCommand : IRoverCommand
    {
        private readonly IRover _rover;

        public MoveCommand(IRover rover)
        {
            _rover = rover;
        }

        public void Execute()
        {
            _rover.Move();
        }
    }

    public class TurnRightCommand : IRoverCommand
    {
        private readonly IRover _rover;

        public TurnRightCommand(IRover rover)
        {
            _rover = rover;
        }

        public void Execute()
        {
            _rover.TurnRight();
        }
    }

    public class TurnLeftCommand : IRoverCommand
    {
        private readonly IRover _rover;

        public TurnLeftCommand(IRover rover)
        {
            _rover = rover;
        }

        public void Execute()
        {
            _rover.TurnLeft();
        }
    }

    public interface IRoverCommand
    {
        void Execute();
    }

    public interface ICommandFactory
    {
        IRoverCommand[] CreateCommands(string commandText, IRover rover);
    }

}
