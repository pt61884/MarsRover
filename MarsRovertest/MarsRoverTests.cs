﻿using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRovertest
{
    [TestClass]
    public class MarsRoverTests
    {
        [TestInitialize]
        public void Setup()
        {
            Rover.Instance.Reset();
        }

        [TestMethod]
        public void FollowCommandScenario1_ProvidedCommand_FollowedCorrectly()
        {

            //5 5
            //1 2 N
            //LMLMLMLMM
            //3 3 E
            //MMRMMRMRRM
            // 
            //Expected Output:
            //1 3 N
            //5 1 E
            var rightUpperCorCoordinate = new Coordinate(5,5);
            var bottomLeftCorCoordinate = new Coordinate(0,0);

            var plateau = new Plateau(bottomLeftCorCoordinate, rightUpperCorCoordinate);
            
            var lastPostion = new RoverPosition(plateau,new Coordinate(1,2),Heading.North);
            var rover = Rover.Instance;
            rover.Position = lastPostion;
            ICommandFactory factory= new CommandFactory();
            const string commandText = "LMLMLMLMM";
            var commands = factory.CreateCommands(commandText,rover);

            foreach (var command in commands)
            {
                command.Execute();
            }

            var roverPosition = rover.Position;
            //1 3 N

            Assert.AreEqual(roverPosition.Coordinate.X,1);
            Assert.AreEqual(roverPosition.Coordinate.Y,3);
            Assert.AreEqual(roverPosition.Heading,Heading.North);
        }


        [TestMethod]
        public void FollowCommandScenario2_ProvidedCommand_FollowedCorrectly()
        {
            //5 5
            //1 2 N
            //LMLMLMLMM
            //3 3 E
            //MMRMMRMRRM
            // 
            //Expected Output:
            //1 3 N
            //5 1 E
            var rightUpperCorCoordinate = new Coordinate(5, 5);
            var bottomLeftCorCoordinate = new Coordinate(0, 0);

            var plateau = new Plateau(bottomLeftCorCoordinate, rightUpperCorCoordinate);
            var lastPosition = new RoverPosition(plateau, new Coordinate(3, 3), Heading.East);
            var rover = Rover.Instance;
            rover.Position = lastPosition;

            ICommandFactory factory = new CommandFactory();
            const string commandText = "MMRMMRMRRM";
            var commands = factory.CreateCommands(commandText, rover);

            foreach (var command in commands)
            {
                command.Execute();
            }

            var roverPosition = rover.Position;
            //5 1 E

            Assert.AreEqual(roverPosition.Coordinate.X, 5);
            Assert.AreEqual(roverPosition.Coordinate.Y, 1);
            Assert.AreEqual(roverPosition.Heading, Heading.East);
        }
    }
}
