using EComPayApp.Application.Features.CQRS.Commands.Contact.CreateContact;
using EComPayApp.Application.Features.CQRS.Commands.Contact.DeleteContact;
using EComPayApp.Application.Features.CQRS.Commands.Contact.UpdateContact;
using EComPayApp.Application.Features.CQRS.Queries.Contact.GetContact;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComPayApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(Guid id)
        {
            var query = new GetContactQuery { Id = id };
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetContact), new { id = result.ContactId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(Guid id, [FromBody] UpdateContactCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Mismatched IDs");
            }

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var command = new DeleteContactCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}
