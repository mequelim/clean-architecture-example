using CleanArchitectureMvc.Application.Products.Commands;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Handlers;

/// <summary>
/// Handles the removal of a product in the system by processing the <see cref="ProductRemoveCommand"/>.
/// </summary>
/// <remarks>
/// This class interacts with the repository layer to fetch and remove a product entity using its identifier.
/// If the product is found and successfully deleted, it returns the deleted product entity.
/// </remarks>
public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Handles the command for removing a product from the system.
    /// </summary>
    /// <remarks>
    /// This handler processes <see cref="ProductRemoveCommand"/> to remove a product from the underlying data store.
    /// It uses the <see cref="IProductRepository"/> to retrieve and delete the product by its identifier.
    /// The class ensures that if a product exists, it is removed and returns the removed product entity.
    /// </remarks>
    public ProductRemoveCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    //* Method...
    /// <summary>
    /// Handles the removal of a product based on the provided command.
    /// </summary>
    /// <param name="request">The command containing the identifier of the product to be removed.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The deleted product entity.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the product with the specified identifier is not found.</exception>
    /// <exception cref="ArgumentNullException">Thrown if the product instance is null.</exception>
    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Product not found!");

        if(product is null) throw new ArgumentNullException(nameof(product), "The created product instance cannot be null!");

        Product result = await _productRepository.DeleteAsync(product.Id)
                         ?? throw new KeyNotFoundException("Product not found!");

        return result;
    }
}