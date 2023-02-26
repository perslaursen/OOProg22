using RazorPageADODemo.Services.Repositories.General.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RazorPageADODemo.Models
{
    public class Order : IHasId
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "A Customer must be chosen")]
        public Customer? Customer { get; set; }

        [Required(ErrorMessage = "An Item must be chosen")]
        public Item? Item { get; set; }

        [Required(ErrorMessage = "An Amount between 1 and 100 must be chosen")]
        [Range(1, 100)]
        public int Amount { get; set; }

        public Order()
        {

        }

        public Order(int id, Customer? customer, Item? item, int amount)
        {
            ID = id;
            Customer = customer;
            Item = item;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"({ID}) -> {(Customer?.Name ?? "(none")},  {(Item?.Name ?? "(none")} {Amount}"; 
        }
    }
}
