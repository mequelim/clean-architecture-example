namespace CleanArchitectureMvc.Application.Products.Commands
{
    /// <summary>
    /// Represents a command used for updating an existing Product entity.
    /// </summary>
    /// <remarks>
    /// The <c>ProductUpdateCommand</c> class inherits from the <c>ProductCommand</c> base class  and adds an <c>Id</c> property, which is required to identify the specific product to be updated.
    /// This command is part of the application's command handling mechanism, leveraging the MediatR library to execute the corresponding update operation.
    /// </remarks>
    public abstract class ProductUpdateCommand : ProductCommand
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product to be updated.
        /// </summary>
        /// <remarks>
        /// The <c>Id</c> property is used to specify the unique identifier of the product that needs to be updated.
        /// It ensures that the update operation targets the correct product in the system.
        /// This property is a required field in the <c>ProductUpdateCommand</c>.
        /// </remarks>
        public int Id { get; set; }
    }
}