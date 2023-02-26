using RazorPageADODemo.Services.Repositories.General.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RazorPageADODemo.Models
{
    public class Item : IHasId
    {
        public int ID { get; set; }

        [Display(Name = "Item Name")]
        [Required(ErrorMessage = "Item must have a name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Item must have a price")]
        public double? Price { get; set; }

        public Item()
        {
        }

        public Item(int id, string name, double price)
        {
            ID = id;
            Name = name;
            Price = price;
        }
    }
}
