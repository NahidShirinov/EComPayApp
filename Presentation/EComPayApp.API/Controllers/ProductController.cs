using EComPayApp.Application.Features.CQRS.Commands.Products.CreateProduct;
using EComPayApp.Application.Features.CQRS.Commands.Products.DeleteProduct;
using EComPayApp.Application.Features.CQRS.Commands.Products.UpdateProduct;
using EComPayApp.Application.Features.CQRS.Queries.Products.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EComPayApp.API.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetProductQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // Get a product by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var query = new GetProductQuery { Id = id };
            var result = await _mediator.Send(query);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        // Create a new product
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Message);
        }

        // Update an existing product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID uyğunsuzluğu");
            }

            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }

        // Delete a product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result) : NotFound(result.Message);
        }
    
    }
}
