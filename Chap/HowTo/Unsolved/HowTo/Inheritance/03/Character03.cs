
public abstract class Character03
{
    public string Name { get; }
    public int LifePoints { get; private set; }
    public int DamageLimit { get; private set; }
    public bool IsDead { get { return LifePoints <= 0; } }
    public abstract string Talk();

    public Character03(string name, int lifePoints, int damageLimit)
    {
        Name = name;
        LifePoints = lifePoints;
        DamageLimit = damageLimit;
    }

    public void RaiseLifePoints(int points)
    {
        if (points >= 0)
            LifePoints += points;
    }

    public void LowerLifePoints(int points)
    {
        if (points >= 0)
            LifePoints -= points;
    }

    public int DealDamage()
    {
        return GetRandomNumber(DamageLimit/10, DamageLimit);
    }

    /// <summary>
    /// This method returns a random integer value, 
    /// in the interval from "min to "max".
    /// </summary>
    protected static int GetRandomNumber(int min, int max)
    {
        return _random.Next(min, max + 1);
    }

    private static Random _random = new Random(Guid.NewGuid().GetHashCode());
}
