namespace MarsRover;

public class Position
{
// Perhaps these should be public auto-properties, perhaps private fields... 
//it's up to you!
	public int X {get; set;}
	public int Y {get; set;}
	public CompassDirection Facing {get; set;}
	// this type can be whatever your direction enum is called
}
