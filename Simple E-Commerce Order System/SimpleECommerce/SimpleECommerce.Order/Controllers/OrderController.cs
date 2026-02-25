using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleECommerce.Order.UseCases.Commands.Orders;

namespace SimpleECommerce.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly ISender _sender;
        public OrderController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);

        }

        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            var command = new CancelOrderCommand { OrderId = id };
            await _sender.Send(command);
            return NoContent();
        }
    }
}
