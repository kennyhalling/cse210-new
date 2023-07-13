public class DamageRoll:DiceRoll{

    public DamageRoll(int sides, int mod, int quantity):base(sides,mod,quantity){

    }

    public override void RollDice()
    {
        base.RollDice();
    }
    public override void Calculate()
    {
        base.Calculate();
    }
}