
public class Character
{
    /// <summary>
    /// Name of character. Once set, it cannot be changed.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The number of LifePoints defines how "healthy" the character is.
    /// </summary>
    public int LifePoints { get; private set; }

    /// <summary>
    /// Upper limit on the damage the character can deal to other characters.
    /// </summary>
    public int DamageLimit { get; private set; }

    /// <summary>
    /// If LifePoints drops to zero or below, the character is dead.
    /// </summary>
    public bool IsDead { get { return LifePoints <= 0; } }

    public Character(string name, int lifePoints, int damageLimit)
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

    /// <summary>
    /// Decides how much damage the character deals in a single attack.
    /// </summary>
    public int DealDamage()
    {
        return GetRandomNumber(DamageLimit/10, DamageLimit);
    }

    /// <summary>
    /// This method returns a random integer value, 
    /// in the interval from "min" to "max", both included.
    /// </summary>
    protected static int GetRandomNumber(int min, int max)
    {
        return _random.Next(min, max + 1);
    }

    private static Random _random = new Random(Guid.NewGuid().GetHashCode());
}
