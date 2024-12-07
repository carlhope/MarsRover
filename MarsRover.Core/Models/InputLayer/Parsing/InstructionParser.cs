using MarsRover.Models.InputLayer.Parsing;

namespace MarsRover;

public class InstructionParser : IInstructionParser
{
    
    
    public List<Instructions> ParseInstruction(string instruction){
    List<Instructions> InstructionsList = new List<Instructions>();
    instruction = instruction.ToUpper();
        char[] chars = instruction.ToCharArray();
        foreach(char c in chars){
            if(Enum.IsDefined(typeof(Instructions), c.ToString())){
                Instructions i = (Instructions)Enum.Parse(typeof(Instructions), c.ToString());
                InstructionsList.Add(i);
            }

        }
        return InstructionsList;
        
    }
}
