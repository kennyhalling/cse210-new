// Prompts:
//   -Give a random prompt for the writer to use
//   -Attributes:
//       -_promptsList string
//   -Behaviors:
//       -GeneratePrompt()

public class Prompts
{
    public List<string> _promptsList = new List<string> 
        {"Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Where did you spend most of your day?",
        "What is one thing you wouldn't want to forget about today?",
        "What are you most grateful for today?",
        "How did you serve someone today?"
        };
    
    public string GeneratePrompt(List<string> prompts)
        {Random rnd = new Random();
        int listLength = prompts.Count;
        int promptIndex = rnd.Next(listLength);
        return prompts[promptIndex];}
}