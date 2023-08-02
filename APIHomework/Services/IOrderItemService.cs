using APIHomework.DAL.Entities;

namespace APIHomework.Services
{
    public interface IOrderItemService
    {
        List<OrderItem> GetAllOrderItem();
        void AddOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(int id);
        OrderItem GetOrderItemById(int id);
    }
}
