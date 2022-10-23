
/// <summary>
/// Product model class. All properties have simple types.
/// </summary>
public class Product : ModelBase<Product>
{
    public string Description { get; set; }
    public double Price { get; set; }

    public Product(int id, string description, double price) 
        : base(id)
    {
        Description = description;
        Price = price;
    }

    public Product(string description, double price) 
        : this(0, description, price)
    {
    }

    public override string ToString()
    {
        return base.ToString() + $" ({Description}, Price: {Price}.)";
    }
}
