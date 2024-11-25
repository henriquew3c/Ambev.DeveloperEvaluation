using Ambev.DeveloperEvaluation.Common.Extensions;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Repository;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Enums;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Factory;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Repository;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.IO.Pipelines;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public UpdateSaleHandler(ISaleRepository saleRepository, 
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
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var updatedSale = command.Map();

        if (!updatedSale.IsValid)
            throw new ValidationException(updatedSale.ValidationResult.Errors);

        if (!command.SaleId.ValidGuid())
        {
            throw new ValidationException(
                new List<ValidationFailure> { new ValidationFailure(command.SaleId, $"Sale id is not valid.") }
            );
        }

        var oldSale = await _saleRepository.GetByIdAsync(Guid.Parse(command.SaleId), cancellationToken);
        if (oldSale == null)
        {
            throw new ValidationException(
                new List<ValidationFailure> { new ValidationFailure(command.SaleId, $"Sale not found.") }
            );
        }

        if(oldSale.Status == SaleStatus.Cancelled)
        {
            throw new ValidationException(
                new List<ValidationFailure> { new ValidationFailure(command.SaleId, $"Sale is cancelled. Update not allowed.") }
            );
        }

        if (oldSale.Status == SaleStatus.Finish)
        {
            throw new ValidationException(
                new List<ValidationFailure> { new ValidationFailure(command.SaleId, $"Sale is finish. Update not allowed.") }
            );
        }

        var saleProducts = SaleProductsFactory.Create(command.Products);

        if (saleProducts.Any(product => product.IsInvalid))
        {
            var failures = saleProducts.Where(t => t.IsInvalid).Select(x => x.ValidationResult.Errors).ToList().FirstOrDefault();
            throw new ValidationException(failures);
        }

        if (command.Status != SaleStatus.Pending && command.Status != SaleStatus.Cancelled && command.Status != SaleStatus.Finish)
        {
            throw new ValidationException(
                new List<ValidationFailure> { new ValidationFailure(command.SaleId, $"Invalid status. Supported: 1 (Pending), 2 (Cancelled) or 3 (Finish).") }
            );
        }

        oldSale = ValidateAndAddProductsIntoSale(oldSale, saleProducts);

        oldSale?.Update(updatedSale, command.Status);
        oldSale?.ApplyDiscountAmount();
        oldSale?.ApplyTotalAmount();
        
        await _saleRepository.UpdateAsync(oldSale, cancellationToken);
        var result = _mapper.Map<UpdateSaleResult>(oldSale);
        result.Status = oldSale.Status.ToString();
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
        sale?.ClearProducts();

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