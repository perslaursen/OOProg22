
public class CreatureFactoryMedieval : ICreatureFactory
{
    public ICreature Create()
    {
        return new Sheep();
    }
}
