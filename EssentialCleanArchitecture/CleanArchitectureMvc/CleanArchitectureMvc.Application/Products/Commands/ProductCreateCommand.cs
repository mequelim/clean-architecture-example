namespace CleanArchitectureMvc.Application.Products.Commands
{
    /// <summary>
    /// Represents the command to create a new Product in the application.
    /// </summary>
    /// <remarks>
    /// This command inherits from the <see cref="ProductCommand"/> class and is used to encapsulate the data required to create a new Product entity.
    /// It includes properties, which are used during the creation process.
    /// </remarks>
    /// <seealso cref="ProductCommand"/>
    public class ProductCreateCommand : ProductCommand { }
}