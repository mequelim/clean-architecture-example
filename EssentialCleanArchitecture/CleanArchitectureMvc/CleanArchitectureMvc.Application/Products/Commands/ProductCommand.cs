using CleanArchitectureMvc.Domain.Entities;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Commands
{
    /// <summary>
    /// Represents a command to manipulate or interact with Product data in the application layer.
    /// </summary>
    /// <remarks>
    /// This class is abstract because it is intended to be inherited by other command classes, that will implement specific product operations.
    /// This class serves as a base for specific command implementations related to the Product entity. It includes common properties.
    /// Commands inheriting from this class are used to encapsulate the data required to execute
    /// product-related operations via the MediatR library.
    /// </remarks>
    public abstract class ProductCommand : IRequest<Product>
    {
        /// <summary>
        /// Gets or sets the name of the product associated with the command.
        /// </summary>
        /// <remarks>
        /// This property represents the name of the product involved in the operation.
        /// It is a required property and must be set when using a command derived from the ProductCommand base class.
        /// </remarks>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the product associated with the command.
        /// </summary>
        /// <remarks>
        /// This property provides detailed information about the product involved in the command operation.
        /// It is a required property and must be specified when creating or modifying a product using a command derived from the ProductCommand base class.
        /// </remarks>
        public required string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product associated with the command.
        /// </summary>
        /// <remarks>
        /// This property represents the monetary cost of the product. It is used in product-related commands to define or update the product's price in the application layer.
        /// The value should be a valid decimal number reflecting the price in the configured currency.
        /// </remarks>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product available in stock.
        /// </summary>
        /// <remarks>
        /// This property represents the number of units available for a product in inventory.
        /// It is used for tracking stock levels and ensuring that sufficient stock is maintained for operations or customer orders.
        /// </remarks>
        public int QuantityInStock { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the category associated with the product command.
        /// </summary>
        /// <remarks>
        /// This property is used to define the relationship between a product and its category.
        /// It represents the unique identifier of the category to which the product belongs.
        /// The value must correspond to a valid category in the system.
        /// </remarks>
        public int CategoryId { get; set; }
    }
}