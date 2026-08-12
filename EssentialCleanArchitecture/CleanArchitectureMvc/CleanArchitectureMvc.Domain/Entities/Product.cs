using CleanArchitectureMvc.Domain.Validations;

namespace CleanArchitectureMvc.Domain.Entities
{
    /// <summary>
    /// Represents a product entity in the domain model.
    /// </summary>
    /// <remarks>
    /// The <see cref="Product"/> class encapsulates the properties and behaviors of a product, including its name, description, price, stock quantity, and its association with a category.
    /// It inherits from the <see cref="EntityBase"/> class, which provides a unique identifier.
    /// </remarks>
    public sealed class Product : EntityBase
    {
        /// <summary>
        /// Gets the price of the product.
        /// </summary>
        /// <value>
        /// A <see cref="decimal"/> representing the cost of the product.
        /// </value>
        /// <remarks>
        /// The price is a crucial property that determines the monetary value of the product.
        /// </remarks>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets the current stock quantity of the product.
        /// </summary>
        /// <remarks>
        /// This property represents the available inventory for the product.
        /// It is used to track and manage the quantity of items in stock.
        /// </remarks>
        public int QuantityInStock { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified name, description, price, and stock quantity.
        /// </summary>
        /// <param name="name">The name of the product. Must be non-empty, at least 3 characters long, and no more than 100 characters.</param>
        /// <param name="description">The description of the product. Must be non-empty, at least 3 characters long, and no more than 500 characters.</param>
        /// <param name="price">The price of the product. Must be greater than zero.</param>
        /// <param name="quantityInStock">The stock quantity of the product. If less than zero, it will default to 0.</param>
        public Product(string name, string description, decimal price, int quantityInStock)
        {
            ValidateDomain(name, description, price);

            QuantityInStock = (quantityInStock < 0) ? 0 : quantityInStock;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified properties.
        /// </summary>
        /// <param name="id">The unique identifier for the product.</param>
        /// <param name="name">The name of the product.</param>
        /// <param name="description">The description of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="quantityInStock">The stock quantity of the product.</param>
        public Product(int id, string name, string description, decimal price, int quantityInStock)
        {
            ValidateDomain(name, description, price);
            DomainExceptionValidation.When((id <= 0), "Id must be greater than 0 (zero)!");

            Id = id;
            QuantityInStock = (quantityInStock < 0) ? 0 : quantityInStock;
        }

        /// <summary>
        /// Gets or sets the identifier of the associated <see cref="Category"/> entity.
        /// </summary>
        /// <remarks>
        /// This property represents the foreign key relationship between the <see cref="Product"/> entity
        /// and the <see cref="Category"/> entity. It is used to associate a product with a specific category.
        /// </remarks>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the associated <see cref="Category"/> entity for the product.
        /// </summary>
        /// <remarks>
        /// This property establishes a navigation property between the <see cref="Product"/> entity
        /// and its associated <see cref="Category"/> entity. It allows access to the details of the category
        /// to which the product belongs.
        /// </remarks>
        public Category? Category { get; set; }

        //* Methods...
        /// <summary>
        /// Validates the domain rules for the <see cref="Product"/> entity.
        /// </summary>
        /// <param name="name">
        /// The name of the product.
        /// Must be non-empty, at least 3 characters long, and no more than 100 characters.
        /// </param>
        /// <param name="description">
        /// The description of the product.
        /// Must be non-empty, at least 3 characters long, and no more than 500 characters.
        /// </param>
        /// <param name="price">
        /// The price of the product.
        /// Must be greater than zero.
        /// </param>
        private void ValidateDomain(string name, string description, decimal price)
        {
            // Name validations...
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required!");
            DomainExceptionValidation.When((name.Length < 3), " Name must be at least 3 characters long!");
            DomainExceptionValidation.When((name.Length > 100), "Name must be at most 100 characters long!");

            // Description validations...
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "Description is required!");
            DomainExceptionValidation.When((description.Length < 3), "Description must be at least 3 characters long!");
            DomainExceptionValidation.When((description.Length > 500), "Description must be at most 500 characters long!");

            // Price validations...
            DomainExceptionValidation.When((price <= 0), "Price must be greater than zero!");

            Name = name;
            Description = description;
            Price = price;
        }

        /// <summary>
        /// Updates the product's data with the provided values.
        /// </summary>
        /// <param name="name">
        /// The new name of the product. Must be non-empty, at least 3 characters long, and no more than 100 characters.
        /// </param>
        /// <param name="description">
        /// The new description of the product. Must be non-empty, at least 3 characters long, and no more than 500 characters.
        /// </param>
        /// <param name="price">
        /// The new price of the product. Must be greater than zero.
        /// </param>
        /// <param name="quantityInStock">
        /// The new stock quantity of the product. If the provided value is less than 0, it will default to 0.
        /// </param>
        /// <param name="categoryId">
        /// The identifier of the category to which the product belongs.
        /// </param>
        /// <remarks>
        /// This method validates the provided values against the domain rules before updating the product's data.
        /// </remarks>
        public void UpdateData(string name, string description, decimal price, int quantityInStock, int categoryId)
        {
            ValidateDomain(name, description, price);

            QuantityInStock = (quantityInStock < 0) ? 0 : quantityInStock;
            CategoryId = categoryId;
        }
    }
}