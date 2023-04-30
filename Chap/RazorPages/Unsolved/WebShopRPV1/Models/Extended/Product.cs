
public partial class Product : IHasId, IHasName, IHasOrders, IUpdateFromOther<Product>
{
    public void Update(Product tOther)
    {
        Name = tOther.Name;
        Price = tOther.Price;
    }
}
