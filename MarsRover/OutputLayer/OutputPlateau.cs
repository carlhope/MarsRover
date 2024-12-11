using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class OutputPlateau(Plateau plateau)
    {
        public void DisplayCurrentStatus(Position position)
        {
            System.Console.WriteLine("Direction: "+position.Direction);
            for (int x = 0; x < plateau.Grid.GetLength(0); x++)
            {

                for (int y = 0; y < plateau.Grid.GetLength(1); y++)
                {
                    string line = "";
                    if (plateau.IsPositionEmpty(x, y))
                    {

                        line += " - ";

                    }
                    else
                    {

                        line += "X";
                    }
                    Console.Write(line);
                }
                Console.WriteLine();

            }
            Console.WriteLine("\n");
        }
    }
}
