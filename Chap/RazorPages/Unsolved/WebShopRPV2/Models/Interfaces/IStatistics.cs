
/// <summary>
/// Interface for entities for which order-oriented statistics can be created.
/// This is in practice either Customers or Products.
/// </summary>
/// <typeparam name="TData">Type of entity to which the statistics apply.</typeparam>
public interface IStatistics<TData> 
	where TData : IHasOrders, IHasId, IHasName
{
	/// <summary>
	/// Entity to which the statistics apply.
	/// </summary>
	TData Entity { get; }

	int Id { get; }
	string Name { get; }
	IEnumerable<Order> Orders { get; }

	int TotalOrdered { get; }
	int TotalOrders { get; }
	double TotalPrice { get; }
}