
/// <summary>
/// Weapon factory class for futuristic weapons.
/// </summary>
public class WeaponFactoryFuture : IWeaponFactory
{
    public IWeapon Create(WeaponType type)
    {
        // implement
        if (WeaponType.Magic == type)
        {
            return new Wand();
        }
        else if (WeaponType.Melee == type)
        {
            return new Dagger();
        }
        else if (WeaponType.Ranged == type)
        {
            return new CrossBow();
        }
        
        return null;
    }
}
