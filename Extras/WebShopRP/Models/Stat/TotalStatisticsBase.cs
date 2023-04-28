
/// <summary>
/// Base class for total statistics for a specific data type.
/// </summary>
/// <typeparam name="TData">Data type to which the statistics apply.</typeparam>
/// <typeparam name="TStat">Type of individual entity statistics.</typeparam>
public class TotalStatisticsBase<TData, TStat> : ITotalStatistics<TData, TStat>
	where TData : IHasOrders, IHasId, IHasName
	where TStat : IStatistics<TData>
{
	public Dictionary<int, TStat> Stats { get; }

	public int TotalOrders => Stats.Select(kvp => kvp.Value.TotalOrders).Sum();
	public int TotalOrdered => Stats.Select(kvp => kvp.Value.TotalOrdered).Sum();
	public double TotalPrice => Stats.Select(kvp => kvp.Value.TotalPrice).Sum();

	public TotalStatisticsBase()
	{
		Stats = new Dictionary<int, TStat>();
	}

	public void AddStat(TStat stat)
	{
		Stats[stat.Entity.Id] = stat;
	}
}
