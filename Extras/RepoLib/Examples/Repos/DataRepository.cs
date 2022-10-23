
/// <summary>
/// This class is intended to act as the "universal" data repository for the application. 
/// DataRepository therefore contains the three individual repositories.
/// DataRepository implements its own set of application-specific CRUD+ methods, 
/// and does not expose individual repositories to a client.
/// </summary>
public class DataRepository
{
    private DataConverter _dataConverter;

    private RepositoryAdapterBase<Customer, CustomerDTO> _customerRepo;
    private RepositoryAdapterBase<Product, ProductDTO> _productRepo;
    private OrderRepository _orderRepo;

    public DataRepository(bool loadOnCreate = true)
    {
        _dataConverter = new DataConverter();

        _customerRepo = new RepositoryAdapterBase<Customer, CustomerDTO>(new CustomerDTORepository(false), _dataConverter);
        _productRepo = new RepositoryAdapterBase<Product, ProductDTO>(new ProductDTORepository(false), _dataConverter);
        _orderRepo = new OrderRepository(new OrderDTORepository(false), _dataConverter);

        _dataConverter.CustomerRepo = _customerRepo;
        _dataConverter.ProductRepo = _productRepo;

        if (loadOnCreate)
        {
            LoadCustomers();
            LoadProducts();
            LoadOrders();
        }
    }

    public void LoadCustomers() { _customerRepo.Load(); }
    public void LoadProducts() { _productRepo.Load(); }
    public void LoadOrders() { _orderRepo.Load(); } // Maybe this needs to be more elaborate...

    public void SaveCustomers() { _customerRepo.Save(); }
    public void SaveProducts() { _productRepo.Save(); }
    public void SaveOrders() { _orderRepo.Save(); }

    public void ClearCustomers() { _customerRepo.Clear(); }
    public void ClearProducts() { _productRepo.Clear(); }
    public void ClearOrders() { _orderRepo.Clear(); } // Maybe this needs to be more elaborate...


    public int CreateProduct(string description, double price, int? hardId = null)
    {
        return _productRepo.Create(new Product(description, price));
    }

    public int CreateCustomer(string name, string phone, string address, int? hardId = null)
    {
        return _customerRepo.Create(new Customer(name, phone, address));
    }

    public int CreateOrder(int customerId, List<int> productIds, int? hardId = null)
    {
        Customer? customer = _customerRepo.Read(customerId);
        List<Product> products = productIds.Select(id => _productRepo.Read(id))
                                           .Where(e => e != null)
                                           .Select(e => e!).ToList();

        return CreateOrder(customer, products, hardId);
    }

    public int CreateOrder(Customer? customer, List<Product> products, int? hardId = null)
    {
        return _orderRepo.Create(new Order(customer, products));
    }

    public Product? ReadProduct(int id) { return _productRepo.Read(id); }
    public Customer? ReadCustomer(int id) { return _customerRepo.Read(id); }
    public Order? ReadOrder(int id) { return _orderRepo.Read(id); }

    public bool UpdateProduct(int id, Product p) { return _productRepo.Update(id, p); }
    public bool UpdateCustomer(int id, Customer c) { return _customerRepo.Update(id, c); }
    public bool UpdateOrder(int id, Order o) { return _orderRepo.Update(id, o); }

    public bool DeleteProduct(int id) { return _productRepo.Delete(id); }
    public bool DeleteCustomer(int id) { return _customerRepo.Delete(id); }
    public bool DeleteOrder(int id) { return _orderRepo.Delete(id); }

    public List<Product> GetProducts() { return _productRepo.GetAll(); }
    public List<Customer> GetCustomers() { return _customerRepo.GetAll(); }
    public List<Order> GetOrders() { return _orderRepo.GetAll(); }

    public string GetCustomersAsString() { return _customerRepo.ToString(); }
    public string GetProductsAsString() { return _productRepo.ToString(); }
    public string GetOrdersAsString() { return _orderRepo.ToString(); }

    public List<Product> SearchProducts(string searchTerm) { return _productRepo.Search(searchTerm); }
    public List<Customer> SearchCustomers(string searchTerm) { return _customerRepo.Search(searchTerm); }
    public List<Order> SearchOrders(string searchTerm) { return _orderRepo.Search(searchTerm); }
}
