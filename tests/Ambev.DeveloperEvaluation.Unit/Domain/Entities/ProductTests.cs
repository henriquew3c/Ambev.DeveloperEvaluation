using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the Product entity class.
    /// Tests cover status changes and validation scenarios.
    /// </summary>
    public class ProductTests
    {
        /// <summary>
        /// Tests that validation passes when all product properties are valid.
        /// </summary>
        [Fact(DisplayName = "Validation should pass for valid data for creation product")]
        public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
        {
            // Arrange
            var command = ProductTestData.GenerateValidCreateProductCommand();

            // Act
            var result = command.Map();

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.ValidationResult.Errors);
        }

        /// <summary>
        /// Tests that validation fails when product name exceeds the minimum length limit.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid product name empty")]
        public void Given_InvalidProductNameEmptyData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = new CreateProductCommand()
            {
                Name = ProductTestData.GenerateEmptyProductName(), // Invalid: empty
                Price = ProductTestData.GenerateValidProductPrice() // Invalid: The price has been greater than 0 
            };

            // Act
            var result = command.Map();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.ValidationResult.Errors);
        }

        /// <summary>
        /// Tests that validation fails when product name exceeds the maximum length limit.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid product name long")]
        public void Given_InvalidProductNameLongData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = new CreateProductCommand()
            {
                Name = ProductTestData.GenerateLongProductName(), // Invalid: empty
                Price = ProductTestData.GenerateValidProductPrice() // Invalid: The price has been greater than 0 
            };

            // Act
            var result = command.Map();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.ValidationResult.Errors);
        }
        
        /// <summary>
        /// Tests that validation fails when product price exceeds the length limit.
        /// </summary>
        [Fact(DisplayName = "Validation should fail for invalid product price zero")]
        public void Given_InvalidProductNameData_When_Validated_Then_ShouldReturnInvalid()
        {
            // Arrange
            var command = new CreateProductCommand()
            {
                Name = ProductTestData.GenerateValidProductName(), // Valid: between 3 and 50 characters
                Price = ProductTestData.GenerateInvalidProductPrice() // Invalid: The price has been greater than 0 
            };

            // Act
            var result = command.Map();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.ValidationResult.Errors);
        }
    }
}
