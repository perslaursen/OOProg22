
/// <summary>
/// Specific data converter for the three model classes (Customer, Product, Order),
/// and the corresponding DTO classes (CustomerDTO, ProductDTO, OrderDTO)
/// </summary>
public class DataConverter : 
    IDataConverter<Customer, CustomerDTO>, 
    IDataConverter<Product, ProductDTO>,
    IDataConverter<Order, OrderDTO>
{
    /// <summary>
    /// Needed for conversion of Order objects.
    /// </summary>
    public IRepository<Customer>? CustomerRepo { get; set; }

    /// <summary>
    /// Needed for conversion of Order objects.
    /// </summary>
    public IRepository<Product>? ProductRepo { get; set; }

    public CustomerDTO ConvertData(Customer source)
    {
        return new CustomerDTO() 
        {
            Id = source.Id,
            Name = source.Name,
            Address = source.Address,
            Phone = source.Phone,
        };
    }

    public Customer CreateData(CustomerDTO source)
    {
        return new Customer(
            source.Id, 
            source.Name, 
            source.Phone, 
            source.Address);
    }

    public ProductDTO ConvertData(Product source)
    {
        return new ProductDTO()
        {
            Id = source.Id,
            Description = source.Description,
            Price = source.Price,
        };
    }

    public Product CreateData(ProductDTO source)
    {
        return new Product(
            source.Id,
            source.Description,
            source.Price);
    }

    public OrderDTO ConvertData(Order source)
    {
        List<int> productIds = source.Products.Select(e => e.Id).ToList();

        return new OrderDTO()
        {
            Id = source.Id,
            CustomerId = source.Customer?.Id ?? 0,
            ProductIds = productIds
        };
    }

    public Order CreateData(OrderDTO source)
    {
        Customer? customer = CustomerRepo?.Read(source.CustomerId);
        List<Product> products = source.ProductIds.Select(id => ProductRepo?.Read(id))
                                                  .Where(e => e != null).Select(e => e!)
                                                  .ToList();

        return new Order(
            source.Id, 
            customer, 
            products);
    }
}
