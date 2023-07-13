public abstract class Enemy{
    private string _name;
    private int[] _mods;
    private int _hp;


    public Enemy(string name, int[] mods, int hp){
        _name = name;
        _mods = mods;
        _hp = hp;
    }

    public abstract void Attack();
    public void TakeDamage(){

    }
    public void Heal(){

    }
    public abstract void ReturnStats();
}