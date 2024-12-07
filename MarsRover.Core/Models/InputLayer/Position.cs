namespace MarsRover;

public class Position
{
// Perhaps these should be public auto-properties, perhaps private fields... 
//it's up to you!
	public int X {get; set;}
	public int Y {get; set;}
	public CompassDirections Direction {get; set;}

    public Position(int x, int y, CompassDirections facing)
    {
        X = x;
        Y = y;
        Direction = facing;
    }
    // this type can be whatever your direction enum is called




}
