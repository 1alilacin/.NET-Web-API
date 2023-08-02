using APIHomework.DAL.Entities;
using APIHomework.DAL.Repository;

namespace APIHomework.Services
{
    public class OrderItemService : IOrderItemService
    {
        private IOrderItemRepository _repository;
        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _repository = orderItemRepository;
        }
        public void AddOrderItem(OrderItem orderItem)
        {
           _repository.AddOrderItem(orderItem);
        }

        public void DeleteOrderItem(int id)
        {
            _repository.DeleteOrderItem(id);
        }

        public List<OrderItem> GetAllOrderItem()
        {
            return _repository.GetAllOrderItem();
        }

        public OrderItem GetOrderItemById(int id)
        {
            return _repository.GetOrderItemById(id);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _repository.UpdateOrderItem(orderItem);
        }
    }
}
