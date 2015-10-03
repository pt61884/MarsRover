using System;

namespace MarsRover
{
    public sealed class Rover : IRover
    {
        private RoverPosition _currentPosition;
        private static Rover _roverInstance = null;

        private static readonly Plateau MarsPlateau = new Plateau(new Coordinate(0,0), new Coordinate(5,5) );

        private static readonly RoverPosition LandingPosition = new RoverPosition(MarsPlateau, new Coordinate(0, 0), Heading.East);

        public static Rover Instance
        {
            get
            {
                return _roverInstance ?? (_roverInstance = new Rover(LandingPosition));
            }
        }

        private Rover(RoverPosition landingPosition)
        {
            _currentPosition = landingPosition;
        }

        public RoverPosition Position
        {
            get { return _currentPosition; }
            set { _currentPosition = value; }
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

        public void Reset()
        {
            _roverInstance = null;
        }
    }
}
