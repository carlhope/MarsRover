namespace MarsRover.Tests;

public class InstructionsParserTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("","")]
    [TestCase("LRM", "LRM")]
    [TestCase("mrl", "MRL")]
    [TestCase("46423486458", "")]
    [TestCase("%&^$*£$&%*%$£", "")]
    [TestCase("kyjhianbfjd", "")]
    [TestCase("kdffmeidsr", "MR")]
    [TestCase("heki*%TriRLMmrl82uL", "RRLMMRLL")]

    public void Test1(string input, string expectedString)
    {
        //Arrange
        InstructionParser parser = new();
      
        //Act
        List<Instructions> actual = parser.ParseInstruction(input);
        string actualToString = "";
        foreach (Instructions instruction in actual) {
        var s = instruction.ToString();
            actualToString += s;
        }
        //Assert
        Assert.That(actualToString, Is.EqualTo(expectedString));
    }
}