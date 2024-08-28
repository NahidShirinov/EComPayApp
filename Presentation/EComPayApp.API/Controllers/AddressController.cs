using EComPayApp.Application.Features.CQRS.Commands.Address.CreateAddress;
using EComPayApp.Application.Features.CQRS.Commands.Address.DeleteAddress;
using EComPayApp.Application.Features.CQRS.Commands.Address.UpdateAddress;
using EComPayApp.Application.Features.CQRS.Queries.Address.GetAddress;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EComPayApp.API.Controllers
{
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all addresses
        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var query = new GetAddressQuery(); // Bu sorğu GetAllAddressesQuery sınıfı tərəfindən təmin edilməlidir
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Get an address by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(Guid id)
        {
            var query = new GetAddressQuery { Id = id };
            var result = await _mediator.Send(query);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        // Create a new address
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
        }

        // Update an existing address
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(Guid id, UpdateAddressCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID uyğunsuzluğu");
            }

            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        // Delete an address
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            var command = new DeleteAddressCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }
    
    }
}
