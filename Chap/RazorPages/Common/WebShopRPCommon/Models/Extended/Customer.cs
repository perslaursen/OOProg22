
public partial class Customer : IHasId, IHasName, IHasOrders, IUpdateFromOther<Customer>
{
    public bool HasAnyOrders => Orders != null && Orders.Count > 0;

    public void Update(Customer tOther)
    {
        Name = tOther.Name;
        Address = tOther.Address;
        Email = tOther.Email;
    }
}
