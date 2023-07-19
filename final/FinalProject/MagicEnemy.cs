public class MagicEnemy:Enemy{
    public MagicEnemy(List<string> stats):base(stats){

    }

    public override void Attack(){
        Console.Clear();
        Console.Write(@"
            How many times is this enemy attacking?: ");
        int attacks = int.Parse(Console.ReadLine());
        for (int i=0; i<attacks; i++){
            InitiativeRoll hitRoll = new InitiativeRoll(20, int.Parse(_statList[11]));
            int roll = hitRoll.Calculate();
            Console.Write($@"
            Does a {roll} hit?
            1. Yes
            2. No
            Answer: ");
            int result = int.Parse(Console.ReadLine());
            if (result == 1){
                Console.Clear();
                Console.Write(@"
            Enter how many sides this creatures damage dice have for this attack: ");
                int sides = int.Parse(Console.ReadLine());
                Console.Write(@"
            Amount of dice being rolled: ");
                int amount = int.Parse(Console.ReadLine());
                DamageRoll dice = new DamageRoll(sides, int.Parse(_statList[11]), amount);
                int damage = dice.Calculate();
                Console.Write(@"
            Does this attack expend a spell slot?
            1. Yes
            2. No
            Answer: ");
                int answer = int.Parse(Console.ReadLine());
                if (answer == 1){
                    ExpendSpellSlot();
                }
                Console.WriteLine($@"
            They do {damage} points of damage!");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
    public override List<string> ReturnNewData(){
        return _statList;
    }

    private void ExpendSpellSlot(){
        int current = int.Parse(_statList[9]);
        current = current - 1;
        _statList[9] = $"{current}";
    }
}