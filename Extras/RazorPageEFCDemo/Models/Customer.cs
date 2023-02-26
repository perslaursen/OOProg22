
using RazorPageEFCDemo.Services.Repositories.General.Interfaces;

namespace RazorPageEFCDemo.Models
{
    public class Customer : IHasID, IUpdateFromOther<Customer>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Customer()
        {
        }

        public Customer(int id, string name, string email, string address)
        {
            ID = id;
            Name = name;
            Email = email;
            Address = address;
        }

        public void Update(Customer tOther)
        {
            Name = tOther.Name;
            Email = tOther.Email;
            Address = tOther.Address;
        }
    }
}
