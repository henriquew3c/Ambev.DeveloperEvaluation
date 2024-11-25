using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products
{
    /// <summary>
    /// Controller for managing sales operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new sale.
        /// </summary>
        /// <param name="request">The create sale request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A response with the created sale data.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSale([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateProductCommand>(request);

            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
            {
                Success = true,
                Message = "Product created successfully",
                Data = _mapper.Map<CreateProductResponse>(response)
            });
        }

       
    }
}