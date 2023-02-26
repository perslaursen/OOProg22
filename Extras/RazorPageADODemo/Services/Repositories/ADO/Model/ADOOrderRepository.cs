using RazorPageADODemo.Models;
using RazorPageADODemo.Services.Repositories.ADO.DTO;
using RazorPageADODemo.Services.Repositories.General.Model;

namespace RazorPageADODemo.Services.Repositories.ADO.Model
{
    public class ADOOrderRepository : IOrderRepository
    {
        private ICustomerRepository _customerRepository;
        private IItemRepository _itemRepository;
        private IOrderDTORepository _orderDTORepository;

        public ADOOrderRepository(
            ICustomerRepository customerRepository, 
            IItemRepository itemRepository, 
            IOrderDTORepository orderDTORepository)
        {
            _customerRepository = customerRepository;
            _itemRepository = itemRepository;
            _orderDTORepository = orderDTORepository;
        }

        public List<Order> GetAll(string? whereCond = null)
        {
            return _orderDTORepository.GetAll().Select(oDTO => ResolveOrderDTO(oDTO)).ToList();
        }

        public int Create(Order order)
        {
            return _orderDTORepository.Create(new OrderDTO(order));
        }

        public Order? Read(int id)
        {
            OrderDTO? orderDTO = _orderDTORepository.Read(id);

            return orderDTO != null ? ResolveOrderDTO(orderDTO) : null;
        }

        public bool Update(int id, Order order)
        {
            return _orderDTORepository.Update(id, new OrderDTO(order));
        }

        public bool Delete(int id)
        {
            return _orderDTORepository.Delete(id);
        }

        private Order ResolveOrderDTO(OrderDTO orderDTO)
        {
            Customer? customer = orderDTO.CustomerId != null ? _customerRepository.Read(orderDTO.CustomerId.Value) : null;
            Item? item = orderDTO.ItemId != null ? _itemRepository.Read(orderDTO.ItemId.Value) : null;

            return new Order(orderDTO.ID, customer, item, orderDTO.Amount);
        }
    }
}
