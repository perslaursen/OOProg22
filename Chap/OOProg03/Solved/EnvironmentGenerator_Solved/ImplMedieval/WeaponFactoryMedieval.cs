
public class WeaponFactoryMedieval : IWeaponFactory
{
    public IWeapon Create()
    {
        return new Sword();
    }
}
