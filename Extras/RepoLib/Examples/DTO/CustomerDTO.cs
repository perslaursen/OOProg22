
/// <summary>
/// DTO class corresponding to Customer model class.
/// Mapping is trivial, since Customer only contains properties of simple types.
/// </summary>
public class CustomerDTO : DTOBase
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public CustomerDTO()
    {
        Name = "";
        Phone = "";
        Address = "";
    }
}
