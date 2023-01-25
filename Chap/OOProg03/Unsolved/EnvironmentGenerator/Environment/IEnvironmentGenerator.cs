
/// <summary>
/// Interface for an environment generator. This is the
/// interface for an Abstract Factory.
/// </summary>
public interface IEnvironmentGenerator
{
    IBuilding GenerateBuilding();
    ICreature GenerateCreature();
    IWeapon GenerateWeapon();
}
