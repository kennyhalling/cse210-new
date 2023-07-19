using System.IO;

public class Menu{
    private int _userInput;
    private Dictionary<string, string[]> _enemyDictionary = new Dictionary<string, string[]>();
    private Dictionary<string, Enemy> _combatants = new Dictionary<string, Enemy>();
    private bool _active = true;
    private string[] _lines;

    public Menu(){

    }

    public void DisplayMenu(){
        Console.Clear();
        Console.Write(@"
            Hello! Thank you for using the Dungeons and Dragons combat interface! A few things to know about this app:
             - When presented with an list of options, please type in the list number corresponding with your choice, don't type 
             the actual option!
             - If you want to know what kind of enemies you can put in your battle, open up the 'enemies.txt' file! When 
             we ask you to enter an enemy's name, write the name as listed (but without any quotation marks if any!).
             - Most of the action will happen in the 'theBattle.txt' file, so you'll want to have that open.
             - This program is most useful when you have the D&D 'Monster Manual', where you can read about all the listed 
             creatures more in depth. If you don't have this book, then when you're asked a question you don't know the answer 
             to, just be creative! D&D is all about making up bizarre things on the spot. You can create 40 sided dice for a 
             creature to attack with for all this program cares.
            
            Press enter when you're ready to begin!   ");
            Console.ReadLine();
        CreateEnemyDictionary();
        while (_active){
            Console.Clear();
            Console.Write(@$"
            Welcome to the Dungeons and Dragons combat interface!
            What would you like to do?
            1. Make Combatant List
            2. Start Battle!
            3. Quit
            Your Choice: ");
            _userInput = int.Parse(Console.ReadLine());
            if (_userInput == 1){
                Console.Clear();
                CreateCombatantList();
            }
            else if (_userInput == 2){
                Console.Clear();
                Battle _fight = new Battle(_combatants);
                _fight.Battlefield();
            }
            else if (_userInput == 3){
                _active = false;
            }
            else{
                
            }
        }
    }
    public void CreateCombatantList(){
        bool _addCombatants = true;
        while (_addCombatants){
            Console.Write(@"
            Who would you like to add?:
            1. Normal Enemy
            2. Spellcasting Enemy
            3. Quit
            Your choice: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1){
                Console.Write(@"
            What is the enemy's name?: ");
                string _enemyName = Console.ReadLine();
                Console.Write(@"
            How many would you like to add?: ");
                string _enemyQuantity = Console.ReadLine();
                if (_enemyDictionary.ContainsKey(_enemyName)){
                    for (int i=1; i <= int.Parse(_enemyQuantity); i++){
                        List<string> _enemyValue = _enemyDictionary[_enemyName].ToList();
                        _enemyValue.Add("0");
                        NormalEnemy normalEnemy = new NormalEnemy(_enemyValue);
                        _combatants.Add($"{_enemyName} {i}", normalEnemy);
                    }
                }
                else{
                    Console.WriteLine(@"
            Sorry, this enemy doens't exist in our files!");
                    Thread.Sleep(2000);
                }
                Console.Clear();
            }
            else if (choice == 2){
                Console.Write(@"
            What is the enemy's name?: ");
                string _enemyName = Console.ReadLine();
                Console.Write(@"
            How many would you like to add?: ");
                string _enemyQuantity = Console.ReadLine();
                Console.Write(@"
            How many spell slots do they have?: ");
                string _spellSlots = Console.ReadLine();
                if (_enemyDictionary.ContainsKey(_enemyName)){
                    for (int i =1; i<= int.Parse(_enemyQuantity); i++){
                        List<string> _enemyValue = _enemyDictionary[_enemyName].ToList();
                        _enemyValue.Add(_spellSlots);
                        MagicEnemy magicEnemy = new MagicEnemy(_enemyValue);
                        _combatants.Add($"{_enemyName} {i}", magicEnemy);
                    }
                }
                else{
                    Console.WriteLine(@"
            Sorry, this enemy doens't exist in our files!");
                    Thread.Sleep(2000);
                }
                Console.Clear();
            }
            else if (choice == 3){
                Console.Clear();
                Console.WriteLine(@"
            Your final combatant list:");
                foreach (KeyValuePair<string, Enemy> entry in _combatants){
                    Console.Write(@$"
            {entry.Key}");
                }
                _addCombatants = false;
                Thread.Sleep(4000);
            }
            else{
                Console.WriteLine(@"
            Please enter the list number of the action you want to take!");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
    public void CreateEnemyDictionary(){
        _lines = System.IO.File.ReadAllLines("enemies.txt");
        foreach (string line in _lines){
            string[] _line = line.Split(",");
            _enemyDictionary.Add(_line[0].Trim('"'), _line);
        }
    }
    public void DisplayDictionary(){
        foreach (KeyValuePair<string, string[]> entry in _enemyDictionary){
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}