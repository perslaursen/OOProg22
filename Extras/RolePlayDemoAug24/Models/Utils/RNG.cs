namespace RolePlayDemoAug24.Models.Utils;

/// <summary>
/// Helper class for generating random numbers.
/// </summary>
public class RNG
{
    private static readonly Random _rand = new Random(Guid.NewGuid().GetHashCode());

    /// <summary>
    /// Generate random integer in [min; max] interval (max not included)
    /// </summary>
    public static int NextInt(int min, int max)
    {
        Validation.CheckRelation(min, max);
        return _rand.Next(min, max);
    }

    /// <summary>
    /// Generate random integer in [0; max] interval (max not included)
    /// </summary>
    public static int NextInt(int max)
    {
        return NextInt(0, max);
    }

    /// <summary>
    /// Generate random double in [min; max] interval
    /// </summary>
    public static double NextDouble(double min, double max)
    {
        Validation.CheckRelation(min, max);
        return min + _rand.NextDouble() * (max - min);
    }
}
