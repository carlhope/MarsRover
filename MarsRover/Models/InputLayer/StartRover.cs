using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MarsRover.Models.InputLayer
{
    internal class StartRover
    {
        public void Play()
        {
            Random random = new Random();
            PlateauSize size = new PlateauSize(5,5);
            Plateau plateau = new Plateau(size);
            Position position = new Position(0, 0, 0);
            Rover rover = new Rover(position);
            rover.Id = random.Next(1,9999999);
            Console.WriteLine("Enter your instructions");
            Console.WriteLine("L for Left turn");
            Console.WriteLine("R for right turn");
            Console.WriteLine("M for move forward");
            string input = Console.ReadLine();
            MissionControl mc = new MissionControl(plateau);
            InstructionParser parser = new InstructionParser();
            List<Instructions> instructions = parser.ParseInstruction(input);
            mc.Navigate(instructions, rover);
        }
    }
}
