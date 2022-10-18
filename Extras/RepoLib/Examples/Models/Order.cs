    
public class Order : ModelBase<Order>
{
    public Customer? Customer { get; set; }
    public List<Product> Products { get; set; }

    public double TotalPrice
    {
        get 
        {
            double totalPrice = 0.0;

            foreach (Product product in Products)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
        }
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
