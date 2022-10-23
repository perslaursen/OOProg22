
/// <summary>
/// DTO class corresponding to Product model class.
/// Mapping is trivial, since Product only contains properties of simple types.
/// </summary>
public class ProductDTO : DTOBase
{
    public string Description { get; set; }
    public double Price { get; set; }

    public ProductDTO()
    {
        Description = "";
        Price = 0.0;
    }
}
