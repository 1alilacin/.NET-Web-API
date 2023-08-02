using APIHomework.DAL.Entities;
using APIHomework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public IActionResult GetOrderItem()
        {
            var values = _orderItemService.GetAllOrderItem();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderItemById(int id)
        {
            var values = _orderItemService.GetOrderItemById(id);
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddOrderIten(OrderItem orderItem)
        {
            _orderItemService.AddOrderItem(orderItem);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteOrderIten(int id)
        {
            _orderItemService.DeleteOrderItem(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateOrderItem(OrderItem orderItem)
        {
            _orderItemService.UpdateOrderItem(orderItem);
            return Ok();
        }
    }
}
