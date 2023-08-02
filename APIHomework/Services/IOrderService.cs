using APIHomework.DAL.Entities;
using APIHomework.Dtos;

namespace APIHomework.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        void CreateOrder(CreateOrderRequest createOrderRequest);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
        Order GetOrderById(int id);
    }
}
