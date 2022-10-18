
public class OrderDTO : DTOBase
{
    public int CustomerId { get; set; }
    public List<int> ProductIds { get; set; }

    public OrderDTO()
    {
        CustomerId = 0;
        ProductIds = new List<int>();
    }

    public OrderDTO(Order order)
    {
        Id = order.Id;
        CustomerId = order.Customer?.Id ?? 0;

        List<int> productIds = new List<int>();
        foreach (Product product  in order.Products)
        {
            productIds.Add(product.Id);
        }
        ProductIds = productIds;
    }

    public Order Convert(CustomerRepository customerRepo, ProductRepository productRepo)
    {
        Customer? customer = customerRepo.Read(CustomerId);
        List<Product> products = new List<Product>();
        foreach (int productId in ProductIds)
        {
            Product? product = productRepo.Read(productId);
            if (product != null)
                products.Add(product);
        }

        return new Order(Id, customer, products);
    }
}
