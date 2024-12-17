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
            
            PlateauSize size = new PlateauSize(5,5);
            Plateau plateau = new Plateau(size);
            Position position = new Position(0, 0, 0);
            OutputPlateau output = new OutputPlateau(plateau);
            Rover rover = new Rover(position);
            MissionControl mc = new MissionControl(plateau);
            InstructionParser parser = new InstructionParser();
            output.DisplayCurrentStatus(position);
            while (true)
            {
                Console.WriteLine("Enter your instructions");
                Console.WriteLine("L for Left turn");
                Console.WriteLine("R for right turn");
                Console.WriteLine("M for move forward");
                Console.WriteLine("Q to Quit");
                string input = Console.ReadLine();


                //initialise game
                
                if (input.ToUpper() == "Q") break;
                List<Instructions> instructions = parser.ParseInstruction(input);

                //process result
                var result = mc.Navigate(instructions, rover);
                output.DisplayCurrentStatus(result);

            }
        }
    }
}
