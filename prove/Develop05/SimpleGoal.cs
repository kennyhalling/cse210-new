public class SimpleGoal : Goal{
    private bool _completed;
    private string _status;

    public SimpleGoal(string name, string description, int points):base(name,description,points){
        _completed = false;
        _status = "Incomplete";
    }
    public SimpleGoal(string name, string description, int points, string status):base(name,description,points){
        _status = status;
        if (_status == "Completed" || status == "Abandoned"){
            _completed = true;
        }
        else{
            _completed = false;
        }
    }
    public override string RecordEvent(){
        if (_completed){
            Console.Clear();
            Console.WriteLine(@"
            This goal was already completed!");
            return "";
        }
        else{
            Console.Write(@"
            How are you doing with this goal?
            1. Completed!
            2. Still working on it
            3. I can no longer do it
            Your choice: ");
            int _userChoice = int.Parse(Console.ReadLine());
            Console.Clear();
            if (_userChoice == 1){
                Console.WriteLine(@"
            Great work!");
                _completed = true;
                _status = IsComplete();
            }
            if (_userChoice == 2){
                Console.WriteLine(@"
            Alright, keep at it!");
            }
            if (_userChoice == 3){
                Console.WriteLine(@"
            Sorry to hear that! Good luck on your next goal.");
                _status = IsComplete();
            }
            return _status;
        }
    }
    public override string IsComplete(){
        if (_completed){
            return "Completed";
        }
        else{
            return "Abandoned";
        }
    }
    public override string ExtractData(){
        return $"{GetName()}: Simple,{GetDescription()},{GetPoints()},{_status}";
    }
}