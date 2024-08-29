using EComPayApp.Application.Features.CQRS.Commands.OrderItems.CreateOrderItem;
using EComPayApp.Application.Features.CQRS.Commands.OrderItems.DeleteOrderItem;
using EComPayApp.Application.Features.CQRS.Commands.Orders.UpdateImage;
using EComPayApp.Application.Features.CQRS.Queries;
using EComPayApp.Application.Features.CQRS.Queries.OrderItems.GetOrderItem;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComPayApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all orderitem
        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems()
        {
            var query = new GetOrderItemQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Get a orderitem by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(Guid id)
        {
            var query = new GetOrderItemQuery { Id = id };
            var result = await _mediator.Send(query);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        // Create a new OrderItem
        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(CreateOrderItemCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
        }

        // Update an existing OrderItem
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(Guid id, UpdateOrderCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID uyğunsuzluğu");
            }

            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        // Delete a OrderItem
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            var command = new DeleteOrderItemCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

    }
}
