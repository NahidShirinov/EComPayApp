using EComPayApp.Application.Features.CQRS.Commands.About.CreateAbout;
using EComPayApp.Application.Features.CQRS.Commands.About.DeleteAbout;
using EComPayApp.Application.Features.CQRS.Commands.About.UpdateAbout;
using EComPayApp.Application.Features.CQRS.Queries.About.GetAbout;
using EComPayApp.Application.Features.CQRS.Queries.Customer.GetCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComPayApp.API.Controllers
{
    [Route("api/Abouts")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]

    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
            var query = new GetAboutQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(Guid id)
        {
            var query = new GetAboutQuery { Id = id };
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetAbout), new { id = result.AboutId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbout(Guid id, [FromBody] UpdateAboutCommand command)
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
        public async Task<IActionResult> DeleteAbout(Guid id)
        {
            var command = new DeleteAboutCommand{ Id = id };
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}
