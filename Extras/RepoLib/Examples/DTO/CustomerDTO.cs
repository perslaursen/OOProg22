
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

    public CustomerDTO(Customer customer)
    {
        Id = customer.Id;
        Name = customer.Name;
        Phone = customer.Phone;
        Address = customer.Address;
    }

    public Customer Convert()
    {
        return new Customer(Id, Name, Phone, Address);
    }
}
