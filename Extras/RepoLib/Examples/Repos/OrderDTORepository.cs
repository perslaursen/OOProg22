
/// <summary>
/// DTO-based repository for Order data.
/// Note that this class does NOT provide a useful implementation of SearchMatch.
/// </summary>
public class OrderDTORepository : JsonRepositoryAppBase<OrderDTO>
{
    public OrderDTORepository(bool loadOnCreation = true)
        : base("Orders.json", false)
    {
        if (loadOnCreation)
            InitFromList(ReadAllFromDataSource());
    }

    protected override bool SearchMatch(OrderDTO dto, string searchTerm)
    {
        throw new NotImplementedException(); // Should not be called!
    }

    protected override void UpdateObject(OrderDTO dtoEx, OrderDTO dtoNew)
    {
        dtoEx.CustomerId = dtoNew.CustomerId;
        dtoEx.ProductIds = dtoNew.ProductIds;
    }
}
