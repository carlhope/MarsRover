namespace MarsRover;

public class InstructionParser
{
    public List<Instructions> InstructionsList = new List<Instructions>();
    
    public void ParseInstruction(string instruction){
        instruction.ToUpper();
        char[] chars = instruction.ToCharArray();
        foreach(char c in chars){
            if(c is instruction i){

                InstructionsList.Add(i);
            }

        }
        
    }
}
