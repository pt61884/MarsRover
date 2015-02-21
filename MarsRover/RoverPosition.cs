namespace MarsRover
{
    public class RoverPosition
    {
        private readonly Plateau _platform;
        private readonly Coordinate _coordinate;
        private readonly Heading _heading;

        public RoverPosition(Plateau platform,Coordinate coordinate, Heading heading)
        {
            _platform = platform;

            if (!_platform.IsWithin(coordinate))
            {
                throw new OutSideRoverRangeException("The coordinate is outside the plateau.");
            }
            _coordinate = coordinate;
            _heading = heading;
        }

        public Coordinate Coordinate
        {
            get { return _coordinate; }
        }

        public Heading Heading
        {
            get { return _heading; }
        }

        public Plateau Platform
        {
            get { return _platform; }
        }

        public Heading GetYourLeftHeading()
        {
            switch (Heading)
            {
                case Heading.North:
                    return Heading.West;
                case Heading.South:
                    return Heading.East;
                case Heading.East:
                    return Heading.North;
                default:
                    return Heading.South;
            }
        }

        public Heading GetYourRightHeading()
        {
            switch (Heading)
            {
                case Heading.North:
                    return Heading.East;
                case Heading.South:
                    return Heading.West;
                case Heading.East:
                    return Heading.South;
                default:
                    return Heading.North;
            }
        }

        public Coordinate GetForwardCoordinate()
        {
            var xDelta =( Heading == Heading.East ? 1 : 0 ) - ( Heading == Heading.West ? 1 : 0);
            var yDelta = (Heading == Heading.North ? 1 : 0 ) - (Heading == Heading.South ? 1 : 0);
            
            return new Coordinate(Coordinate.X+xDelta,Coordinate.Y+yDelta);
        }
       
    }


    public enum Heading
    {
        East, West, North, South
    }

    public struct Coordinate
    {
        private readonly int _x;
        private readonly int _y;

        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
        }
        public int Y
        {
            get { return _y; }
        }
    }
}