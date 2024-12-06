using MarsRover.Models.InputLayer.Parsing;
using Moq;

namespace MarsRover.Tests;

public class RoverTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("", 2, 2, 1, TestName = "Empty string, should return start position")]
    [TestCase("9854&%^fdiendUV", 2, 2, 1, TestName = "no matching chars")]
    [TestCase("LRM", 2, 2, 1, TestName = "all upper")]
    [TestCase("mrl", 2, 3, 1, TestName = "all lower")]
    [TestCase("MMM",2,3,1, TestName = "Test out of bounds X")]
    [TestCase("L", 2, 2, 0, TestName = "This will be only passing test when using Moq")]
    public void Navigate(string instructions, int expectedX, int expectedY, int ExpectedD)
    {
        //change this to work with MissionControl

        //Arrange
        Position position = new Position(2, 2, CompassDirections.W);
        Rover rover = new Rover(position);
        PlateauSize size = new PlateauSize(4,4);
        Plateau plateau = new Plateau(size);
        MissionControl mc = new MissionControl(plateau);
        InstructionParser parser = new InstructionParser();
        //var parser = new Mock<IInstructionParser>();

        //Act
         var parsedData = parser.ParseInstruction(instructions);
        //parser.Setup(p => p.ParseInstruction(instructions)).Returns(new List<Instructions> { Instructions.L }); 
        //var parsedData = parser.Object.ParseInstruction(instructions);
        mc.Navigate(parsedData, rover);

        //rover.FollowInstruction(instructions);
        //Assert
        Assert.That(rover.position.Y, Is.EqualTo(expectedY));
        Assert.That(rover.position.X, Is.EqualTo(expectedX));
        Assert.That(rover.position.Direction, Is.EqualTo((CompassDirections)ExpectedD));
        //parser.Verify(p=>p.ParseInstruction(instructions), Times.Once);
    }
}
