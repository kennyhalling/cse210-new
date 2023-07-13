public class Activity{
    private string _name;
    private string _startingMessage;
    private string _endingMessage;
    private double _duration;
    private double _cycles;
    private string _description;

    public Activity(string name, string description){
        _name = name;
        _description = description;
        DisplayStartingMessage();
        _endingMessage = @$"
        Great job. We're happy to have helped with your mentality.
        You just completed doing the {_name} for {_duration} seconds.";
        
    }

    private void DisplayStartingMessage(){
        Console.Clear();
        _startingMessage = @$"
        We will now being the {_name}.
        {_description}";
        Console.WriteLine(_startingMessage);
        Console.Write(@"
        How long would you like to do this activity for (in seconds)?: ");
        _duration = int.Parse(Console.ReadLine());
    }

    public double DivyTime(double cycleLength){
        _duration = Math.Round(_duration/cycleLength)*cycleLength;
        _cycles = _duration/cycleLength;
        return _cycles;
    }

    public void DisplayEndingMessage(){
        Console.WriteLine(_endingMessage);
        Thread.Sleep(5000);
    }
    
    public void Countdown(double duration){
        while (duration != 0){
            Console.Write(duration);
            Thread.Sleep(1000);
            Console.Write("\b\b");
            Console.Write(" ");
            Console.Write("\b\b");
            duration -= 1;
        }

    }

    public void Loading(double duration){
        for (int i = 0; i < duration; i++){
            Console.Write("|");
            Thread.Sleep(125);
            Console.Write("\b\b");
            Console.Write("/");
            Thread.Sleep(125);
            Console.Write("\b\b");
            Console.Write("-");
            Thread.Sleep(125);
            Console.Write("\b\b");
            Console.Write("""\""");
            Thread.Sleep(125);
            Console.Write("\b\b");
            Console.Write("|");
            Thread.Sleep(125);
            Console.Write("\b\b");
            Console.Write("/");
            Thread.Sleep(125);
            Console.Write("\b\b");
            Console.Write("-");
            Thread.Sleep(125);
            Console.Write("\b\b");
            Console.Write("""\""");
            Thread.Sleep(125);
            Console.Write("\b\b");
            Console.Write(" ");
            Console.Write("\b\b");
        }
    }
}