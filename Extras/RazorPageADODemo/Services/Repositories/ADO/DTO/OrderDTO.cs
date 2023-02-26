using RazorPageADODemo.Models;
using RazorPageADODemo.Services.Repositories.General.Interfaces;

namespace RazorPageADODemo.Services.Repositories.ADO.DTO
{
    public class OrderDTO : IHasId
    {
        public int ID { get; set; }

        public int? CustomerId { get; set; }

        public int? ItemId { get; set; }

        public int Amount { get; set; }

        public OrderDTO(int id, int? customerId, int? itemId, int amount)
        {
            ID = id;
            CustomerId = customerId;
            ItemId = itemId;
            Amount = amount;
        }

        public OrderDTO(Order order)
        {
            ID = order.ID;
            CustomerId = order.Customer?.ID;
            ItemId = order.Item?.ID;
            Amount = order.Amount;
        }
    }
}
