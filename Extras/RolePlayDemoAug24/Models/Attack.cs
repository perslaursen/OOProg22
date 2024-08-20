using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Damage;

namespace RolePlayDemoAug24.Models;

/// <summary>
/// Represents an Attack, e.g. performed by a Beast, An Attack has:
/// 1) A Name
/// 2) A DamageSpecification
/// </summary>
public class Attack : HasIdAndName
{
	public DamageSpecification Damage { get; }

	public Attack(string name, DamageSpecification damage)
		: base(name)
	{
		Damage = damage;
	}

	public DamageDealt DealDamage()
	{
		return Damage.DealDamage();
	}
}
