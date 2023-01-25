
public class WeaponFactoryFuture : IWeaponFactory
{
    public IWeapon Create()
    {
        return new Phaser();
    }
}
