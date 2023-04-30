
/// <summary>
/// This interface targets those entities which have 
/// an Orders navigation property.
/// </summary>
public interface IHasOrders
{
	ICollection<Order> Orders { get; set; }
}
