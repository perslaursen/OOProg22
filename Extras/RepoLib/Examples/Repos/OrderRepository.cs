
public class OrderRepository : JsonRepositoryBase<Order, OrderDTO>
{
    private CustomerRepository _customerRepo;
    private ProductRepository _productRepo;

    public OrderRepository(CustomerRepository customerRepo, ProductRepository productRepo, bool loadOnCreation = true)
        : base(false)
    {
        _customerRepo = customerRepo;
        _productRepo = productRepo;

        if (loadOnCreation)
            InitFromList(ReadAllFromDataSource());
    }

    protected override string JsonFileName => @"C:\Users\persl\Documents\GitHubEASJ\OOProg22\Extras\RepoLib\Examples\Data\Orders.json";

    protected override Order FromDTO(OrderDTO dto)
    {
        return dto.Convert(_customerRepo, _productRepo);
    }

    protected override OrderDTO ToDTO(Order t)
    {
        return new OrderDTO(t);
    }

    protected override bool SearchMatch(Order t, string searchTerm)
    {
        if (t.Customer == null)
            return false;

        return t.Customer.Name.Contains(searchTerm);
    }

    protected override void UpdateObject(Order tEx, Order tNew)
    {
        tEx.Customer = tNew.Customer;
        tEx.Products = tNew.Products;
    }
}
