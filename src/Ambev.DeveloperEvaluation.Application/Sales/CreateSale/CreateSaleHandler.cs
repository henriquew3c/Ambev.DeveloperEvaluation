using Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Repository;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Factory;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Repository;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CreateSaleHandler(ISaleRepository saleRepository, 
        IMapper mapper,
        IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _productRepository = productRepository;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = command.Map();

        if (!sale.IsValid)
            throw new ValidationException(sale.ValidationResult.Errors);

        var saleProducts = SaleProductsFactory.Create(command.Products);

        if (saleProducts.Any(product => product.IsInvalid))
        {
            var failures = saleProducts.Where(t => t.IsInvalid).Select(x => x.ValidationResult.Errors).ToList().FirstOrDefault();
            throw new ValidationException(failures);
        }

        sale = ValidateAndAddProductsIntoSale(sale, saleProducts);

        sale?.ApplyDiscountAmount();
        sale?.ApplyTotalAmount();

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }

    /// <summary>
    /// Validate if products exists and if is valid add into sale
    /// </summary>
    /// <param name="sale">The sale in process</param>
    /// <param name="products">List of the products to add into sale</param>
    /// <returns>The sale witch products inserted if all valid</returns>
    private Sale? ValidateAndAddProductsIntoSale(Sale? sale, List<SaleProduct> products)
    {
        foreach (var saleProduct in products)
        {
            var product = _productRepository.GetProductById(saleProduct.ProductId);

            if (product == null)
            {
                throw new ValidationException(
                    new List<ValidationFailure> { new ValidationFailure("products", $"Product with id {saleProduct.ProductId} not found.") }
                );
            }

            saleProduct.Product = product;
            sale?.AddProduct(saleProduct);
        }

        return sale;
    }
}