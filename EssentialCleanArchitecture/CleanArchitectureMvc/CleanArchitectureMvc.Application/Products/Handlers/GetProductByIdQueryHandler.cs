using CleanArchitectureMvc.Application.Products.Queries;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Handlers;

/// <summary>
/// Handles queries for retrieving a product by its unique identifier.
/// </summary>
/// <remarks>
/// This handler is responsible for processing instances of <see cref="GetProductByIdQuery"/> to retrieve a <see cref="Product"/> entity
/// from the data source using the <see cref="IProductRepository"/>.
/// </remarks>
/// <exception cref="ArgumentNullException">Thrown when the <see cref="IProductRepository"/> instance is null.</exception>
/// <exception cref="KeyNotFoundException">Thrown when no product is found for the specified identifier.</exception>
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Handles the query to retrieve a product entity by its unique identifier.
    /// </summary>
    /// <remarks>
    /// This class processes the <see cref="GetProductByIdQuery"/> request to fetch product details based on the provided product ID.
    /// It interacts with the <see cref="IProductRepository"/> to retrieve the requested product data.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the product repository instance is null.</exception>
    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    //* Method...
    /// <summary>
    /// Handles the process of retrieving a product by its ID.
    /// </summary>
    /// <param name="request">The query request that contains the ID of the product to be retrieved.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>The product associated with the given ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the product with the specified ID is not found.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the product instance is null.</exception>
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(request.Id)
                          ?? throw new KeyNotFoundException("Product not found!");

        if(product is null) throw new ArgumentNullException(nameof(product), "The product instance cannot be null!");

        return product;
    }
}