class Hero
{
    public string name;
    public int health;
    public int attack;
    public int defense;
    public int gold;

    public Hero(string _name)
    {
        name = _name;
        health = 100;
        attack = 10;
        defense = 5;
        gold = 0;
    }

    public void ShowStats()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Health: " + health);
        Console.WriteLine("Attack: " + attack);
        Console.WriteLine("Defense: " + defense);
        Console.WriteLine("Gold: " + gold);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    public void DealDamage(Enemy enemy)
    {
        // Deal "attack" damage to an enemy
        enemy.TakeDamage(attack);
    }
}