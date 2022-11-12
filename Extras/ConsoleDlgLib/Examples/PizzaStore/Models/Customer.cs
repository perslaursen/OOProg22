
public class Customer : IId
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }


    public Customer(int id, string name, string phone, string address)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Address = address;
    }

    public Customer()
    {
        Name = "";
        Phone = "";
        Address = "";
    }

    public override string ToString()
    {
        return $"{Id} - {Name}, Address: {Address}, Phone: {Phone}.";
    }
}
