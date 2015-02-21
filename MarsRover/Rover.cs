namespace MarsRover
{
    public class Rover : IRover
    {
        private RoverPosition _currentPosition;

        public Rover(RoverPosition landingPosition)
        {
            _currentPosition = landingPosition;
        }

        public RoverPosition Position
        {
            get { return _currentPosition; }
        }
     
        public void TurnLeft()
        {
            _currentPosition = new RoverPosition(Position.Platform,Position.Coordinate, Position.GetYourLeftHeading());
        }

        public void TurnRight()
        {
            _currentPosition = new RoverPosition(Position.Platform, Position.Coordinate, Position.GetYourRightHeading());
        }

        public void Move()
        {
            _currentPosition = new RoverPosition(Position.Platform, Position.GetForwardCoordinate(), Position.Heading);
        }
    }

    public interface IRover
    {
        RoverPosition Position { get; }
        void TurnLeft();
        void TurnRight();
        void Move();
    }
}
