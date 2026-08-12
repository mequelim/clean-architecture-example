using CleanArchitectureMvc.Domain.Entities;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Commands
{
    /// <summary>
    /// Command to remove a product entity from the system by its identifier.
    /// </summary>
    /// <remarks>
    /// This command encapsulates the data required to remove a product from the database, primarily the product's unique identifier.
    /// It is used within the application's MediatR pipeline to handle product removal requests.
    /// TO remove a product, an instance of this command is created with the product's ID, and it is sent through the MediatR mediator for processing.
    /// </remarks>
    public class ProductRemoveCommand : IRequest<Product>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product removal command.
        /// </summary>
        /// <remarks>
        /// This identifier specifies which product entity should be removed from the system. It is required to effectively execute the
        /// <see cref="ProductRemoveCommand"/> through the application's MediatR pipeline.
        /// </remarks>
        public int Id { get; set; }

        /// <summary>
        /// Represents a command to remove a product from the system using its identifier.
        /// </summary>
        /// <remarks>
        /// This command is part of the application layer and facilitates the removal of products by encapsulating the product's unique identifier.
        /// It is used by the MediatR pipeline for processing.
        /// </remarks>
        public ProductRemoveCommand(int id) => Id = id;
    }
}