namespace RolePlayDemoAug24.Models.Base;

/// <summary>
/// Represents the various parts of the body to which a piece of Armor fits.
/// One piece of Armor can only fit on one part of the body.
/// </summary>
public enum ArmorType
{
    Feet,
    Chest,
    Hands,
    Head
}

public class ArmorTypes
{
    /// <summary>
    /// Returns of List of all existing Armor types.
    /// </summary>
    /// <returns></returns>
    public static List<ArmorType> GetAll()
    {
        return Enum.GetValues(typeof(ArmorType)).Cast<ArmorType>().ToList();
    }
}