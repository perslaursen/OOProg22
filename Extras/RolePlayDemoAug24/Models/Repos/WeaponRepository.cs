using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Damage;

namespace RolePlayDemoAug24.Models.Repos;

/// <summary>
/// Repository of Weapon instances.
/// </summary>
public class WeaponRepository : Repository<Weapon>
{
    public WeaponRepository()
    {
        _elements = new List<Weapon>()
        {
            new Weapon("Novice Sword", new DamageSpecification(10, 25, 0, 0, 0, 100)),
            new Weapon("Spiked Mace", new DamageSpecification(15, 32, 0, 0, 0, 100)),
            new Weapon("Fire Wand", new DamageSpecification(20, 45, 70, 0, 0, 30)),
            new Weapon("Frost Gun", new DamageSpecification(30, 60, 0, 70, 10, 20)),
            new Weapon("Musket", new DamageSpecification(40, 75, 0, 0, 10, 90)),
            new Weapon("Dagger of Dread", new DamageSpecification(25, 50, 0, 0, 50, 50)),
            new Weapon("Rust Pistol", new DamageSpecification(30, 55, 20, 0, 30, 50)),
            new Weapon("Swift Rapier", new DamageSpecification(22, 48, 0, 10, 20, 70))
        };

        _selection = Enumerable.Repeat(false, _elements.Count).ToList();
    }
}
