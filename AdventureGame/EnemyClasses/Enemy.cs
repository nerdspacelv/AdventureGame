class Enemy
{
    public string name;
    public int health;
    public int attack;
    public int defense;
    public int speed;
    public int experience;
    public int gold;
    public List<string> weaknesses; // { "fire", "lightning" }
    public List<string> resistances; // { "none" }
    public string attackType;

    public Enemy(string _name, int _health, int _attack, int _defense, int _speed, int _experience, int _gold, List<string> _weaknesses, List<string> _resistances, string _attackType)
    {
        name = _name;
        health = _health;
        attack = _attack;
        defense = _defense;
        speed = _speed;
        experience = _experience;
        gold = _gold;
        weaknesses = _weaknesses;
        resistances = _resistances;
        attackType = _attackType;
    }

    public void TakeDamage(int damage, string attackType)
    {
        if (weaknesses.Contains(attackType))
        {
        // Apply double damage if weak to the attack type
            damage *= 2;
        }
        // Check if the enemy has a resistance to the attack type
        else if (resistances.Contains(attackType))
        {
        // Apply half damage if resistant to the attack type
            damage /= 2;
        }
        damage -= defense;
        if (damage < 0)
        {
        damage = 0;
        }
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        Console.WriteLine(name" takes " + damage + " damage! Health left: " + this.health);
    }
    // can pass attack type with specific attacks if enemy can have several attack types.
    public int DealDamage() 
    {
        return attack;
    }
    //TODO
    //public Item DropItem()
}
