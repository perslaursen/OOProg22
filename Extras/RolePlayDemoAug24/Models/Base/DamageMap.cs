namespace RolePlayDemoAug24.Models.Base;

/// <summary>
/// Base class for mappings from Damage types to values.
/// </summary>
public abstract class DamageMap
{
    protected Dictionary<DamageType, double> _damageMap;

    public DamageMap(double fire, double frost, double necro, double physical = 0)
    {
        ValidateDamageVaules(fire, frost, necro, physical);

        _damageMap = new Dictionary<DamageType, double>();

        _damageMap[DamageType.Fire] = fire;
        _damageMap[DamageType.Frost] = frost;
        _damageMap[DamageType.Necrotic] = necro;
        _damageMap[DamageType.Physical] = physical;
    }

    /// <summary>
    /// Specific validation of values must be performed in derived classes.
    /// </summary>
    public abstract void ValidateDamageVaules(double fire, double frost, double necro, double physical);

    /// <summary>
    /// Returns Damage values corresponding to given Damage type.
    /// </summary>
    protected double GetDamageValue(DamageType damageType)
    {
        if (_damageMap.ContainsKey(damageType))
            return _damageMap[damageType];
        else
            return 0;
    }

    /// <summary>
    /// Returns sum of all Damage values.
    /// </summary>
    protected double GetDamageValueSum()
    {
        return _damageMap.Values.Sum();
    }
}
