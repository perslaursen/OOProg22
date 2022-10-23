
/// <summary>
/// Order model class. Note that the class has a 1-0..1 relation to Customer,
/// and a 1-0..n relation to Product.
/// Also, the class contains a calculated property.
/// </summary>
public class Order : ModelBase<Order>
{
    public Customer? Customer { get; set; }
    public List<Product> Products { get; set; }

    public double TotalPrice
    {
        get { return Products.Select(e => e.Price).Sum(); }
    }

    public Order(int id, Customer? customer, List<Product> products) 
        : base(id)
    {
        Customer = customer;
        Products = products;
    }

    public Order(Customer? customer, List<Product> products)
        : this(0, customer, products)
    {
        Customer = customer;
        Products = products;
    }

    public override string ToString()
    {
        string prodList = "[" + string.Join(", ", Products.Select(s => s.Description)) + "]";

        return base.ToString() + $" (Customer: {Customer?.Name ?? "(none)"}, Products: {prodList}, Total: {TotalPrice:F2} kr.)";
    }
}
