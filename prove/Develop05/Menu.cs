using System.IO;

public class Menu{

    private string _userName;
    private string _filename;
    private string[] _lines;
    private Dictionary<string, string[]> _userData = new Dictionary<string, string[]>{};
    private int _currentPoints;
    private int _userInput;
    private bool active = true;

    public Menu(){

    }

    public void DisplayMenu(){
        Console.Clear();
        LoadUserData();
        Console.Clear();
        while (active){
            Console.Write(@$"
            Welcome {_userName}!
            What would you like to do?:
            1. Display Current Goals and Score
            2. Record Progress
            3. Add New Goal
            4. Change User
            5. Quit
            Your Choice: ");
            _userInput = int.Parse(Console.ReadLine());
            if (_userInput == 1){
                DisplayUserData();
                Thread.Sleep(3000);
            }
            if (_userInput == 2){
                RecordProgress();
            }
            if (_userInput == 3){
                AddGoal();
            }
            if (_userInput ==4){
                Console.Clear();
                LoadUserData();
                Console.Clear();
            }
            if (_userInput == 5){
                active = false;
                SaveUserData();
                Console.Clear();
            }
        }

    }
    private void LoadUserData(){
        Console.Write(@"
            Welcome to the Goal Tracker!
            Please enter your name: ");
        _userName = Console.ReadLine();
        _filename = $"{_userName}.txt";
        if (File.Exists(_filename)){
            WriteData();
        }
        else{
            using (StreamWriter outputfile = new StreamWriter(_filename)){
                outputfile.WriteLine("Current Points: 0");
            }
            WriteData();
        }
        void WriteData(){
            _userData = new Dictionary<string, string[]>{};
            _lines = System.IO.File.ReadAllLines(_filename);
            foreach (string line in _lines){
                string[] _line = line.Split(":");
                string[] _lineData = _line[1].Split(",");
                _userData.Add(_line[0], _lineData);
            }
        }
    }
    private void SaveUserData(){
        using (StreamWriter outputfile = new StreamWriter(_filename)){
            foreach (KeyValuePair<string, string[]> entry in _userData){
                outputfile.Write($"{entry.Key}:");
                outputfile.WriteLine("{0}", string.Join(",", entry.Value));
            }
        }
    }
    private void DisplayUserData(){
        Console.Clear();
        foreach (KeyValuePair<string, string[]> entry in _userData){
            if (entry.Key == "Current Points"){
                Console.WriteLine(@$"
            {entry.Key}: {entry.Value[0]}");
            }
            else if (entry.Value[0] == " Checklist"){
                Console.Write(@$"
            {entry.Key}: {entry.Value[1]}({entry.Value[2]} per check) ~ [{entry.Value[3]}/{entry.Value[4]}]");
            }
            else{  
                Console.Write(@$"
            {entry.Key}: {entry.Value[1]}({entry.Value[2]}) ~ {entry.Value[3]}");
            }
        }
        Console.WriteLine();
    }
    private void AddGoal(){
        Console.Clear();
        Console.Write(@"
            There are three types of goals you can make:
            1. Simple Goal ~ Something you want to accomplish once
            2. Eternal Goal ~ Something you want to be doing every day
            3. Checklist Goal ~ Something you want to do a certain number of times
            What kind of goal do you want to create?: ");
        int choice = int.Parse(Console.ReadLine());
        Console.Write(@"
            Describe your goal, what do you want to accomplish?: ");
        string goalDescription = Console.ReadLine();
        Console.Write(@"
            Name your goal!: ");
        string goalName = Console.ReadLine();
        if (choice == 1){
            Console.Write(@"
            How many points is this goal worth on completion?: ");
            int goalPoints = int.Parse(Console.ReadLine());
            SimpleGoal simple1 = new SimpleGoal(goalName, goalDescription, goalPoints);
            AppendDicitonary(simple1);
        }
        if (choice == 2){
            Console.Write(@"
            How many points should you get every day you keep with this goal?: ");
            int goalPoints = int.Parse(Console.ReadLine());
            EternalGoal eternal1 = new EternalGoal(goalName, goalDescription, goalPoints);
            AppendDicitonary(eternal1);
        }
        if (choice == 3){
            Console.Write(@"
            How many points should you get for each check?: ");
            int goalPoints = int.Parse(Console.ReadLine());
            Console.Write(@"
            How many checks do you want to reach?: ");
            int goalChecks = int.Parse(Console.ReadLine());
            ChecklistGoal checklist1 = new ChecklistGoal(goalName, goalDescription, goalPoints, 0, goalChecks);
            AppendDicitonary(checklist1);
        }
        SaveUserData();
        Console.Clear();
        void AppendDicitonary(Goal goal){
            string result = goal.ExtractData();
            string[] resultArray = result.Split(":");
            string[] data = resultArray[1].Split(",");
            _userData.Add(resultArray[0], data);
        }
    }
    private void RecordProgress(){
        DisplayUserData();
        Console.Write(@"
            Name of the goal you're reporting on: ");
        string key = Console.ReadLine();
        if (_userData.ContainsKey(key)){
            string[] keyValue = _userData[key];
            if (keyValue[0] == " Simple"){
                SimpleGoal simple2 = new SimpleGoal(key, keyValue[1], int.Parse(keyValue[2]), keyValue[3]);
                string status = simple2.RecordEvent();
                if (status != ""){
                    keyValue[3] = status;
                    if (keyValue[3] == "Completed"){
                        AssignPoints(keyValue[2]);
                    }
                }
            }
            else if (keyValue[0] == " Eternal"){
                EternalGoal eternal2 = new EternalGoal(key, keyValue[1], int.Parse(keyValue[2]));
                string status = eternal2.RecordEvent();
                keyValue[3] = status;
                if (keyValue[3] == "Done!"){
                    AssignPoints(keyValue[2]);
                }
                
            }
            else if (keyValue[0] == " Checklist"){
                ChecklistGoal checklist2 = new ChecklistGoal(key, keyValue[1], int.Parse(keyValue[2]), int.Parse(keyValue[3]), int.Parse(keyValue[4]));
                string status = checklist2.RecordEvent();
                if (status != ""){
                    keyValue[3] = status;
                    AssignPoints(checklist2.CalculatePoints());
                }
            }
        }
        else{
            Console.WriteLine(@"
            Goal not found.");
        }
        SaveUserData();
        Thread.Sleep(2000);
        void AssignPoints(string goalPoints){
            string[] points = _userData["Current Points"];
            _currentPoints = int.Parse(points[0]) + int.Parse(goalPoints);
            points[0] = $"{_currentPoints}";
        }
    }
}