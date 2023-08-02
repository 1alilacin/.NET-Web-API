using APIHomework.DAL.Entities;
using APIHomework.Dtos;
using APIHomework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }
        [HttpPost]
        public IActionResult CreateOrder(CreateOrderRequest createOrderRequest)
        {
            _orderService.CreateOrder(createOrderRequest);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            return Ok(order);
        }
        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateOrder(Order order)
        {
            _orderService.UpdateOrder(order);
            return Ok();
        }

    }
}
