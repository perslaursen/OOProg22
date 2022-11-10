using ItemRazorV1.Service.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ItemRazorV1.Models
{
    public class Customer : IHasId, IUpdateFromOther<Customer>
    {
        public int Id { get; set; }

        [Display(Name = "Customer Navn")]
        [Required(ErrorMessage = "Customer skal have et navn")]
        public string? Name { get; set; }

        [Display(Name = "Customer E-mail")]
        [Required(ErrorMessage = "Customer skal have en e-mail adresse")]
        [EmailAddress(ErrorMessage = "Ugyldig e-mail adresse")]
        public string? Email { get; set; }

        [Display(Name = "Customer Adresse")]
        [Required(ErrorMessage = "Customer skal have en adresse")]
        public string? Address { get; set; }

        public Customer()
        {
        }

        public Customer(int id, string name, string email, string address)
        {
            Id = id;
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
