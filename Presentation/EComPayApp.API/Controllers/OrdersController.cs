using EComPayApp.Application.Features.CQRS.Commands.Orders.CreateOrder;
using EComPayApp.Application.Features.CQRS.Commands.Orders.DeleteImage;
using EComPayApp.Application.Features.CQRS.Commands.Orders.UpdateImage;
using EComPayApp.Application.Features.CQRS.Queries.Order.GetOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComPayApp.API.Controllers
{
    [Route("api/Orders")]
    [Authorize(AuthenticationSchemes = "Admin")]

    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var query = new GetOrderQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var query = new GetOrderQuery { Id = id };
            var result = await _mediator.Send(query);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdateOrderCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID uyğunsuzluğu");
            }

            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var command = new DeleteOrderCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }
    
    }
}
