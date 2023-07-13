public class BreathingActivity : Activity{
    private List<string> _prompts;
    private double _cycles;
    private double _oneBreath = 5;

    public BreathingActivity(string name, string description):base(name, description){
        _prompts = new List<string>();
        _prompts.Add("Breathe in...");
        _prompts.Add("Breathe out...");
        _cycles = DivyTime(10.0);
    }

    public void RunBreathingActivity(){
        Console.Write(@"
        When you are read to begin, press 'Enter'.");
        Console.ReadLine();
        Console.Clear();
        for (int i=0; i <_cycles; i++){
            Console.WriteLine($"{_prompts[0]}");
            Countdown(_oneBreath);
            Console.Clear();
            Console.WriteLine($"{_prompts[1]}");
            Countdown(_oneBreath);
            Console.Clear();
        }
        DisplayEndingMessage();
    }
}