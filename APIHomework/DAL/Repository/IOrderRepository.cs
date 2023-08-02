using APIHomework.DAL.Entities;

namespace APIHomework.DAL.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        void AddOrder(Order order);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
        Order GetOrderById(int id);

        public int AddOrderGetId(Order order);
    }
}
