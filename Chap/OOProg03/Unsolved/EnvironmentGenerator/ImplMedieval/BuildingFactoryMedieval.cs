
public class BuildingFactoryMedieval : IBuildingFactory
{
    public IBuilding Create()
    {
        return new Castle();
    }
}
