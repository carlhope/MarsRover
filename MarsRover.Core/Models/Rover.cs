using System.Threading.Channels;

namespace MarsRover;

public class Rover
{
    private static int count = 0;
    public int Id { get; set; }
    public Position position { get; set; }

    public Rover(Position position)
    {
        this.position = position;
        count++;
        Id = count;
    }

}
