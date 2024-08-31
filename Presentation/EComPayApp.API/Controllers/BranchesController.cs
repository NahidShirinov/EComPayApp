using EComPayApp.Application.Features.CQRS.Commands.Branches.CreateBranch;
using EComPayApp.Application.Features.CQRS.Commands.Branches.DeleteBranch;
using EComPayApp.Application.Features.CQRS.Commands.Branches.UpdateBranch;
using EComPayApp.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EComPayApp.API.Controllers
{
    [Route("api/branch")]
    [Authorize(AuthenticationSchemes = "Admin")]

    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all branches
        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var query = new GetBranchQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Get a branch by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranchById(Guid id)
        {
            var query = new GetBranchQuery { Id = id };
            var result = await _mediator.Send(query);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        // Create a new branch
        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
        }

        // Update an existing branch
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(Guid id, UpdateBranchCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID uyğunsuzluğu");
            }

            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        // Delete a branch
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(Guid id)
        {
            var command = new DeleteBranchCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }
    
    }
}
