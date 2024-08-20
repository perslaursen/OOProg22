using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Utils;

namespace RolePlayDemoAug24.Models.Damage;

/// <summary>
/// Represents the actual Damage dealt by a Damage Dealer.
/// </summary>
public class DamageDealt : DamageMap
{
    public DamageDealt(double fire, double frost, double necro, double physical)
        : base(fire, frost, necro, physical)
    {
    }

    /// <summary>
    /// This constructor implies that no Damage was dealt
    /// </summary>
    public DamageDealt() : this(0, 0, 0, 0)
    {
    }

    /// <summary>
    /// Returns the Damage amount for the given Damage type.
    /// </summary>
    public double GetDamage(DamageType damageType)
    {
        return GetDamageValue(damageType);
    }

    /// <summary>
    /// Returns the total Damage amount.
    /// </summary>
    public double GetDamage()
    {
        return GetDamageValueSum();
    }

    /// <summary>
    /// Sets the Damage amount for the given Damage type.
    /// </summary>
    public void SetDamage(DamageType damageType, double damage)
    {
        _damageMap[damageType] = damage;
    }

    /// <summary>
    /// All Damage values must be non-negative.
    /// </summary>
    public override void ValidateDamageVaules(double fire, double frost, double necro, double physical)
    {
        Validation.CheckNonNegative(fire);
        Validation.CheckNonNegative(frost);
        Validation.CheckNonNegative(necro);
        Validation.CheckNonNegative(physical);
    }
}
