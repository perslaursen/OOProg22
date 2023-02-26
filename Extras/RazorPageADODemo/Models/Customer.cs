
using RazorPageADODemo.Services.Repositories.General.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RazorPageADODemo.Models
{
    public class Customer : IHasId
    {
        public int ID { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer must have a name")]
        public string? Name { get; set; }

        [Display(Name = "Customer E-mail")]
        [Required(ErrorMessage = "Customer must have an e-mail address")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        public string? Email { get; set; }

        [Display(Name = "Customer Address")]
        [Required(ErrorMessage = "Customer must have an address")]
        public string? Address { get; set; }

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
    }
}
