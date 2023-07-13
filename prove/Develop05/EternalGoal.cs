public class EternalGoal : Goal{
    private bool _doneToday;
    private string _status;


    public EternalGoal(string name, string description, int points):base(name,description,points){
        _doneToday = false;
        _status = "Not Done Today";
    }
    public override string RecordEvent(){
        Console.Write(@"
            Have you accomplished this goal today?
            1. Yes
            2. Not yet
            Your choice: ");
        int _userChoice = int.Parse(Console.ReadLine());
        Console.Clear();
        if (_userChoice ==1){
            _doneToday = true;
            Console.WriteLine(@"
            Great job!");
        }
        if (_userChoice ==2){
            Console.WriteLine(@"
            Alright, keep at it!");
        }
        _status = IsComplete();
        return _status;
    }
    public override string IsComplete(){
        if (_doneToday){
            return "Done!";
        }
        else{
            return "Not Done Today";
        }
    }
    public override string ExtractData(){
        return $"{GetName()}: Eternal,{GetDescription()},{GetPoints()},{_status}";
    }
}