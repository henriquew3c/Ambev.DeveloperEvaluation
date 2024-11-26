using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Xunit;
using FluentAssertions;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the Product entity class.
    /// Tests cover status changes and validation scenarios.
    /// </summary>
    public class SaleTests
    {
        /// <summary>
        /// Tests that validation passes when all sale properties are valid.
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid data for creation sale")]
        public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var command = SaleTestData.GenerateValidCreateSaleCommand();

            // Act
            var result = command.Map();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.ValidationResult.Errors);
        }

        /// <summary>
        /// Tests that validation passes when all product properties are valid.
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid data for creation product")]
        public void Given_ValidSaleWithIProductsData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var command = SaleTestData.GenerateValidCreateSaleCommand();
            var products = SaleTestData.GenerateValidSaleProducts(3);

            // Act
            var sale = command.Map();
            products.ForEach(product => sale.AddProduct(product));


            // Assert
            Assert.True(sale.IsValid);
            Assert.Empty(sale.ValidationResult.Errors);
            Assert.True(sale.Products.Count == 1);
        }

        /// <summary>
        /// Tests that validation fails when quantity sale products exceeds the length limit (more than 20).
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid sale quantity products length")]
        public void Given_InvalidSaleProductsQuantityData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = SaleTestData.GenerateValidCreateSaleCommand();

            // Act
            var sale = command.Map();
            var saleProducts = SaleTestData.SaleProductInvalidFaker.Generate(5);

            // When
            var act = () => saleProducts.ForEach(product => sale.AddProduct(product));

            // Then
            act.Should().Throw<ValidationException>(); //Product's identical quantity not be more 20.
        }

        /// <summary>
        /// Tests that validation fails when sale properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid sale customer id data")]
        public void Given_InvalidSaleCustomerIdData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = new CreateSaleCommand()
            {
                CustomerId = "", // Invalid: empty
                BranchId = Guid.NewGuid().ToString(), // Valid
                Date = DateTime.MinValue, // Invalid: unrealistic
            };

            // When
            var act = () => command.Map();

            // Then
            act.Should().Throw<ValidationException>(); //Customer id is not valid. CustomerId is not a GUID.
        }
        
        /// <summary>
        /// Tests that validation fails when sale properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid sale branch id data on create")]
        public void Given_InvalidCreateSaleBranchIdData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = new CreateSaleCommand()
            {
                CustomerId = Guid.NewGuid().ToString(), // Valid
                BranchId = "", // Invalid: empty
                Date = DateTime.MinValue, // Invalid: unrealistic
            };

            // When
            var act = () => command.Map();

            // Then
            act.Should().Throw<ValidationException>(); //Branch id is not valid. BranchID is not a GUID.
        }
        
        /// <summary>
        /// Tests that validation fails when sale properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid sale customer id data on create")]
        public void Given_InvalidCreateSaleCustomerIdData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = new CreateSaleCommand()
            {
                CustomerId = "", // Invalid: empty
                BranchId = Guid.NewGuid().ToString(), // Valid
                Date = DateTime.MinValue, // Invalid: unrealistic
            };

            // When
            var act = () => command.Map();

            // Then
            act.Should().Throw<ValidationException>(); //Customer id is not valid. CustomerId is not a GUID.
        }
        
        /// <summary>
        /// Tests that validation fails when sale properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid sale branch id data on update")]
        public void Given_InvalidUpdateSaleBranchIdData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = new UpdateSaleCommand()
            {
                CustomerId = Guid.NewGuid().ToString(), // Valid
                BranchId = "", // Invalid: empty
                UpdateAt = DateTime.MinValue, // Invalid: unrealistic
            };

            // When
            var act = () => command.Map();

            // Then
            act.Should().Throw<ValidationException>(); //Branch id is not valid. BranchID is not a GUID.
        }
        
       /// <summary>
        /// Tests that validation fails when sale properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid sale customer id data on update")]
        public void Given_InvalidUpdateSaleCustomerIdData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = new UpdateSaleCommand()
            {
                BranchId = Guid.NewGuid().ToString(), // Valid
                CustomerId = "", // Invalid: empty
                UpdateAt = DateTime.MinValue, // Invalid: unrealistic
            };

            // When
            var act = () => command.Map();

            // Then
            act.Should().Throw<ValidationException>(); //Branch id is not valid. BranchID is not a GUID.
        }
       
        /// <summary>
        /// Tests that validation fails on update sale when sale properties are invalid.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid sale data")]
        public void Given_InvalidUpdateSaleData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = new UpdateSaleCommand()
            {
                CustomerId = Guid.NewGuid().ToString(), // Valid
                BranchId = Guid.NewGuid().ToString(), // Valid
                UpdateAt = DateTime.MinValue, // Invalid: unrealistic
            };

            // Act
            var result = command.Map();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.ValidationResult.Errors);
        }
    }
}
