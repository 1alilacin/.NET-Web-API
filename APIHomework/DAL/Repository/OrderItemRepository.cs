using APIHomework.DAL.Context;
using APIHomework.DAL.Entities;

namespace APIHomework.DAL.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private ProductContext _orderContext;
        public OrderItemRepository(ProductContext productContext)
        {
            _orderContext = productContext;
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            _orderContext.Items.Add(orderItem);
            _orderContext.SaveChanges();
        }

        public int AddOrderItemById(OrderItem orderItems)
        {
            _orderContext.Items.Add(orderItems);
            _orderContext.SaveChanges();
            return orderItems.Id;
        }

        public void AddOrderItems(List<OrderItem> orderItems)
        {
            _orderContext.Items.AddRange(orderItems);
            _orderContext.SaveChanges();
        }

        public void DeleteOrderItem(int id)
        {
            _orderContext.Items.Remove(GetOrderItemById(id));
            _orderContext.SaveChanges();
        }

        public List<OrderItem> GetAllOrderItem()
        {
            return _orderContext.Items.ToList();
        }

        public OrderItem GetOrderItemById(int id)
        {
            return _orderContext.Items.Find(id);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            OrderItem orderItem1 = GetOrderItemById(orderItem.Id);
            orderItem1.Id = orderItem.Id;
            orderItem1.OrderId = orderItem.OrderId;
            orderItem1.ProductId = orderItem.ProductId;
            orderItem1.Quantity = orderItem.Quantity;
            _orderContext.Items.Update(orderItem1);
            _orderContext.SaveChanges();
        }
    }
}
