using ItemRazorV1.MockData;
using ItemRazorV1.Models;

namespace ItemRazorV1.Service
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customers;

        private JsonFileCustomerService JsonFileCustomerService { get; set; }

        public CustomerService(JsonFileCustomerService jsonFileCustomerService)
        {
            JsonFileCustomerService = jsonFileCustomerService;
            // _customers = MockCustomers.GetMockCustomers();
            _customers = JsonFileCustomerService.GetJsonCustomers().ToList();
        }

        public CustomerService()
        {
            _customers = MockCustomers.GetMockCustomers();
        }

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
            JsonFileCustomerService.SaveJsonCustomers(_customers);
        }

        public Customer GetCustomer(int id)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.Id == id)
                    return customer;
            }

            return null;
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                foreach (Customer c in _customers)
                {
                    if (c.Id == customer.Id)
                    {
                        c.Name = customer.Name;
                        c.Email= customer.Email;
                        c.Address = customer.Address;
                    }
                }
                JsonFileCustomerService.SaveJsonCustomers(_customers);
            }
        }

        public Customer DeleteCustomer(int? id)
        {
            Customer customerToBeDeleted = null;
            foreach (Customer customer in _customers)
            {
                if (customer.Id == id)
                {
                    customerToBeDeleted = customer;
                    break;
                }
            }

            if (customerToBeDeleted != null)
            {
                _customers.Remove(customerToBeDeleted);
                JsonFileCustomerService.SaveJsonCustomers(_customers);
            }

            return customerToBeDeleted;
        }

        public List<Customer> GetCustomers() { return _customers; }

        public IEnumerable<Customer> NameSearch(string str)
        {
            List<Customer> nameSearch = new List<Customer>();
            foreach (Customer customer in _customers)
            {
                if (string.IsNullOrEmpty(str) || customer.Name.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(customer);
                }
            }

            return nameSearch;
        }
    }
}
