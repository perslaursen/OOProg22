
/// <summary>
/// Total statistics for a specific data type.
/// </summary>
/// <typeparam name="TData">Data type to which the statistics apply.</typeparam>
/// <typeparam name="TStat">Type of individual entity statistics.</typeparam>
public interface ITotalStatistics<TData, TStat>
	where TData : IHasOrders, IHasId, IHasName
	where TStat : IStatistics<TData>
{
	/// <summary>
	/// Statistics collection, mapped from entity id 
	/// to individual entity statistics.
	/// </summary>
	Dictionary<int, TStat> Stats { get; }

	int TotalOrdered { get; }
	int TotalOrders { get; }
	double TotalPrice { get; }

	void AddStat(TStat stat);
}
