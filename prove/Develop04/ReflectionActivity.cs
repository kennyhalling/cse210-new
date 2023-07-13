public class ReflectionActivity : Activity{
    private List<string> _prompts;
    private List<string> _questions;
    private int _selection;
    private int _questionIndex;
    private double _cycles;

    public ReflectionActivity(string name, string description):base(name,description){
        _prompts = new List<string>{@"
        Think of a time when you stood up for someone else.",@"
        Think of a time when you served someone or your community.",@"
        Think of a time when you did something very difficult",@"
        Think of a time when you made someone happy.",@"
        Think of a time when you did something truly selfless."};
        _questions = new List<string>{@"
        Why is this experience meaningful to you?",@"
        Had you done anything like this before?",@"
        How did you feel afterwards?",@"
        How did you get started?",@"
        What made this time different from times you weren't as successful?",@"
        What was your favorite thing about this experience?",@"
        What could you take away from this experience that applies to other situations?",@"
        What things did you learn about yourself through this experience?",@"
        How can you remember this experience to help you outside of this activity?",@"
        Contiue reflecting on the questions above..."};
        _cycles = DivyTime(8.0);
    }

    public void RunReflectionActivity(){
        Console.Clear();
        Random rnd = new Random();
        _selection = rnd.Next(5);
        Console.WriteLine(@$"
        {_prompts[_selection]}");
        Console.Write(@"
        Take a moment to think, then press 'Enter' when you're ready to reflect.");
        Console.ReadLine();
        _questionIndex = 0;
        for (int i=0; i<_cycles; i++){
            if (_questionIndex < _questions.Count()){
                Console.WriteLine(@$"
                {_questions[_questionIndex]}");
                Loading(8);
                _questionIndex += 1;
            }
            else{
                Loading(8);
            }
        }
        DisplayEndingMessage();
    }
}