public abstract class Enemy{
    protected List<string> _statList;
    protected string _name;
    protected int _dex;
    protected int _str;
    protected int _hp;
    protected int[] _mods;


    public Enemy(List<string> stats){
        _statList = stats;
        _name = stats[0];
        _dex = int.Parse(stats[4]);
        _str = int.Parse(stats[3]);
        _hp = int.Parse(stats[2]);
        CalculateMods();
    }
    public void TakeDamage(){
        Console.Write(@"
            How much damage was taken?: ");
        int damage = int.Parse(Console.ReadLine());
        _hp = _hp - damage;
        if (_hp < 0){
            _statList[2] = "{_hp}";
        }
        else if (_hp <= 0 ){
            Console.WriteLine(@"
            This enemy was killed!");
        }
    }
    private void CalculateMods(){
        _statList.Add($"{Calc(_dex)}");
        _statList.Add($"{Calc(_str)}");
        int Calc(int stat){
            double _stat = Convert.ToDouble(stat);
            int result = Convert.ToInt32(Math.Floor((_stat/2)-5));
            return result;
        }
    }
    public abstract void Attack();
    public abstract List<string> ReturnNewData();
}