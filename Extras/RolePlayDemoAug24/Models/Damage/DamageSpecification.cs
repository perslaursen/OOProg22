using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Utils;

namespace RolePlayDemoAug24.Models.Damage;

/// <summary>
/// Represents the specification of Damage for a damage dealing entity 
/// (currently Weapon or Attack). A specification consists of
/// 1) An interval specifying minimal/maximal total damage.
/// 2) A Damage distribution, specified by values (as percentages) for each Damage type.
///    These values must add up to 100 %, as they specify how the total Damage is 
///    distributed across the Damage types.
/// </summary>
public class DamageSpecification : DamageMap
{
    public double MinAmount { get; }
    public double MaxAmount { get; }

    public DamageSpecification(double minAmount, double maxAmount, double fire, double frost, double necro, double physical)
        : base(fire, frost, necro, physical)
    {
        Validation.CheckRelation(minAmount, maxAmount);

        MinAmount = minAmount;
        MaxAmount = maxAmount;
    }

    public double GetDamage(DamageType damageType)
    {
        return GetDamageValue(damageType);
    }

    /// <summary>
    /// Calculates an actual instance of Damage dealt, given the specification.
    /// </summary>
    /// <returns></returns>
    public DamageDealt DealDamage()
    {
        // Find base damage.
        double baseDamage = RNG.NextDouble(MinAmount, MaxAmount);

        DamageDealt damageDealt = new DamageDealt();
        foreach (DamageType damageType in DamageTypes.GetAll())
        {
            // Find Damage amount for each Damage type.
            damageDealt.SetDamage(damageType, (GetDamageValue(damageType) / 100.0) * baseDamage);
        }

        return damageDealt;
    }

    public override void ValidateDamageVaules(double fire, double frost, double necro, double physical)
    {
        Validation.CheckInterval(fire + frost + necro + physical, 99.99, 100.01);
    }
}
