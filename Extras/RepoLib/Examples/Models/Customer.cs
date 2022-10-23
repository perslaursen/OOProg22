
/// <summary>
/// Customer model class. All properties have simple types.
/// </summary>
public class Customer : ModelBase<Customer>
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public Customer(int id, string name, string phone, string address) 
        : base(id)
    {
        Name = name;
        Phone = phone;
        Address = address;
    }

    public Customer(string name, string phone, string address)
        : this(0, name, phone, address)
    {
    }

    public override string ToString()
    {
        return base.ToString() + $" ({Name}, Address: {Address}, Phone: {Phone}.)";
    }
}
