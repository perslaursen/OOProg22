
public class BackPackingSolverSmartFavorSmallItems : BackPackingSolverSmartBase
{
    public BackPackingSolverSmartFavorSmallItems(List<BackPackItem> items, double capacity) : base(items, capacity)
    {
    }

    protected override double ActualItemValue(BackPackItem item)
    {
        return (item.Value + 5) / item.Weight;
    }
}
