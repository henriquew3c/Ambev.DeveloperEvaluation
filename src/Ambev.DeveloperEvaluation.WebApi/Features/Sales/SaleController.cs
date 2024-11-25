using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;

using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    /// <summary>
    /// Controller for managing sales operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public SaleController(IMediator mediator, IMapper mapper)
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
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateSaleCommand>(request);

            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<CreateSaleResponse>(response)
            });
        }


        /// <summary>
        /// Retrieves a sale by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetUserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
        {

            var command = _mapper.Map<GetSaleCommand>(id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetSaleResponse>
            {
                Success = true,
                Message = "Sale retrieved successfully",
                Data = _mapper.Map<GetSaleResponse>(response)
            });
        }


    }
}