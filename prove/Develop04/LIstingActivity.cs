public class ListingActivity : Activity{
    private List<string> _categories;
    private List<string> _entries;
    private string _currentItem;
    private int _selection;
    private double _duration;
    private bool _active;
    private DateTime _endTime;
    private DateTime _currentTime;

    public ListingActivity(string name, string description):base(name,description){
        _categories = new List<string>{@"
        Who are people that you appreciate?",@"
        What are some small talents that you have?",@"
        Who have you helped this week?",@"
        Where are some Holy Places you often stand in?",@"
        Who are the people who love you?"};
        _entries = new List<string>();
        _duration = DivyTime(1);
        _active = true;
    }

    public void RunListingActivity(){
        Random rnd = new Random();
        _selection = rnd.Next(5);
        Console.WriteLine(@$"
        {_categories[_selection]}
        Think about this for a few seconds.");
        Countdown(9);
        _currentTime = DateTime.Now;
        _endTime = _currentTime.AddSeconds(_duration);;
        Console.WriteLine(@"
        Create your list below:");
        while (_active){
            _currentItem = Console.ReadLine();
            _entries.Add(_currentItem);
            _currentTime = DateTime.Now;
            if (_currentTime > _endTime){
                _active = false;
            };
        }
        Console.WriteLine(@$"
        You listed {_entries.Count()} things!");
        DisplayEndingMessage();
    }
}