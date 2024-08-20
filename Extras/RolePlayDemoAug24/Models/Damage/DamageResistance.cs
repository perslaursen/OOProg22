using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Utils;

namespace RolePlayDemoAug24.Models.Damage;

/// <summary>
/// Represents the "resistance" for Damage types a Being may possess.
/// When a Being receives Damage of a specific type, this Damage is 
/// reduced with the corresponding Damage Resistance value, thereby 
/// possibly dampening the resulting Damage received.
/// Values are specified as a percentage.
/// </summary>
public class DamageResistance : DamageMap
{
    public DamageResistance(double fire, double frost, double necro, double physical)
        : base(fire, frost, necro, physical)
    {
    }

    /// <summary>
    /// This constructor implies that all Damage Resistances are 0 %, 
    /// i.e. no dampening.
    /// </summary>
    public DamageResistance() : this(0, 0, 0, 0)
    {
    }

    /// <summary>
    /// Returns the Damage Resistance for the given Damage type, as a percentage.
    /// </summary>
    public double GetPercentage(DamageType damageType)
    {
        return GetDamageValue(damageType);
    }

    /// <summary>
    /// Returns the Damage Resistance for the given Damage type, as a fraction.
    /// </summary>
    public double GetFraction(DamageType damageType)
    {
        return GetPercentage(damageType) / 100.0;
    }

    /// <summary>
    /// All Resistance values must be between 0 % and 100 %.
    /// </summary>
    public override void ValidateDamageVaules(double fire, double frost, double necro, double physical)
    {
        Validation.CheckInterval(fire, 0, 100);
        Validation.CheckInterval(frost, 0, 100);
        Validation.CheckInterval(necro, 0, 100);
        Validation.CheckInterval(physical, 0, 100);
    }
}
