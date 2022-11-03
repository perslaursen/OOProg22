using System.Text.Json.Serialization;

namespace ItemRazorV1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public List<OrderLine> Items { get; set; } = new List<OrderLine>();
        public string? Remark { get; set; }

        [JsonIgnore]
        public double TotalPrice  { get { return Items.Select(i => i.TotalPrice).Sum(); } }

        [JsonIgnore]
        public string ItemsSummary { get { return string.Join(" , ", Items); } }

        [JsonIgnore]
        public string CustomerInfo { get { return Customer?.Name ?? "(none)"; } }

        public Order() { }

        public Order(int id, Customer? customer) { Id = id; Customer = customer; }

        public OrderLine? GetOrderLine(int itemId) { return Items.FirstOrDefault(i => i.Item.Id == itemId); }
    }
}
