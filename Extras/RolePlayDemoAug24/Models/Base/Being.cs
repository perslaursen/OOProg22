using RolePlayDemoAug24.Models.Damage;
using RolePlayDemoAug24.Models.Utils;

namespace RolePlayDemoAug24.Models.Base;

/// <summary>
/// Base class for all living entities in the game (currently Hero and Beast).
/// All Beings have
/// 1) An Id, a Name and a Description
/// 2) Health Points (HP), and are considered dead if HP < 0.
/// 3) Damage Resistance (implemented in derived classes)
/// 4) Can deal Damage
/// 5) Can receive Damage
/// </summary>
public abstract class Being : HasIdAndName
{
	private double _initialHealthPoints;

	public string Description { get; set; }
	public double Healthpoints { get; protected set; }
	public double HealthAsFraction { get { return Healthpoints / _initialHealthPoints; } }
	public bool IsDead { get { return Healthpoints < 0; } }
	public abstract DamageResistance DamageResistance { get; }

	public Being(string name, string description, double healthpoints)
		: base(name)
	{
		Validation.CheckNonNegative(healthpoints);

		Description = description;
		Healthpoints = healthpoints;

		_initialHealthPoints = healthpoints;
	}

	/// <summary>
	/// Logic for dealing Damage.
	/// </summary>
	public DamageDealt DealDamage()
	{
		// Only deal damage if Being is not dead.
		return IsDead ? new DamageDealt() : CalcDamageDealt();
	}

	/// <summary>
	/// The actual calculation of the Damage dealt must be performed in the dervied classes.
	/// </summary>
	protected abstract DamageDealt CalcDamageDealt();

	/// <summary>
	/// Logic for receiving Damage. The net amount of Damage received is returned.
	/// </summary>
	public double ReceiveDamage(DamageDealt damageDealt)
	{
		// Only receive Damage if Being is not dead
		if (IsDead)
			return 0;

		double totalDamage = 0;

		// Add up Damage contributions for all Damage types.
		foreach (DamageType damageType in DamageTypes.GetAll())
		{
			// Each Damage contribution is "resisted" by the Beings ability to resist this
			// specific type of damage (by means of Armor and/or Damage resistance).
			totalDamage += damageDealt.GetDamage(damageType) * (1 - (DamageResistance.GetFraction(damageType)));
		}

		Healthpoints -= totalDamage;

		return totalDamage;
	}

	/// <summary>
	/// Restores the Being to full health.
	/// </summary>
	public void Reset()
	{
		Healthpoints = _initialHealthPoints;
	}
}
