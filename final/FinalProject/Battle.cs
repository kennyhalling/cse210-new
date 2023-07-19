using System.IO;

public class Battle{
    private Dictionary<string, Enemy> _combatants;
    private Dictionary<int, List<string>> _initiativeOrder;
    private int _turn;

    public Battle(Dictionary<string, Enemy> combatants){
        _combatants = combatants;
        _initiativeOrder = new Dictionary<int, List<string>>();
        _turn = 0;
    }

    public void Battlefield(){
        RollInitiative();
        CreateBattleFile(_initiativeOrder);
        bool _activeBattle = true;
        Console.WriteLine(@"
            Open up 'theBattle.txt' to see the generated turn order! HP, Spell Slots, and 
            deaths will all be visibly tracked within this file.");
        Thread.Sleep(5000);
        Console.Clear();
        while (_activeBattle){
            Console.Write(@"
            What action are you taking?:
            1. Take Turn
            2. Record Damage
            3. Finish Battle
            Your choice: ");
            int _choice = int.Parse(Console.ReadLine());
            if (_choice ==1){
                if (_turn < _initiativeOrder.Count()){
                    List<int> list = _initiativeOrder.Keys.ToList();
                    list.Sort();
                    list.Reverse();
                    int key = list[_turn];
                    Console.WriteLine(@$"
            It's {_initiativeOrder[key][0]}'s turn!");
                    Thread.Sleep(2000);
                    List<string> _stats = _initiativeOrder[key];
                    if (_stats[9] != "0"){
                        MagicEnemy magic = new MagicEnemy(_stats);
                        DealDamge(magic);
                        _stats = magic.ReturnNewData();
                        _initiativeOrder[key] = _stats;
                        CreateBattleFile(_initiativeOrder);
                    }
                    else{
                        NormalEnemy norm = new NormalEnemy(_stats);
                        DealDamge(norm);
                    }
                    _turn += 1;
                }
                else{
                    _turn = 0;
                }
                Console.Clear();
            }
            else if (_choice ==2){
                TakeDamage(_initiativeOrder);
                Console.Clear();
            }
            else if (_choice ==3){
                _activeBattle = false;
                Console.Clear();
            }
        }
    }
    private void CreateBattleFile(Dictionary<int, List<string>> dictionary){
        using (StreamWriter outputfile= new StreamWriter("theBattle.txt")){
            List<int> list = dictionary.Keys.ToList();
            list.Sort();
            list.Reverse();
            outputfile.WriteLine("Initiative: Monster Name ~ HP, Spell Slots");
            foreach (int key in list){
                if (dictionary[key][9] == "0"){
                    outputfile.WriteLine("{0}: {1} ~ HP: {2}", key, dictionary[key][0], dictionary[key][2]);
                }
                else{
                    outputfile.WriteLine("{0}: {1} ~ HP: {2}, Spell Slots: {3}", key, dictionary[key][0], dictionary[key][2], dictionary[key][9]);
                }
            }
        }
    }
    private void RollInitiative(){
        foreach (KeyValuePair<string, Enemy> entry in _combatants){
            List<string> _stats = entry.Value.ReturnNewData();
            InitiativeRoll intRoll = new InitiativeRoll(20, int.Parse(_stats[10]));
            int initiative = intRoll.Calculate();
            _stats[0] = entry.Key;
            bool _adding = true;
            while (_adding){
                if (_initiativeOrder.ContainsKey(initiative)){
                    initiative = initiative+1;
                }
                else{
                    _initiativeOrder.Add(initiative, _stats);
                    _adding = false;
                }
            }
        }
    }
    private void TakeDamage(Dictionary<int, List<string>> dictionary){
        Console.Clear();
        Console.Write(@"
            Which enemy is taking damage?");
        int _counter = 1;
        foreach (KeyValuePair<int, List<string>> entry in dictionary){
            Console.Write(@$"
            {_counter}: {entry.Value[0]}");
            _counter += 1;
        }
        Console.Write(@"
            Your Choice: ");
        int _hurtEnemy = int.Parse(Console.ReadLine())-1;
        Console.Write(@"
            How much damage was done?: ");
        int _damage = int.Parse(Console.ReadLine());
        int _HP = int.Parse(dictionary.ElementAt(_hurtEnemy).Value[2]);
        _HP = _HP -_damage;
        if (_HP > 0){
            dictionary.ElementAt(_hurtEnemy).Value[2] = $"{_HP}";
        }
        else if(_HP <= 0){
            dictionary.Remove(dictionary.ElementAt(_hurtEnemy).Key);
            if(_hurtEnemy < _turn && _turn != 0){
                _turn = _turn-1;
            }
            Console.Clear();
            Console.WriteLine(@"
            This enemy was killed!");
            Thread.Sleep(2000);
        }
        CreateBattleFile(dictionary);
    }
    private void DealDamge(Enemy enemy){
        enemy.Attack();
    }
}