using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Damage;

namespace RolePlayDemoAug24.Models;

/// <summary>
/// Represents a single piece of Armor. A piece of Armor has:
/// 1) A Name
/// 2) An Armor type (i.e. which body part does the Armor fit).
/// 3) A DamageResistance
/// </summary>
public class Armor : HasIdAndName
{
	public ArmorType ArmorType { get; }
	public DamageResistance DamageResistance { get; }

	public Armor(string name, ArmorType armorType, DamageResistance damageResistance)
		: base(name)
	{
		ArmorType = armorType;
		DamageResistance = damageResistance;
	}
}
