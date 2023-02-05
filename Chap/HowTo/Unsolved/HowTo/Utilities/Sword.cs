
// This is the class definition for the class Player
public class Sword
{
    public int MinDamage { get; }
    public int MaxDamage { get; }

    /// <summary>
    /// Create a Sword which deals damage in the interval [MinDamage; MaxDamage]
    /// </summary>
    public Sword(int minDamage, int maxDamage)
    {
        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    /// <summary>
    /// Create a Sword which deals damage in the interval [10; 50]
    /// </summary>
    public Sword()
    {
        MinDamage = 5;
        MaxDamage = 25;
    }

    /// <summary>
    /// Calculates the damage dealt when using the sword once.
    /// Calling it again will (probably) return a different result.
    /// </summary>
    public int CalculateDamage()
    {
        return GetRandomNumber(MinDamage, MaxDamage);
    }

    // Helper method, only used in the Sword class itself.
    private int GetRandomNumber(int min, int max)
    {
        return _random.Next(min, max + 1);
    }

    // Helper (static) instance field, for random number generation
    private static Random _random = new Random();
}
