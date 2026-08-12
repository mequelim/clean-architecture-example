using CleanArchitectureMvc.Application.Products.Queries;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Handlers;

/// <summary>
/// Handles the retrieval of products by their name.
/// </summary>
/// <remarks>
/// This class processes <see cref="GetProductsByNameQuery"/> requests and returns a collection of <see cref="Product"/> entities matching the specified name.
/// Implements the <see cref="IRequestHandler{TRequest, TResponse}"/> interface from MediatR.
/// </remarks>
public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Handles queries for retrieving products based on their name.
    /// </summary>
    /// <remarks>
    /// This class serves as the handler for <see cref="GetProductsByNameQuery"/>, managing the execution of the request and providing a collection of <see cref="Product"/> entities
    /// that match the specified product name.
    /// </remarks>
    public GetProductsByNameQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    //* Method...
    /// <summary>
    /// Handles the execution of the query to retrieve products by their name.
    /// </summary>
    /// <param name="request">The query request containing the product name to search for.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A collection of <see cref="Product"/> entities matching the specified name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="request"/> is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when no products are found for the specified name.</exception>
    public async Task<IEnumerable<Product>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
    {
        if(request is null) throw new ArgumentNullException(nameof(request), "The request cannot be null!");

        IEnumerable<Product> products = await _productRepository.GetByNameAsync(request.Name)
                                        ?? throw new KeyNotFoundException("No products found for the specified name!");

        if(products is null) throw new KeyNotFoundException("No products found for the specified name!");

        return products;
    }
}