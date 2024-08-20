using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Damage;

namespace RolePlayDemoAug24.Models.Repos;

/// <summary>
/// Repository of Hero instances.
/// </summary>
public class HeroRepository : Repository<Hero>
{
	public HeroRepository()
	{
		_elements = new List<Hero>()
		{
			new Hero("Sir Galahad", "A galant champion, versed in many ways of combat", 200, new DamageAffinity(60, 120, 40, 100), null, null),
			new Hero("The Mountain", "Formidable strength, with an air of death around him", 250,  new DamageAffinity(20, 20, 60, 160), null, null),
			new Hero("Lagertha", "The ultimate warrior, trained in almost all talents of war", 280, new DamageAffinity(80, 50, 125, 110), null, null),
			new Hero("Hexia de Trick", "Intellect and magic powers equalled by very few", 170, new DamageAffinity(140, 120, 170, 30), null, null)
		};

		_selection = Enumerable.Repeat(false, _elements.Count).ToList();
	}

	/// <summary>
	/// ( Only used for test purposes)
	/// </summary>
	//public void UpdateArmorForHeroes(ArmorRepository armorRepo)
	//{
	//	foreach (Hero hero in _elements)
	//	{
	//		hero.EquippedArmor.Clear();
	//		List<Armor> armorList = armorRepo.GetAll();

	//		for (int i = 0; i < armorList.Count; i++)
	//		{
	//			if (armorRepo.GetSelection()[i])
	//			{
	//				hero.EquippedArmor[armorList[i].ArmorType] = armorList[i];
	//			}
	//		}
	//	}
	//}

	/// <summary>
	/// ( Only used for test purposes)
	/// </summary>
	//public void UpdateWeaponForHeroes(Weapon weapon)
	//{
	//	foreach (Hero hero in _elements)
	//	{
	//		hero.Weapon = weapon;
	//	}
	//}
}
