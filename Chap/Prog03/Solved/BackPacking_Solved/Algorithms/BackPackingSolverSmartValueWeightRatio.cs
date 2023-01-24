
public class BackPackingSolverSmartValueWeightRatio : BackPackingSolverSmartBase
{
    public BackPackingSolverSmartValueWeightRatio(List<BackPackItem> items, double capacity) : base(items, capacity)
    {
    }

    protected override double ActualItemValue(BackPackItem item)
    {
        return item.Value / item.Weight;
    }
}