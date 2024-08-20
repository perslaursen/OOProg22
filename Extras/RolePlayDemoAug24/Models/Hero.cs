using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Damage;

namespace RolePlayDemoAug24.Models;

/// <summary>
/// Respresents a Hero, who will fight a Beast. A Hero is a Being, but also has:
/// 1) A Weapon
/// 2) A set of equipped Armor
/// 3) A Damage Affinity
/// </summary>
public class Hero : Being
{
	public DamageAffinity DamageAffinity { get; }
	public Weapon? Weapon { get; set; }
	public ArmorSet EquippedArmor { get; set; }
	public override DamageResistance DamageResistance { get { return EquippedArmor.DamageResistance; } }

	/// <summary>
	/// A Hero can be created without a Weapon or Armor. This can be added/updated later.
	/// </summary>
	public Hero(string name, string desc, double healthpoints, DamageAffinity damageAffinity, Weapon? weapon, List<Armor>? armorList = null)
		: base(name, desc, healthpoints)
	{
		DamageAffinity = damageAffinity;
		Weapon = weapon;
		EquippedArmor = new ArmorSet(armorList); ;
	}

	/// <summary>
	/// Replace the set of equipped Armor with the new set of Armor.
	/// </summary>
	public void SetArmor(List<Armor>? armorList)
	{
		EquippedArmor.SetArmor(armorList);
	}

	/// <summary>
	/// A Hero attacks by dealing Damage with the Weapon, and multiplying
	/// the Damage with the Damage Affinity.
	/// </summary>
	protected override DamageDealt CalcDamageDealt()
	{
		if (Weapon == null)
			return new DamageDealt();
		else
			return MultiplyDamageByAffinity(Weapon.DealDamage());
	}

	/// <summary>
	/// Calculates and returns the resulting Damage from the given Damage 
	/// modified by the Damage Affinity.
	/// </summary>
	private DamageDealt MultiplyDamageByAffinity(DamageDealt dd)
	{
		double fireDamage = dd.GetDamage(DamageType.Fire) * DamageAffinity.GetFraction(DamageType.Fire);
		double frostDamage = dd.GetDamage(DamageType.Frost) * DamageAffinity.GetFraction(DamageType.Frost);
		double necroDamage = dd.GetDamage(DamageType.Necrotic) * DamageAffinity.GetFraction(DamageType.Necrotic);
		double physDamage = dd.GetDamage(DamageType.Physical) * DamageAffinity.GetFraction(DamageType.Physical);

		return new DamageDealt(fireDamage, frostDamage, necroDamage, physDamage);
	}
}
