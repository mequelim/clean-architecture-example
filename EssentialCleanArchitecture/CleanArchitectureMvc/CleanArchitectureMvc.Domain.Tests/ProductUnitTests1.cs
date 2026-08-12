using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Validations;
using FluentAssertions;
using Xunit;

namespace CleanArchitectureMvc.Domain.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="Product"/> class in the domain layer.
    /// </summary>
    /// <remarks>
    /// The <see cref="ProductUnitTests1"/> class is designed to validate the behavior and state of the <see cref="Product"/> entity.
    /// It ensures that the <see cref="Product"/> class adheres to the expected domain rules and constraints.
    /// </remarks>
    public class ProductUnitTests1
    {
        /// <summary>
        /// Tests the creation of a <see cref="Product"/> object with valid parameters.
        /// </summary>
        /// <remarks>
        /// This test ensures that a <see cref="Product"/> instance can be successfully created when provided with valid input parameters.
        /// It verifies that no exceptions are thrown during the creation process and that the resulting object's state matches the expected values.
        /// </remarks>
        /// <example>
        /// The test validates the following:
        /// <list type="bullet">
        /// <item>Creation of a <see cref="Product"/> with valid parameters does not throw a <see cref="DomainExceptionValidation"/>.</item>
        /// <item>The resulting <see cref="Product"/> object has the expected property values.</item>
        /// </list>
        /// </example>
        [Fact(DisplayName = "Create a product with valid parameters.")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            // Arrange: defines a product creation action with valid parameters.
            Action action = () => new Product(1, "Product Name", "Product description...", 99.99m, 10);

            // Act & Assert: verifies that the creation does not throw a domain validation exception.
            action.Should().NotThrow<DomainExceptionValidation>();

            // Assert: validates the internal state of the created object.
            Product product = new(1, "Product Name", "Product description...", 99.99m, 10);

            product.Id.Should().Be(1);
            product.Name.Should().Be("Product Name");
            product.Description.Should().Be("Product description...");
            product.Price.Should().Be(99.99m);
            product.QuantityInStock.Should().Be(10);
        }

        /// <summary>
        /// Validates that creating a <see cref="Product"/> with a negative ID throws a <see cref="DomainExceptionValidation"/>.
        /// </summary>
        /// <remarks>
        /// This test ensures that the domain rule requiring the product ID to be greater than zero is enforced.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the product ID is less than or equal to zero.
        /// </exception>
        [Fact(DisplayName = "Create a product with negative id.")]
        public void CreateProduct_WithNegativeId_DomainExceptionValidation()
        {
            // Arrange: defines a product creation action with a negative ID.
            Action action = () => new Product(-1, "Product Name", "Product description...", 99.99m, 10);

            // Act & Assert: verifies that a domain validation exception is thrown.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Id must be greater than 0 (zero)!");
        }

        /// <summary>
        /// Validates that creating a <see cref="Product"/> with an empty name throws a <see cref="DomainExceptionValidation"/>.
        /// </summary>
        /// <remarks>
        /// This test ensures that the <see cref="Product"/> entity enforces the domain rule requiring a non-empty name.
        /// It verifies that a <see cref="DomainExceptionValidation"/> is thrown with the appropriate error message.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when attempting to create a <see cref="Product"/> with an empty name.
        /// </exception>
        [Fact(DisplayName = "Create a product with empty name.")]
        public void CreateProduct_WithEmptyName_DomainExceptionValidation()
        {
            // Arrange: defines a product creation action with an empty name.
            Action action = () => new Product(string.Empty, "Product description...", 99.99m, 10);

            // Act & Assert: verifies that a domain validation exception is thrown.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name is required!");
        }

        /// <summary>
        /// Validates the creation of a <see cref="Product"/> with a short name.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to create a <see cref="Product"/> with a name shorter than the minimum required length results in a <see cref="DomainExceptionValidation"/> being thrown.
        /// The exception message should indicate that the name must be at least 3 characters long.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the <see cref="Product"/> name does not meet the minimum length requirement.
        /// </exception>
        [Fact(DisplayName = "Create a product with short name.")]
        public void CreateProduct_WithShortName_DomainExceptionValidation()
        {
            // Arrange: defines a product creation action with a short name.
            Action action = () => new Product("AB", "Product description...", 99.99m, 10);

            // Act & Assert: verifies that a domain validation exception is thrown.
            action.Should().Throw<DomainExceptionValidation>().WithMessage(" Name must be at least 3 characters long!");
        }

        /// <summary>
        /// Validates the creation of a <see cref="Product"/> with a name exceeding the maximum allowed length.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to create a <see cref="Product"/> with a name longer than 100 characters results in a <see cref="DomainExceptionValidation"/> being thrown,
        /// with an appropriate error message.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the name of the <see cref="Product"/> exceeds 100 characters.
        /// </exception>
        [Fact(DisplayName = "Create a product with long name.")]
        public void CreateProduct_WithLongName_DomainExceptionValidation()
        {
            // Arrange: defines a product creation action with a name longer than 100 characters.
            Action action = () => new Product(new string('A', 101), "Product description...", 99.99m, 10);

            // Act & Assert: verifies that a domain validation exception is thrown.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name must be at most 100 characters long!");
        }

        /// <summary>
        /// Tests the creation of a <see cref="Product"/> with an empty description.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to create a <see cref="Product"/> with an empty description results in a <see cref="DomainExceptionValidation"/> being thrown.
        /// This validates the domain rule that a product description is required.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the description is empty, with the message "Description is required!".
        /// </exception>
        [Fact(DisplayName = "Create a product with empty description.")]
        public void CreateProduct_WithEmptyDescription_DomainExceptionValidation()
        {
            // Arrange: defines a product creation action with an empty description.
            Action action = () => new Product("Product Name", string.Empty, 99.99m, 10);

            // Act & Assert: verifies that a domain validation exception is thrown.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description is required!");
        }

        /// <summary>
        /// Validates the creation of a <see cref="Product"/> with a short description.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to create a <see cref="Product"/> with a description
        /// shorter than the minimum allowed length triggers a <see cref="DomainExceptionValidation"/>.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the description length is less than the required minimum (e.g., less than 3 characters).
        /// </exception>
        [Fact(DisplayName = "Create a product with short description.")]
        public void CreateProduct_WithShortDescription_DomainExceptionValidation()
        {
            // Arrange: defines a product creation action with a short description.
            Action action = () => new Product("Product Name", "AB", 99.99m, 10);

            // Act & Assert: verifies that a domain validation exception is thrown.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description must be at least 3 characters long!");
        }

        /// <summary>
        /// Validates the creation of a <see cref="Product"/> with a description exceeding the maximum allowed length.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to create a <see cref="Product"/> with a description longer than 500 characters
        /// throws a <see cref="DomainExceptionValidation"/> with an appropriate error message.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the description exceeds 500 characters.
        /// </exception>
        [Fact(DisplayName = "Create a product with long description.")]
        public void CreateProduct_WithLongDescription_DomainExceptionValidation()
        {
            // Arrange: defines a product creation action with a description longer than 500 characters.
            Action action = () => new Product("Product Name", new string('A', 501), 99.99m, 10);

            // Act & Assert: verifies that a domain validation exception is thrown.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description must be at most 500 characters long!");
        }

        /// <summary>
        /// Validates the creation of a <see cref="Product"/> with an invalid price.
        /// </summary>
        /// <remarks>
        /// This test ensures that attempting to create a <see cref="Product"/> with a price of zero or a negative value results in a <see cref="DomainExceptionValidation"/> being thrown.
        /// The exception message is expected to indicate that the price must be greater than zero.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the price of the <see cref="Product"/> is zero or negative.
        /// </exception>
        [Fact(DisplayName = "Create a product with zero or negative price.")]
        public void CreateProduct_WithInvalidPrice_DomainExceptionValidation()
        {
            // Arrange: defines product creation actions with invalid prices.
            Action action1 = () => new Product("Product Name", "Product description...", 0m, 10);
            Action action2 = () => new Product("Product Name", "Product description...", -10m, 10);

            // Act & Assert: verifies that both actions throw a domain validation exception.
            action1.Should().Throw<DomainExceptionValidation>().WithMessage("Price must be greater than zero!");
            action2.Should().Throw<DomainExceptionValidation>().WithMessage("Price must be greater than zero!");
        }

        /// <summary>
        /// Validates the behavior of creating a <see cref="Product"/> with a negative stock quantity.
        /// </summary>
        /// <remarks>
        /// This test ensures that when a <see cref="Product"/> is created with a negative stock quantity,
        /// the <see cref="Product.QuantityInStock"/> property is automatically set to zero, adhering to domain rules.
        /// </remarks>
        [Fact(DisplayName = "Create a product with negative stock quantity.")]
        public void CreateProduct_WithNegativeStock_StockShouldBeZero()
        {
            // Arrange: defines a product creation action with negative stock quantity.
            Product product = new("Product Name", "Product description...", 99.99m, -5);

            // Assert: verifies that the quantity in stock is set to zero.
            product.QuantityInStock.Should().Be(0);
        }

        /// <summary>
        /// Validates the behavior of updating a <see cref="Product"/> entity with valid data.
        /// </summary>
        /// <remarks>
        /// This test ensures that the <see cref="Product.UpdateData"/> method correctly updates the product's properties when provided with valid input values.
        /// It verifies that the updated state of the product matches the expected values.
        /// </remarks>
        /// <example>
        /// The test performs the following steps:
        /// <list type="number">
        /// <item>Creates a <see cref="Product"/> instance with valid initial data.</item>
        /// <item>Updates the product using the <see cref="Product.UpdateData"/> method with valid new data.</item>
        /// <item>Asserts that the product's state reflects the updated values.</item>
        /// </list>
        /// </example>
        [Fact(DisplayName = "Update a product with valid data.")]
        public void UpdateProduct_WithValidData_ResultObjectValidState()
        {
            // Arrange: creates a product with valid initial state.
            var product = new Product(1, "Product Name", "Product description...", 99.99m, 10);

            // Act: updates the product with valid new data.
            product.UpdateData("Updated Name", "Updated description...", 199.99m, 20, 2);

            // Assert: verifies updated state.
            product.Name.Should().Be("Updated Name");
            product.Description.Should().Be("Updated description...");
            product.Price.Should().Be(199.99m);
            product.QuantityInStock.Should().Be(20);
            product.CategoryId.Should().Be(2);
        }

        /// <summary>
        /// Validates the behavior of updating a <see cref="Product"/> with an invalid name.
        /// </summary>
        /// <remarks>
        /// This test ensures that the <see cref="Product.UpdateData"/> method throws a 
        /// <see cref="DomainExceptionValidation"/> when the provided name is shorter than the minimum required length.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the name is less than 3 characters long.
        /// </exception>
        [Fact(DisplayName = "Update a product with invalid name.")]
        public void UpdateProduct_WithInvalidName_DomainExceptionValidation()
        {
            // Arrange: creates a product.
            var product = new Product(1, "Product Name", "Product description...", 99.99m, 10);

            // Act: defines an update action with an invalid name.
            Action action = () => product.UpdateData("AB", "Valid description...", 199.99m, 20, 2);

            // Assert: verifies exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage(" Name must be at least 3 characters long!");
        }

        /// <summary>
        /// Validates that updating a product with an invalid description throws a <see cref="DomainExceptionValidation"/>.
        /// </summary>
        /// <remarks>
        /// This test ensures that the <see cref="Product.UpdateData"/> method enforces the domain rule requiring
        /// the description to have a minimum length of 3 characters.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the description is shorter than the required minimum length.
        /// </exception>
        [Fact(DisplayName = "Update a product with invalid description.")]
        public void UpdateProduct_WithInvalidDescription_DomainExceptionValidation()
        {
            // Arrange: creates a product.
            var product = new Product(1, "Product Name", "Product description...", 99.99m, 10);

            // Act: defines an update action with an invalid description.
            Action action = () => product.UpdateData("Valid Name", "AB", 199.99m, 20, 2);

            // Assert: verifies exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description must be at least 3 characters long!");
        }

        /// <summary>
        /// Validates that updating a product with an invalid price throws a <see cref="DomainExceptionValidation"/>.
        /// </summary>
        /// <remarks>
        /// This test ensures that the <see cref="Product.UpdateData"/> method enforces the domain rule requiring the price to be greater than zero.
        /// An exception is expected when the price is invalid.
        /// </remarks>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when the price is zero or negative, violating the domain constraint.
        /// </exception>
        [Fact(DisplayName = "Update a product with invalid price.")]
        public void UpdateProduct_WithInvalidPrice_DomainExceptionValidation()
        {
            // Arrange: creates a product.
            var product = new Product(1, "Product Name", "Product description...", 99.99m, 10);

            // Act: defines an update action with a zero price.
            Action action = () => product.UpdateData("Valid Name", "Valid description...", 0m, 20, 2);

            // Assert: verifies exception.
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Price must be greater than zero!");
        }
    }
}