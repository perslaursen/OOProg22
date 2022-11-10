using System.Text.Json.Serialization;

namespace ItemRazorV1.Models
{
    public class OrderLine
    {
        private static int _nextId = 0;

        public int Id { get; set; }
        public Item Item { get; set; }
        public int Amount { get; set; }

        [JsonIgnore]
        public double TotalPrice { get { return (Item.Price ?? 0) * Amount; } }

        public OrderLine(Item item, int amount) : this(++_nextId, item, amount) { }

        public OrderLine(int id, Item item, int amount)
        {
            Id = id;
            Item = item;
            Amount = amount;
        }

        public OrderLine() { }

        public override string ToString() { return $"{Item.Name} x {Amount}"; }
    }
}
