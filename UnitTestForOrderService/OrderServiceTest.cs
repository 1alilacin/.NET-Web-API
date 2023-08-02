using APIHomework.DAL.Context;
using APIHomework.DAL.Entities;
using APIHomework.DAL.Repository;
using APIHomework.Dtos;
using APIHomework.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;

namespace UnitTestForOrderService
{
    public class OrderServiceTest
    {
        CreateOrderRequest createOrderRequest = new CreateOrderRequest() { CustomerName = "Mehmet", Products = new List<ProductIdCountDto>() { new ProductIdCountDto { ProductId = 1, Count = 5 } } };
        private IOrderService _orderService;
        private Mock<IOrderRepository> _orderRepository = new Mock<IOrderRepository>();
        private Mock<IProductService> _productService = new Mock<IProductService>();
        Order TestOrder = new Order() { Id = 5, CustomerName = "Ali", OrderItems = new List<OrderItem>() { new OrderItem { ProductId = 1, Quantity = 5 } } };
        public OrderServiceTest()
        {
            SetupData();
            _orderService = new OrderService(_orderRepository.Object, _productService.Object);
        }
        private void SetupData()
        {
            _orderRepository.Setup(x => x.GetOrderById(It.IsAny<int>()))
                .Returns(TestOrder);
        }

        [Test]
        public void Get_OrdersByIdShouldReturnOrder()
        {
            var order = _orderService.GetOrderById(TestOrder.Id);
            order.Id.Should().Be(TestOrder.Id);
        }

        [Test]
        public void DeleteOrdersShouldDeleteOrders()
        {
            _orderService.DeleteOrder(TestOrder.Id);
            _orderRepository.Verify(x => x.DeleteOrder(TestOrder.Id));
        }

        [Test]
        public void UpdateOrderShouldUpdateOrder()
        {
            var order = _orderService.GetOrderById(TestOrder.Id);
            order.CustomerName = "Test";
            _orderService.UpdateOrder(order);
            order.CustomerName.Should().Be(TestOrder.CustomerName);
        }

        [Test]
        public void GetAllOrdersShouldReturnOrder()
        {
            _orderRepository.Setup(x => x.GetAllOrders())
                .Returns(new List<Order>() { new Order { Id = 2, CustomerName = "Mehmet" } });
            List<Order> results = _orderService.GetAllOrders();
            results.Should().HaveCount(1);
        }
        [Test]
        public void CreateOrderShouldReturnCreateOrder()
        {
            var Product = new Product();
            Product.Price = 500;
            _orderService.CreateOrder(createOrderRequest);
            TestOrder.TotalAmount = createOrderRequest.Products.Count * Product.Price;
            TestOrder.TotalAmount.Should().Be(2500);
        }
    }
}
