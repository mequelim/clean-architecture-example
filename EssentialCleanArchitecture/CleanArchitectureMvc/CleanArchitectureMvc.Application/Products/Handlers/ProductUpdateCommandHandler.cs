using CleanArchitectureMvc.Application.Products.Commands;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Handlers;

/// <summary>
/// Handles product update operations by processing <see cref="ProductUpdateCommand"/> and interacting with the <see cref="IProductRepository"/>.
/// </summary>
/// <remarks>
/// The <see cref="ProductUpdateCommandHandler"/> class is responsible for fetching a specific <see cref="Product"/> entity by its identifier,
/// applying updates to its properties, and saving the changes in the data store by leveraging the <see cref="IProductRepository"/> interface.
/// </remarks>
public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Handles product update commands by processing <see cref="ProductUpdateCommand"/> and utilizing the <see cref="IProductRepository"/> for persistence operations.
    /// </summary>
    /// <remarks>
    /// The <see cref="ProductUpdateCommandHandler"/> ensures the retrieval of the target <see cref="Product"/> from the data source,
    /// modifies its properties based on the supplied command data, and saves the updated entity back to the repository.
    /// It also ensures proper exception handling during the operation.
    /// </remarks>
    public ProductUpdateCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    //* Method...
    /// <summary>
    /// Processes the <see cref="ProductUpdateCommand"/> to update an existing <see cref="Product"/> entity in the repository.
    /// </summary>
    /// <param name="request">The update command containing the product ID and details to be updated.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="Product"/>.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the product with the specified ID does not exist in the repository.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the created product instance is null.</exception>
    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Product not found!");

        if(product is null) throw new ArgumentNullException(nameof(product), "The created product instance cannot be null!");

        product.UpdateData(request.Name, request.Description, request.Price, request.QuantityInStock, request.CategoryId);

        return await _productRepository.UpdateAsync(product);
    }
}