﻿using EComPayApp.Application.Features.CQRS.Commands.Customers.CreateCustomer;
using EComPayApp.Application.Features.CQRS.Commands.Customers.DeleteCustomer;
using EComPayApp.Application.Features.CQRS.Commands.Customers.UpdateCustomer;
using EComPayApp.Application.Features.CQRS.Commands.Images.CreateImage;
using EComPayApp.Application.Features.CQRS.Commands.Images.DeleteImage;
using EComPayApp.Application.Features.CQRS.Commands.Images.UpdateImage;
using EComPayApp.Application.Features.CQRS.Queries;
using EComPayApp.Application.Features.CQRS.Queries.Customer.GetCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComPayApp.API.Controllers
{
    [Route("api/Images")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]

    public class ImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all images
        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var query = new GetImageQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Get a image by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            var query = new GetImageQuery { Id = id };
            var result = await _mediator.Send(query);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        // Create a new image
        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateImageCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
        }

        // Update an existing image
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(Guid id, UpdateImageCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID uyğunsuzluğu");
            }

            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        // Delete a image
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var command = new DeleteImageCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

    }
}
