
public class BackPackingSolverSmartAbsoluteItemValue : BackPackingSolverSmartBase
{
    public BackPackingSolverSmartAbsoluteItemValue(List<BackPackItem> items, double capacity) : base(items, capacity)
    {
    }

    protected override double ActualItemValue(BackPackItem item)
    {
        return item.Value;
    }
}
