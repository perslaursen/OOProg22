using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Damage;

namespace RolePlayDemoAug24.Models.Repos;

/// <summary>
/// Repository of Beast instances.
/// </summary>
public class BeastRepository : Repository<Beast>
{
	public BeastRepository()
	{
		_elements = new List<Beast>()
		{
			new Beast("Flame Bear", "A formidable creature, blending physcial and fire damage in equal doses.", 300, new DamageResistance(15, 25, 0, 50), new List<Attack>
				{ 
					new Attack("Maul", new DamageSpecification(25, 60, 0, 0, 20, 80)),
					new Attack("Flame Breath", new DamageSpecification(50, 80, 90, 0, 10, 0)),
					new Attack("Bite", new DamageSpecification(30, 70, 0, 0, 60, 40))
				}),
			new Beast("Icosaur", "After near-extinction, these strong and chilling beasts still roam colder zones.", 260, new DamageResistance(0, 60, 50, 0), new List<Attack>
				{
					new Attack("Headbutt", new DamageSpecification(20, 50, 0, 0, 10, 90)),
					new Attack("Ice Spray", new DamageSpecification(40, 90, 0, 80, 20, 0)),
					new Attack("Claw Rip", new DamageSpecification(15, 25, 0, 0, 50, 50))
				}),
			new Beast("Arcane Gorilla", "A strong but also very intelligent creature, not only relying on physical strength.", 350, new DamageResistance(10, 10, 80, 50), new List<Attack>
				{
					new Attack("Fist Flurry", new DamageSpecification(30, 50, 0, 0, 20, 80)),
					new Attack("Mortal Touch", new DamageSpecification(50, 110, 0, 0, 80, 20)),
					new Attack("Cold Breath", new DamageSpecification(25, 45, 0, 60, 20, 20))
				}),
			new Beast("Demonotaur", "A mythic beast seen only by the damned, and usually only once in a lifetime.", 500, new DamageResistance(40, 25, 60, 35), new List<Attack>
				{
					new Attack("Mind Flay", new DamageSpecification(60, 90, 0, 0, 50, 50)),
					new Attack("Fatal Rip", new DamageSpecification(35, 70, 25, 0, 20, 55)),
					new Attack("Brutal Slam", new DamageSpecification(50, 90, 0, 0, 0, 100))
				}),
		};

		_selection = Enumerable.Repeat(false, _elements.Count).ToList();
	}
}
