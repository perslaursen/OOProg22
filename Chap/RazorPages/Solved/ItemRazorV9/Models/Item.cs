using ItemRazorV1.Service.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ItemRazorV1.Models
{
    public class Item : IHasId, IUpdateFromOther<Item>
    {
        public int Id { get; set; }

        [Display(Name = "Item Navn")]
        [Required(ErrorMessage = "Item skal have et navn")]
        public string? Name { get; set; }

        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Der skal angives en pris")]
        public double? Price { get; set; }

        public Item()
        {
        }

        public Item(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public void Update(Item tOther)
        {
            Name = tOther.Name;
            Price = tOther.Price;
        }
    }
}
