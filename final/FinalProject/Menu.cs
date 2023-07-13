public class Menu{
    private int _userInput;
    private Dictionary<string, string[]> _combatants = new Dictionary<string, string[]>();
    private bool _active = true;

    public Menu(){

    }

    public void DisplayMenu(){
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
}