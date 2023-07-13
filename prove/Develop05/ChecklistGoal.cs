public class ChecklistGoal : Goal{
    private int _goalAmount;
    private int _currentAmount;
    private int _checks;
    private bool _completed;


    public ChecklistGoal(string name, string description, int points, int currentAmount, int goalAmount):base(name,description,points){
        _currentAmount = currentAmount;
        _goalAmount = goalAmount;
        if (_currentAmount >= _goalAmount){
            _completed = true;
        }
        else{
            _completed = false;
        }
    }
    public string CalculatePoints(){
        if (_goalAmount > _currentAmount){
            int points = _checks*GetPoints();
            return $"{points}";
        }
        else if (_goalAmount <= _currentAmount){
            int points = _checks*GetPoints() + (GetPoints()*10);
            return $"{points}";
        }
        else{
            return "";
        }
    }
    public override string RecordEvent(){
        if (_completed){
            Console.Clear();
            Console.WriteLine(IsComplete());
            return "";
        }
        else{
            Console.Write(@"
            How many checks did you reach?: ");
            _checks = int.Parse(Console.ReadLine());
            _currentAmount += _checks;
            Console.Clear();
            if (_currentAmount >= _goalAmount){
                Console.WriteLine(@"
            You did it! Enjoy some bonus points!");
            }
            Console.WriteLine(@"
            Keep up the good work!");
            return $"{_currentAmount}";
        }
    }
    public override string IsComplete(){
        return @"
            This goal has already been completed!";
    }
    public override string ExtractData(){
        return $"{GetName()}: Checklist,{GetDescription()},{GetPoints()},{_currentAmount},{_goalAmount}";
    }
}