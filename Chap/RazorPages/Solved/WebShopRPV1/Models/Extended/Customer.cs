
public partial class Customer : IHasId, IHasName, IHasOrders, IUpdateFromOther<Customer>
{
    public void Update(Customer tOther)
    {
        Name = tOther.Name;
        Address = tOther.Address;
        Email = tOther.Email;
    }
}
