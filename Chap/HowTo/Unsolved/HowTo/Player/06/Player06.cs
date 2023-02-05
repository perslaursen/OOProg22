
// This is the class definition for the class Player
public class Player06
{
    public string Name { get; }
    public int LifePoints { get; private set; }
    public bool IsDead { get { return LifePoints <= 0; } }

    public Player06(string name)
    {
        Name = name;
        LifePoints = 100;
    }

    public Player06(string name, int lifePoints)
    {
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

    // Add the method DealDamage here
}
