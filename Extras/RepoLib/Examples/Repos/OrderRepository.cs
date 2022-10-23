
/// <summary>
/// Explicit repository for Order object.
/// This is needed to provide a meaningful implementation of Search.
/// </summary>
public class OrderRepository : RepositoryAdapterBase<Order, OrderDTO>
{
    public OrderRepository(IPersistentRepository<OrderDTO> dtoRepo, IDataConverter<Order, OrderDTO> dataConverter) 
        : base(dtoRepo, dataConverter)
    {
    }

    public override List<Order> Search(string searchTerm)
    {
        return GetAll().Where(e => SearchMatch(e, searchTerm)).ToList();
    }

    /// <summary>
    /// SearchMatch is here defined as a match between the searchTerm
    /// and the Name on the Customer object (if any).
    /// </summary>
    /// <param name="order">Order object to test for match</param>
    /// <param name="searchTerm">string to match against Order object</param>
    private bool SearchMatch(Order order, string searchTerm)
    {
        if (order.Customer == null)
            return false;

        return order.Customer.Name.Contains(searchTerm);
    }
}
