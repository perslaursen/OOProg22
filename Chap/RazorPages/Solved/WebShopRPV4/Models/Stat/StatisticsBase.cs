
/// <summary>
/// Base classes for order-oriented statistics
/// </summary>
/// <typeparam name="TData">Type of entity to which the statistics apply.</typeparam>
public class StatisticsBase<TData> : IStatistics<TData> 
	where TData : IHasOrders, IHasId, IHasName
{
	public TData Entity { get; }

	public int Id => Entity.Id;
	public string Name => Entity.Name;
	public IEnumerable<Order> Orders => Entity.Orders;

	public int TotalOrders => Orders.Count();
	public int TotalOrdered => Orders.Select(o => o.Amount).Sum();
	public double TotalPrice => Orders.Select(o => o.TotalPrice).Sum();

	public StatisticsBase(TData entity)
	{
		Entity = entity;
	}
}

