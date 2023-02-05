
// This is the class definition for the class Player
public class Player10
{
    private Sword _sword;

    public string Name { get; }
    public int LifePoints { get; private set; }
    public bool IsDead { get { return LifePoints <= 0; } }

    // Add a third parameter to the constructor
    public Player10(string name, int lifePoints)
    {
        // Use the new parameter to initialize _sword
        _sword = new Sword(20, 100);

        Name = name;
        LifePoints = lifePoints;
    }

    public void RaiseLifePoints(int points)
    {
        if (points >= 0)
        {
            LifePoints += points;
        }
    }

    public void LowerLifePoints(int points)
    {
        if (points >= 0)
        {
            LifePoints -= points;
        }
    }

    public int DealDamage()
    {
        return _sword.CalculateDamage();
    }
}
