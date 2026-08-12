using CleanArchitectureMvc.Application.Products.Queries;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Handlers;

/// <summary>
/// Handles the processing of the <see cref="GetProductsByCategoryIdQuery"/> query to return a collection of products filtered by a specific category ID.
/// </summary>
/// <remarks>
/// This handler is part of the Clean Architecture implementation for the application and works within the MediatR library to process the query object.
/// It interacts with the <see cref="IProductRepository"/> to fetch the required data.
/// </remarks>
/// <example>
/// The handler executes the query and retrieves a collection of <see cref="Product"/> entities matching the criteria set in the <see cref="GetProductsByCategoryIdQuery"/> query object.
/// </example>
public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// A query handler that processes the <see cref="GetProductsByCategoryIdQuery"/> query.
    /// </summary>
    /// <remarks>
    /// This handler is responsible for fetching all products that belong to a specific category by interacting with the <see cref="IProductRepository"/>.
    /// </remarks>
    public GetProductsByCategoryIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    //* Method...
    /// <summary>
    /// Handles the processing of the <see cref="GetProductsByCategoryIdQuery"/> query.
    /// </summary>
    /// <param name="request">The query object containing the category ID.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to observe cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of <see cref="Product"/> entities that belong to the specified category.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when no products are found for the specified category ID.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the product collection is null.</exception>
    public async Task<IEnumerable<Product>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products = await _productRepository.GetByCategoryIdAsync(request.CategoryId)
                                        ?? throw new KeyNotFoundException("No products found for the specified category ID!");

        if(products is null) throw new ArgumentNullException(nameof(products), "The product collection cannot be null!");

        return products;
    }
}