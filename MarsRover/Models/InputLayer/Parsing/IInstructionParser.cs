using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models.InputLayer.Parsing
{
    public interface IInstructionParser
    {
        public List<Instructions> ParseInstruction(string instruction);
    }
}
