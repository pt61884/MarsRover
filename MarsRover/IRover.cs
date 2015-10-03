namespace MarsRover
{
    public interface IRover
    {
        RoverPosition Position { get; set; }
        void TurnLeft();
        void TurnRight();
        void Move();
    }
}