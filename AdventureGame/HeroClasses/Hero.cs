using static System.Net.Mime.MediaTypeNames;

class Hero
{
    private int MAX_HEALTH;

    public enum Race
    {
        Human,
        Elf,
        Dwarf,
    }

    public string name;
    public Race race;
    public string heroClass;
    public int health;
    public int attack;
    public int defense;
    public int gold;
    public int level;
    public int experience;
    public int expToNextLevel;

    public Hero(string name, Race race, string heroClass)
    {
        this.name = name;
        this.race = race;
        this.heroClass = heroClass;
        this.level = 1;
        this.experience = 0;
        this.expToNextLevel = 100;

        switch (race) {
            case Race.Human:
                health = MAX_HEALTH = 100;
                attack = 10;
                defense = 5;
                gold = 0;
                break;
            case Race.Elf:
                health = MAX_HEALTH = 90;
                attack = 15;
                defense = 3;
                gold = 0;
                break;
            case Race.Dwarf:
                health = MAX_HEALTH = 110;
                attack = 8;
                defense = 8;
                gold = 10;
                break;
            default:
                health = MAX_HEALTH = 100;
                attack = 10;
                defense = 5;
                gold = 0;
                break;
            }
    }

    public void ShowStats()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Race: " + race);
        Console.WriteLine("Class: " + heroClass);
        Console.WriteLine("Health: " + health + "/" + MAX_HEALTH);
        Console.WriteLine("Experience: " + experience);
        Console.WriteLine("Attack: " + attack);
        Console.WriteLine("Defense: " + defense);
        Console.WriteLine("Gold: " + gold);
    }

    public void TakeDamage(int damage)
    {
        damage -= defense;
        if (damage < 0) damage = 0;

        health -= damage;
        if (health < 0) health = 0;

        Console.WriteLine("You take " + damage + " damage! Health left: " + this.health + "/" + MAX_HEALTH);
    }

    public void DealDamage(Enemy enemy)
    {
        // Deal "attack" damage to an enemy
        enemy.TakeDamage(attack);

        Console.WriteLine("You deal " + attack + " damage to " + enemy.name + "!");
    }

    public void Heal(int health)
    {
        this.health += health;
        if (this.health > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }

        Console.WriteLine("You heal " + health + " health points! Current health: " + this.health + "/" + MAX_HEALTH);
    }

    public void AddGold(int gold)
    {
        this.gold += gold;

        Console.WriteLine("You gained " + gold + " gold! Current gold: " + this.gold);
    }

    public void RemoveGold(int gold)
    {
        if (this.gold >= gold)
        {
            this.gold -= gold;
            return;
        }

        Console.WriteLine("You do not have enough gold [gold: " + this.gold + "] to spend [price: " + gold + "]!");
    }

    public void AddExperience(int experience) {
        this.experience += experience;
        Console.WriteLine("You gained " + experience + " experience!");

        if (this.experience >= expToNextLevel)
        {
            LevelUp();
        }

        Console.WriteLine("Experience to next level: " + this.experience + "/" + expToNextLevel);
    }

    public void LevelUp() {
        level += 1;
        MAX_HEALTH += 10;
        health += 10;
        attack += 3;
        defense += 3;

        // in case LevelUp got called outside of AddExperience function, we should increase the experience to minimum requirement for current level
        if (expToNextLevel < experience)
        {
            experience = expToNextLevel;
        }

        expToNextLevel += level * 100;

        Console.WriteLine("Congratulations, your level has increased to " + level + "! Your stats went up!");

        // check if player can increase another level, and call LevelUp recursively 
        if (experience >= expToNextLevel)
        {
            LevelUp();
        }
    }
}