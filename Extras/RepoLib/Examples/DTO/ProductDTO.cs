
public class ProductDTO : DTOBase
{
    public string Description { get; set; }
    public double Price { get; set; }

    public ProductDTO()
    {
        Description = "";
        Price = 0.0;
    }

    public ProductDTO(Product product)
    {
        Id = product.Id;
        Description = product.Description;
        Price = product.Price;
    }

    public Product Convert()
    {
        return new Product(Id, Description, Price);
    }
}
