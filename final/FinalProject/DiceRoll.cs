public abstract class DiceRoll{
    private Random _random = new Random();
    private int _sides;
    private Random _rand = new Random();
    private int _roll;
    protected int _modifier;

    public DiceRoll(int sides, int mod){
        _sides = sides;
        _modifier = mod;
    }

    public int RollDice(){
        _roll = _rand.Next(_sides+1);
        if( _roll == 0){
            _roll = _roll+1;
        }
        return _roll;
    }
    public abstract int Calculate();
}