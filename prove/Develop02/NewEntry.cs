// NewEntry:
//   -Allows user to add an entry to a journal file
//   -Attributes:
//   -Behaviors:
//       -GetPrompt()

public class NewEntry
{
    public string GetPrompt()
        {Prompts prompt = new Prompts();
        string yourPrompt = prompt.GeneratePrompt(prompt._promptsList);    
       return yourPrompt;}
    
    public string GetInput()
    {return Console.ReadLine();}

    public string getDate()
    {DateTime currentTime = DateTime.Now;
    string dateText = currentTime.ToLongDateString();
    return dateText;}
}