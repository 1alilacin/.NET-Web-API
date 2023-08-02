using APIHomework.DAL.Entities;

namespace APIHomework.DAL.Repository
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetAllOrderItem();
        void AddOrderItem(OrderItem orderItem);
        void AddOrderItems(List<OrderItem> orderItems);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(int id);
        OrderItem GetOrderItemById(int id);
        int AddOrderItemById(OrderItem orderItems);


    }
}
