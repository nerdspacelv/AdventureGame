class Enemy
{
    public string name;
    public int health;
    public int attack;
    public int defense;
    public int speed;
    public int experience;
    public int gold;

    public Enemy(string _name, int _health, int _attack, int _defense, int _speed, int _experience, int _gold)
    {
        name = _name;
        health = _health;
        attack = _attack;
        defense = _defense;
        speed = _speed;
        experience = _experience;
        gold = _gold;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    public int DealDamage()
    {
        return attack;
    }
}