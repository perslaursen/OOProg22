using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageADODemo.Services.Repositories.General.Model;
using System.ComponentModel.DataAnnotations;

namespace RazorPageADODemo.Pages.Order
{
    public class CreateOrderModel : PageModel
    {
        private IOrderRepository _orderRepository;
        private IItemRepository _itemRepository;
        private ICustomerRepository _customerRepository;

        [BindProperty]
        [Display(Name = "Item")]
        public int ChosenItemId { get; set; }

        public SelectList ItemList { get; set; }

        [BindProperty]
        [Display(Name = "Customer")]
        public int ChosenCustomerId { get; set; }

        public SelectList CustomerList { get; set; }

        [BindProperty]
        [Range(1, 100)]
        public int Amount{ get; set; }


        public CreateOrderModel(IOrderRepository repository, IItemRepository itemRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = repository;
            _itemRepository = itemRepository;
            _customerRepository = customerRepository;

            List<Models.Item> selectableItems = _itemRepository.GetAll().ToList();
            ItemList = new SelectList(selectableItems, nameof(Models.Item.ID), nameof(Models.Item.Name));

            List<Models.Customer> selectableCustomers = _customerRepository.GetAll().ToList();
            CustomerList = new SelectList(selectableCustomers, nameof(Models.Customer.ID), nameof(Models.Customer.Name));

        }

        public virtual IActionResult OnGet()
        {
            return Page();
        }

        public virtual IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Models.Order order = new Models.Order(0, _customerRepository.Read(ChosenCustomerId), _itemRepository.Read(ChosenItemId), Amount);
            _orderRepository.Create(order);

            return RedirectToPage("GetAllOrders");
        }
    }
}
