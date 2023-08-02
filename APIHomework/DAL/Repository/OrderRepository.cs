using APIHomework.DAL.Context;
using APIHomework.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIHomework.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private ProductContext _productContext;
        public OrderRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public void AddOrder(Order order)
        {
            _productContext.Orders.Add(order);
            _productContext.SaveChanges();
        }
        public int AddOrderGetId(Order order)
        {
            _productContext.Orders.Add(order);
            _productContext.SaveChanges();
            return order.Id;
        }

        public void DeleteOrder(int id)
        {
            var values = (GetOrderById(id));
            if (values == null)
            {
                return;
            }
            _productContext.Orders.Remove(values);
            _productContext.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            return _productContext.Orders.Include(s => s.OrderItems).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _productContext.Orders.Include(s => s.OrderItems).SingleOrDefault(s => s.Id == id);
        }

        public void UpdateOrder(Order order)
        {
            Order newOrder = GetOrderById(order.Id);
            newOrder.OrderItems = order.OrderItems;
            newOrder.OrderDate = order.OrderDate;
            newOrder.CustomerName = order.CustomerName;
            newOrder.TotalAmount = order.TotalAmount;
            _productContext.Orders.Update(newOrder);
            _productContext.SaveChanges();
        }
    }
}
