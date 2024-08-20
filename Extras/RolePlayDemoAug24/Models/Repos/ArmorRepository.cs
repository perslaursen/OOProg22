using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Damage;

namespace RolePlayDemoAug24.Models.Repos;

/// <summary>
/// Repository of Armor instances.
/// </summary>
public class ArmorRepository : Repository<Armor>
{
	public ArmorRepository()
	{
		_elements = new List<Armor>()
		{
			new Armor("Copper Helmet", ArmorType.Head, new DamageResistance(20, 10, 10, 60)),
			new Armor("Steel Helmet", ArmorType.Head, new DamageResistance(25, 10, 15, 50)),
			new Armor("Woolen Cap", ArmorType.Head, new DamageResistance(20, 10, 10, 60)),
			new Armor("Sages Headband", ArmorType.Head, new DamageResistance(20, 10, 10, 60)),
			new Armor("Leather Chest", ArmorType.Chest, new DamageResistance(20, 40, 10, 30)),
			new Armor("Plate Chest", ArmorType.Chest, new DamageResistance(20, 20, 10, 50)),
			new Armor("Sages Chest", ArmorType.Chest, new DamageResistance(40, 50, 0, 10)),
			new Armor("Lords Chest", ArmorType.Chest, new DamageResistance(15, 10, 0, 75)),
			new Armor("Wool Gloves", ArmorType.Hands, new DamageResistance(20, 20, 40, 20)),
			new Armor("Mail Gloves", ArmorType.Hands, new DamageResistance(30, 25, 10, 35)),
			new Armor("Leather Gloves", ArmorType.Hands, new DamageResistance(20, 20, 40, 20)),
			new Armor("Lords Gloves", ArmorType.Hands, new DamageResistance(10, 20, 25, 45)),
			new Armor("Wool Pants", ArmorType.Feet, new DamageResistance(20, 40, 0, 40)),
			new Armor("Mail Pants", ArmorType.Feet, new DamageResistance(40, 20, 0, 40)),
			new Armor("Linen Pants", ArmorType.Feet, new DamageResistance(20, 50, 10, 20)),
			new Armor("Captains Boots", ArmorType.Feet, new DamageResistance(20, 50, 10, 20))
		};

		_selection = Enumerable.Repeat(false, _elements.Count).ToList();
	}
}
