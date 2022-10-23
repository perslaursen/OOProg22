
/// <summary>
/// DTO class corresponding to Order model class.
/// Mapping is non-trivial, since Order contains properties of class types.
/// Object references are thus mapped to ids.
/// </summary>
public class OrderDTO : DTOBase
{
    public int CustomerId { get; set; }
    public List<int> ProductIds { get; set; }

    public OrderDTO()
    {
        CustomerId = 0;
        ProductIds = new List<int>();
    }
}
