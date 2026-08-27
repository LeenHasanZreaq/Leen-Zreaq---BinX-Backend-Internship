using Microsoft.AspNetCore.Mvc;
using MyWebProject.DTOs;

namespace MyWebProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderItemsController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{orderId}/items")]
        public async Task<IActionResult> AddItem(int orderId, [FromBody] CreateOrderItemRequest request)
        {
            var result = await _orderService.AddOrderItemAsync(orderId, request);
            return Ok(result);
        }

        [HttpDelete("{orderId}/items/{itemId}")]
        public async Task<IActionResult> RemoveItem(int orderId, int itemId)
        {
            await _orderService.RemoveOrderItemAsync(orderId, itemId);
            return NoContent();
        }
    }
}
