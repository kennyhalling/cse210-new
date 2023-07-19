public class DamageRoll:DiceRoll{
    private int _quanity;
    private int _damage;
    public DamageRoll(int sides, int mod, int quantity):base(sides,mod){
        _quanity = quantity;
    }
    public override int Calculate(){
        for (int i=0; i<_quanity; i++){
            int roll = RollDice();
            _damage = _damage+roll;
        }
        _damage = _damage+_modifier;
        return _damage;
    }
}