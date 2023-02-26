using RazorPageEFCDemo.Services.Repositories.General.Interfaces;

namespace RazorPageEFCDemo.Models
{
    public class Order : IHasID, IUpdateFromOther<Order>
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; private set; }
        public int ItemID { get; set; }
        public Item Item { get; private set; }
        public int Amount { get; set; }

        public Order()
        {
        }

        // NB: EF-Core specific constructor.
        // EFC will resolve foreignkey IDs to references.
        public Order(int id, int customerId, int itemId, int amount)
        {
            ID = id;
            CustomerID = customerId;
            ItemID = itemId;
            Amount = amount;
        }

        public void Update(Order tOther)
        {
            CustomerID = tOther.CustomerID;
            ItemID = tOther.ItemID;
            Amount = tOther.Amount;
        }
    }
}
