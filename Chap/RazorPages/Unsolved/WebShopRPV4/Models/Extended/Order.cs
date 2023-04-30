
public partial class Order : IHasId, IUpdateFromOther<Order>
{
    public double TotalPrice => Amount * (Product?.Price ?? 0);

    public void Update(Order tOther)
    {
        CustomerId = tOther.CustomerId;
        ProductId = tOther.ProductId;
        Amount = tOther.Amount;
    }
}