
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

        public Position Navigate(List<Instructions> instructions, Rover rover)
        {

            IsRoverInList (rover);

            var pos = rover.position;
            //throws error here. suspect its because starting position is occuppied by the currently playing rover. its checking starting position
            //needs changing to position rover will occupy
            
            var startPositionX = pos.X;
            var startPositionY = pos.Y;
            Plateau.Grid[pos.X,pos.Y]=rover.Id.ToString();
            foreach (Instructions instruction in instructions) 
            {
              
                int startX = rover.position.X;
                int startY = rover.position.Y;
                int num = (int)pos.Direction;
                //if L or R, change direction
                if (instruction == Instructions.L) num--;
                if (instruction == Instructions.R) num++;
                if (num >3) num = 0;
                if (num < 0) num = 3;
                pos.Direction = (CompassDirections)num;
                if (instruction == Instructions.M)
                {
                    
                    if (pos.Direction == CompassDirections.N &&(pos.X-1)>= 0 && Plateau.IsPositionEmpty(pos.X - 1, pos.Y)) pos.X--; 
                    else if (pos.Direction == CompassDirections.S  && (pos.X + 1) < Plateau.Grid.GetLength(0) && Plateau.IsPositionEmpty(pos.X + 1, pos.Y)) pos.X++;    
                    else if (pos.Direction == CompassDirections.E  &&(pos.Y-1)>=0 && Plateau.IsPositionEmpty(pos.X, pos.Y - 1)) pos.Y--; 
                    else if (pos.Direction == CompassDirections.W  &&(pos.Y+1)<Plateau.Grid.GetLength(1) && Plateau.IsPositionEmpty(pos.X, pos.Y + 1)) pos.Y++;
                }
                if (Plateau.IsPositionEmpty(pos.X, pos.Y) == false && Plateau.Grid[pos.X, pos.Y] != rover.Id.ToString()) throw new Exception("Position occupied");
               
            }
            Plateau.Grid[pos.X, pos.Y] = rover.Id.ToString();
            rover.position = pos;
            Plateau.Grid[startPositionX, startPositionY] = null;
            Plateau.Grid[pos.X, pos.Y] = rover.Id.ToString();


            return pos;

        }

        
    }
}
