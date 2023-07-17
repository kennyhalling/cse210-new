using System.IO;

public class Menu{
    private int _userInput;
    private Dictionary<string, string[]> _enemyDictionary = new Dictionary<string, string[]>();
    private Dictionary<string, int[]> _combatants = new Dictionary<string, int[]>();
    private bool _active = true;
    private string[] _lines;

    public Menu(){

    }

    public void DisplayMenu(){
        CreateEnemyDictionary();
        while (_active){
            Console.Clear();
            Console.Write(@$"
            Welcome to the Dungeons and Dragons combat interface!
            What would you like to do?
            1. Make Combatant List
            2. Start Battle!
            3. Append Enemy Dictionary
            4. Quit
            Your Choice: ");
            _userInput = int.Parse(Console.ReadLine());
            if (_userInput == 1){
                Console.Clear();
                CreateCombatantList();
            }
            else if (_userInput == 2){
                
            }
            else if (_userInput == 3){
                
            }
            else if (_userInput == 4){
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
            Console.WriteLine(choice);
            if (choice == 1){
                Console.Write(@"
                What is the enemy's name?: ")
                string _enemyName = Console.ReadLine()
                Console.Write(@"
                How many would you like to add?: ")
                string _enemyQuantity = int.Parse(Console.ReadLine())
                if (_enemyDictionary.ContainsKey(_enemyName)){

                }
                else{
                    Console.WriteLine(@"
                    Sorry, this enemy doenst exist in our files!")
                }
            }
            else if (choice == 2){

            }
            else if (choice == 3){
                Console.WriteLine(@"
                Your final combatant list:")
                _addCombatants = false;
                Thread.Sleep(4000)
            }
            else{

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