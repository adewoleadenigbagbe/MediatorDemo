using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatorDemo.Commands;
using MediatorDemo.Models;
using MediatorDemo.Queries;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorDemo
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var query = new GetProducts.Query();
            var products = await _mediator.Send(query);

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var command = new CreateProduct.Command();
            command.Id =  product.Id;
            command.Name = product.Name;
            await _mediator.Send(command);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById([FromRoute] int id)
        {
            var query = new GetProductById.Query
            {
                Id = id
            };
            var products = await _mediator.Send(query);

            return Ok(products);
        }
    }
}
