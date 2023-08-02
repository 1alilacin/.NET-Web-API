using APIHomework.DAL.Entities;
using APIHomework.DAL.Repository;
using APIHomework.Dtos;

namespace APIHomework.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IProductService _productService;
        private IOrderItemRepository _orderItemRepository;
        public OrderService(IOrderRepository orderRepository, IProductService productService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            //_orderItemRepository = orderItemRepository;
        }
        public void CreateOrder(CreateOrderRequest createOrderRequest)
        {
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            // int orderId = _orderRepository.AddOrderGetId(order);
            // order = _orderRepository.GetOrderById(orderId);
            List<OrderItem> orderItems = new List<OrderItem>();
            order.CustomerName = createOrderRequest.CustomerName;
            decimal TotalAmount = 0;
            foreach (var productRequest in createOrderRequest.Products)
            {
                var product = _productService.GetProductById(productRequest.ProductId);
                OrderItem item = new OrderItem();
                //  var orderItemId = _orderItemRepository.AddOrderItemById(item);
                // item = _orderItemRepository.GetOrderItemById(orderItemId);
                item.ProductId = productRequest.ProductId;
                item.OrderId = order.Id;
                item.Quantity = productRequest.Count;
                orderItems.Add(item);
                var itemPrice = item.Quantity * product.Price;
                TotalAmount += itemPrice;

            }
            order.OrderItems = orderItems;

            order.TotalAmount = TotalAmount;
            _orderRepository.AddOrder(order);
            //_orderItemRepository.AddOrderItems(orderItems);
            //_orderRepository.UpdateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }
    }
}
