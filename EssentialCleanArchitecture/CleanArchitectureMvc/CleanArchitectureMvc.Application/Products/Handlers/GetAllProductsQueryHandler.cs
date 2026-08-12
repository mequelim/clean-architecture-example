using CleanArchitectureMvc.Application.Products.Queries;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Handlers;

/// <summary>
/// Handles the processing of queries to retrieve all products.
/// </summary>
/// <remarks>
/// This class is responsible for handling the <see cref="GetAllProductsQuery"/> and fetching a collection of <see cref="Product"/> entities from the repository.
/// </remarks>
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Handles the query to retrieve a product entity by its unique identifier.
    /// </summary>
    /// <remarks>
    /// This class processes the <see cref="GetAllProductsQuery"/> request to fetch all product details.
    /// It interacts with the <see cref="IProductRepository"/> to retrieve the requested product data.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the product repository instance is null.</exception>
    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    //* Method...
    /// <summary>
    /// Handles the given query to retrieve all products from the repository.
    /// </summary>
    /// <param name="request">The query object representing the request to retrieve all products.</param>
    /// <param name="cancellationToken">A token that can be used to propagate notification that the operation should be canceled.</param>
    /// <returns>A task representing the asynchronous operation that contains a collection of products.</returns>
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken) => await _productRepository.GetAllAsync();
}