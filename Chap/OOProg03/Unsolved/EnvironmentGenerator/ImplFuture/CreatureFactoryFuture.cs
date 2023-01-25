
public class CreatureFactoryFuture : ICreatureFactory
{
    public ICreature Create()
    {
        return new Robot();
    }
}
