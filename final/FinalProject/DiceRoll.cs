public class DiceRoll{
    private Random _random = new Random();
    private int _sides;
    private int _roll;
    private int _modifier;
    private int _quantity;

    public DiceRoll(int sides, int mod, int quantity){
        _sides = sides;
        _modifier = mod;
        _quantity = quantity;
    }

    public virtual void RollDice(){
        
    }
    public virtual void Calculate(){
        
    }
}