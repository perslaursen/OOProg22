
/// <summary>
/// Weapon factory class for medieval weapons.
/// </summary>
public class WeaponFactoryMedieval : IWeaponFactory
{
    public IWeapon Create(WeaponType type)
    {
        if (WeaponType.Magic == type)
        {
            return new VacuumEnergyChanneler();
        }
        else if (WeaponType.Melee == type)
        {
            return new TazerKnuckles();
        }
        else if (WeaponType.Ranged == type)
        {
            return new Phaser();
        }
        return null;
    }
}
