using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Damage;
using RolePlayDemoAug24.Models.Utils;

namespace RolePlayDemoAug24.Models;

/// <summary>
/// Respresents a Beast, which will fight a Hero. A Beast is a Being, but also has:
/// 1) A DamageResistance
/// 2) A set of Attacks (from 1 to 3 Attacks)
/// </summary>
public class Beast : Being
{
	public override DamageResistance DamageResistance { get; }
	public List<Attack> Attacks { get; }

	public Beast(string name, string desc, double healthpoints, DamageResistance damageResistance, List<Attack> attacks)
		: base(name, desc, healthpoints)
	{
		Validation.CheckInterval(attacks.Count, 1, 3);

		DamageResistance = damageResistance;
		Attacks = new List<Attack>(attacks);
	}

	/// <summary>
	/// A Beast attacks by randomly choosing one Attack from its set of Attacks,
	/// and then performing the chosen Attack.
	/// </summary>
	protected override DamageDealt CalcDamageDealt()
	{
		int chosenAttack = RNG.NextInt(0, Attacks.Count);
		return Attacks[chosenAttack].DealDamage();
	}

	/// <summary>
	/// The Damage Resistance for a Beast is completely defined by
	/// its DamageResistance instance.
	/// </summary>
	//public override double GetDamageResistanceFraction(DamageType damageType)
	//{
	//	return _damageResistance.GetDamageResistanceFraction(damageType);
	//}
}
