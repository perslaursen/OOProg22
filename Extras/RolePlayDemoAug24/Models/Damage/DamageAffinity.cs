using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Utils;

namespace RolePlayDemoAug24.Models.Damage;

/// <summary>
/// Represents the "affinity" for Damage types a Being may possess.
/// When a Being deals Damage of a specific type, this Damage is multiplied
/// with the corresponding Damage Affinity value, thereby dampening or
/// amplifying the resulting Damage.
/// Values are specified as a percentage.
/// </summary>
public class DamageAffinity : DamageMap
{
    public DamageAffinity(double fire, double frost, double necro, double physical)
        : base(fire, frost, necro, physical)
    {
    }

    /// <summary>
    /// This constructor implies that all Damage Affinities are 100 %, 
    /// i.e. no dampening or amplification.
    /// </summary>
    public DamageAffinity() : this(100, 100, 100, 100)
    {
    }

    /// <summary>
    /// Returns the Affinity for the given Damage type, as a percentage.
    /// </summary>
    public double GetPercentage(DamageType damageType)
    {
        return GetDamageValue(damageType);
    }

    /// <summary>
    /// Returns the Affinity for the given Damage type, as a fraction.
    /// </summary>
    public double GetFraction(DamageType damageType)
    {
        return GetPercentage(damageType) / 100.0;
    }

    /// <summary>
    /// All Affinity values must be between 0 % and 200 %.
    /// </summary>
    public override void ValidateDamageVaules(double fire, double frost, double necro, double physical)
    {
        Validation.CheckInterval(fire, 0, 200);
        Validation.CheckInterval(frost, 0, 200);
        Validation.CheckInterval(necro, 0, 200);
        Validation.CheckInterval(physical, 0, 200);
    }
}
