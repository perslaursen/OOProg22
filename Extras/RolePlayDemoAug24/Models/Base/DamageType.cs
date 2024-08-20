namespace RolePlayDemoAug24.Models.Base;

/// <summary>
/// Represents the various types or flavors of Damage that a Weapon or 
/// Attack can deal. The actual nature of the Damage is not so important.
/// </summary>
public enum DamageType
{
    Fire,
    Frost,
    Necrotic,
    Physical
}

public class DamageTypes
{
    /// <summary>
    /// Returns of List of all existing Damage types.
    /// </summary>
    /// <returns></returns>
    public static List<DamageType> GetAll()
    {
        return Enum.GetValues(typeof(DamageType)).Cast<DamageType>().ToList();
    }
}