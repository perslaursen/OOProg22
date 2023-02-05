
// This is the class definition for the class Player
public class Player11
{
    private Sword _sword;

    public string Name { get; }
    public int LifePoints { get; private set; }
    public bool IsDead { get { return LifePoints <= 0; } }

    public Player11(string name, int lifePoints, Sword sword)
    {
        _sword = sword;

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
