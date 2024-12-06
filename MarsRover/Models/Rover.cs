using System.Threading.Channels;

namespace MarsRover;

public class Rover
{
    public int Id { get; set; }
    public Position position { get; set; }

    public Rover(Position position)
    {
        this.position = position;
    }

}
