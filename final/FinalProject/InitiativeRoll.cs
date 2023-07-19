public class InitiativeRoll:DiceRoll{
    private int _initiative;

    public InitiativeRoll(int sides, int mod):base(sides,mod){

    }
    public override int Calculate()
    {   
        int roll = RollDice();
        _initiative = roll+_modifier;
        return _initiative;
    }

}