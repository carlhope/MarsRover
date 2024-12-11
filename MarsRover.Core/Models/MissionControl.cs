using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class MissionControl
    {

        public List<Rover> Rovers { get; set; }
        public Plateau Plateau { get; set; }

        public MissionControl(Plateau plateau)
        {
            Rovers = new List<Rover>();
            Plateau = plateau;
        }

        public void IsRoverInList(Rover rover)
        {
            if (Rovers.Contains(rover))
            {
                rover = Rovers.Where(r => r.Id == rover.Id).First();

            }
            else
            {
                if (Plateau.IsPositionEmpty(rover.position.X, rover.position.Y))
                {
                    Rovers.Add(rover);
                }
                else
                {
                    Console.WriteLine("starting position currently occupied");
                    throw new Exception("position already occupied");
                }
            }
        }

        public void Navigate(List<Instructions> instructions, Rover rover)
        {

            IsRoverInList (rover);

            var pos = rover.position;
            if (Plateau.IsPositionEmpty(pos.X, pos.Y) == false) throw new Exception("Position occupied");
            else Plateau.Grid[pos.X, pos.Y] = rover.Id.ToString();
            DisplayCurrentStatus();
            var startPositionX = pos.X;
            var startPositionY = pos.Y;
            Plateau.Grid[pos.X,pos.Y]=null;
            foreach (Instructions instruction in instructions) 
            {
                //var start = rover.position;
                int startX = rover.position.X;
                int startY = rover.position.Y;
                int num = (int)pos.Direction;
                //if L or R, change direction
                if (instruction == Instructions.L) num--;
                if (instruction == Instructions.R) num++;
                pos.Direction = (CompassDirections)num;
                bool movedPosition = false;
                if (instruction == Instructions.M)
                {
                    //else if M, Move forward
                    //if direction north, parent array --
                    if (pos.Direction == CompassDirections.N &&(pos.X-1)>= 0 && Plateau.IsPositionEmpty(pos.X - 1, pos.Y)) pos.X--; 

                    //if direction south, parent array ++
                    else if (pos.Direction == CompassDirections.S  && (pos.X + 1) < Plateau.Grid.GetLength(0) && Plateau.IsPositionEmpty(pos.X + 1, pos.Y)) pos.X++; 
                    //if direction east, nested array --
                    else if (pos.Direction == CompassDirections.E  &&(pos.Y-1)>=0 && Plateau.IsPositionEmpty(pos.X, pos.Y - 1)) pos.Y--; 
                    //if direction west, nested array ++
                    else if (pos.Direction == CompassDirections.W  &&(pos.Y+1)<Plateau.Grid.GetLength(1) && Plateau.IsPositionEmpty(pos.X, pos.Y + 1)) pos.Y++;
                    else System.Console.WriteLine("nothing triggered");
                    
                }
                rover.position = pos;
                DisplayCurrentStatus();

            }

            Plateau.Grid[startPositionX, startPositionY] = null;
            Plateau.Grid[pos.X, pos.Y] = rover.Id.ToString();
            System.Console.WriteLine((startPositionX+" "+startPositionY));
            System.Console.WriteLine(pos.X+" "+pos.Y+"");
            System.Console.WriteLine(pos.Direction);
            DisplayCurrentStatus();

            

        }

        public void DisplayCurrentStatus() 
        {
            
            for (int x = 0; x < Plateau.Grid.GetLength(0); x++) {

                for (int y = 0; y < Plateau.Grid.GetLength(1); y++)
                {
                    string line = "";
                    if (Plateau.IsPositionEmpty(x, y))
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
