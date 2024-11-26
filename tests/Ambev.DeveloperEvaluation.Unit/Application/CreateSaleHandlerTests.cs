using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Product.Repository;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.Repository;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale;
using Ambev.DeveloperEvaluation.Domain.Aggregate.Sale.DTO;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleHandler"/> class.
/// </summary>
public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _productRepository = Substitute.For<IProductRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSaleHandler(_saleRepository, _mapper, _productRepository);
    }

    /// <summary>
    /// Tests that a valid Sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid Sale data When creating Sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        var sale = command.Map();

        sale.Id = Guid.NewGuid();

        var products = CreateSaleProductsHandlerTestData.GenerateValidSaleProducts(1);
        products.ForEach(product => sale.AddProduct(product));

        command.Products =
            [..products.Select(p => new SaleProductDTO { ProductId = p.ProductId.ToString(), Quantity = p.Quantity })];

        var result = new CreateSaleResult
        {
            Id = sale.Id,
            CustomerId = sale.CustomerId,
            BranchId = sale.BranchId,
            CreateAt = sale.CreateAt,
            Products = sale.Products.Select(p => new CreateSaleItemResult { ProductId = p.ProductId.ToString(), Quantity = p.Quantity }).ToList(),
        };

        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        _productRepository.GetProductById(Arg.Any<Guid>()).Returns(sale.Products.First().Product);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid Sale creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid Sale data When creating Sale Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSaleCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid command When handling Then maps command to Sale entity")]
    public async Task Handle_ValidRequest_MapsCommandToSale()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        var sale = command.Map();

        sale.Id = Guid.NewGuid();

        var products = CreateSaleProductsHandlerTestData.GenerateValidSaleProducts(1);
        products.ForEach(product => sale.AddProduct(product));

        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        var result = new CreateSaleResult
        {
            Id = sale.Id,
        };

        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id);
    }

    /// <summary>
    /// Tests that validation discount when purchases 4-9 identical products.
    /// </summary>
    [Fact(DisplayName = "10% discount should be applied for 4-9 identical products")]
    public void Given_4To9IdenticalProducts_When_Calculated_Then_ShouldApply10PercentDiscount()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        var sale = command.Map();

        sale.Id = Guid.NewGuid();

        sale.ClearProducts();
        var product = CreateSaleProductsHandlerTestData.GenerateSaleProductTo10PercentDiscount();
        sale.AddProduct(product);

        // When
        sale.ApplyDiscountAmount();
        sale.ApplyTotalAmount();

        // Then
        Assert.Equal(450m, sale.TotalAmount);
    }

    /// <summary>
    /// Tests that validation discount when purchases 10-20 identical products.
    /// </summary>
    [Fact(DisplayName = "20% discount should be applied for 10-20 identical products")]
    public void Given_10To20IdenticalProducts_When_Calculated_Then_ShouldApply20PercentDiscount()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        var sale = command.Map();

        sale.Id = Guid.NewGuid();

        sale.ClearProducts();
        var product = CreateSaleProductsHandlerTestData.GenerateSaleProductTo20PercentDiscount();
        sale.AddProduct(product);

        // When
        sale.ApplyDiscountAmount();
        sale.ApplyTotalAmount();

        // Then
        Assert.Equal(800m, sale.TotalAmount);
    }

    /// <summary>
    /// Tests that validation discount when purchases  below 4 identical products.
    /// </summary>
    [Fact(DisplayName = "No discount should be applied for purchases below 4 identical products")]
    public void Given_Below4IdenticalProducts_When_Calculated_Then_ShouldNotApplyDiscount()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        var sale = command.Map();

        sale.Id = Guid.NewGuid();

        sale.ClearProducts();
        var product = CreateSaleProductsHandlerTestData.GenerateSaleProductBelow4Identical();
        sale.AddProduct(product);

        // When
        sale.ApplyDiscountAmount();
        sale.ApplyTotalAmount();

        // Then
        Assert.Equal(300m, sale.TotalAmount);
    }

    /// <summary>
    /// Tests that validation fails when purchases above 20 identical products.
    /// </summary>
    [Fact(DisplayName = "Exception should be thrown for purchases above 20 identical products")]
    public void Given_Above20IdenticalProducts_When_Added_Then_ShouldThrowException()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        var sale = command.Map();

        sale.Id = Guid.NewGuid();

        sale.ClearProducts();
        var product = CreateSaleProductsHandlerTestData.GenerateSaleProductAbove20Identical();

        // When
        var act = () => sale.AddProduct(product);

        // Then
        act.Should().Throw<ValidationException>();  //ValidationErrors: Product's identical quantity not be more 20
    }

}
