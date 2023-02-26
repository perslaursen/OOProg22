
using RazorPageEFCDemo.Services.Repositories.General.Interfaces;

namespace RazorPageEFCDemo.Models
{
    public class Item : IHasID, IUpdateFromOther<Item>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Item()
        {
        }

        public Item(int id, string name, double price)
        {
            ID = id;
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
