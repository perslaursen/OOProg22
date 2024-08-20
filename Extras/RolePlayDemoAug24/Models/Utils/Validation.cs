namespace RolePlayDemoAug24.Models.Utils;

/// <summary>
/// Helper class for validation of values and references.
/// </summary>
public class Validation
{
    public static void CheckNonNegative(double value)
    {
        if (value < 0)
            throw new ArgumentException("value cannot be negative");
    }

    public static void CheckInterval(double value, double min, double max)
    {
        if (value > max || value < min)
            throw new ArgumentException("value outside min-max interval");
    }

    public static void CheckRelation(double min, double max)
    {
        if (min > max)
            throw new ArgumentException("min cannot be larger than max");
    }

    public static void CheckNotNull<T>(T t)
    {
        if (t == null)
            throw new ArgumentNullException("object reference cannot be null");
    }
}
