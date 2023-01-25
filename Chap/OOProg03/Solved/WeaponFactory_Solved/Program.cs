

Console.WriteLine("Testing Medieval Weapon Factory");
TestWeaponFactory(new WeaponFactoryMedieval());
Console.WriteLine();

Console.WriteLine("Testing Future Weapon Factory");
TestWeaponFactory(new WeaponFactoryFuture());
Console.WriteLine();

void TestWeaponFactory(IWeaponFactory factory)
{
    IWeapon meleeWeapon = factory.Create(WeaponType.Melee);
    IWeapon rangedWeapon = factory.Create(WeaponType.Ranged);
    IWeapon magicWeapon = factory.Create(WeaponType.Magic);

    Console.WriteLine($"Melee Weapon: {meleeWeapon}");
    Console.WriteLine($"Ranged Weapon: {rangedWeapon}");
    Console.WriteLine($"Magic Weapon: {magicWeapon}");
}
