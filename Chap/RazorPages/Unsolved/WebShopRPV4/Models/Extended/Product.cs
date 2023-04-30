
public partial class Product : IHasId, IHasName, IHasOrders, IUpdateFromOther<Product>
{
    public bool HasAnyOrders => Orders != null && Orders.Count > 0;

    public void Update(Product tOther)
    {
        Name = tOther.Name;
        Price = tOther.Price;
    }
}
