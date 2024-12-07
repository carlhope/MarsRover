namespace MarsRover;

public class Plateau
{
public PlateauSize PlateauSize { get; set; }
public string[,] Grid {get; set;}

    public Plateau(PlateauSize plateauSize)
    {
        PlateauSize = plateauSize;
        var x = PlateauSize.X;
        var y = PlateauSize.Y;
        Grid = new string[x,y];
    }
    public bool IsPositionEmpty(int x, int y)
    {
        if (Grid[x,y] == null) return true;
        return false;
    }
}
