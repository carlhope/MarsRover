namespace MarsRover.Tests;

public class MissionControlTest
{
    public MissionControl mc { get; set; }
    [SetUp]
    public void Setup()
    {
        //plateau setup
        PlateauSize plateauSize = new PlateauSize(5, 5);
        Plateau plateau = new Plateau(plateauSize);
        //Mission control setup
        mc = new MissionControl(plateau);
        //initial rover
        Position position = new Position(0, 0, CompassDirections.S);
        Rover rover = new Rover(position);
        rover.Id = 1;
        List<Instructions> instructions = new List<Instructions>();
        mc.Navigate(instructions, rover);


    }

    [Test]
    public void Test1()
    {
        Position position = new Position(0, 0, 0);
        Rover rover2 = new Rover(position);
        rover2.Id = 2;
        Rover rover3 = new Rover(position);
        rover3.Id = 3;
        List<Instructions> instructions = new List<Instructions>();
        mc.Navigate(instructions, rover2);
        mc.Navigate(instructions, rover3);
        Assert.That(rover3.position, Is.EqualTo(position));
    }
}
