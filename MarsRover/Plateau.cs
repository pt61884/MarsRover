namespace MarsRover
{
    public class Plateau
    {
        private readonly int _xMax;
        private readonly int _yMax;
        private readonly int _xMin;
        private readonly int _yMin;

        public Plateau(Coordinate bottomLeftCoordinate, Coordinate rightUpperCorCoordinate)
        {
            _xMax = rightUpperCorCoordinate.X;
            _yMax = rightUpperCorCoordinate.Y;
            _xMin = bottomLeftCoordinate.X;
            _yMin = bottomLeftCoordinate.Y;
        }

        public bool IsWithin(Coordinate coordinate)
        {
            return (coordinate.X > _xMin || coordinate.X == _xMin) && (coordinate.X < _xMax || coordinate.X == _xMax) &&
                   (coordinate.Y > _yMin || coordinate.Y == _yMin) && (coordinate.Y < _yMax || coordinate.Y == _yMax);
        }
    }
}