using CleanArchitectureMvc.Application.Products.Queries;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Handlers;

/// <summary>
/// Handles the query to retrieve a collection of products based on a specified category name.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IRequestHandler{TRequest, TResult}"/> interface to process the
/// <see cref="GetProductsByCategoryNameQuery"/> and return a collection of <see cref="Product"/> entities.
/// </remarks>
/// <seealso cref="GetProductsByCategoryNameQuery"/>
/// <seealso cref="Product"/>
public class GetProductsByCategoryNameQueryHandler : IRequestHandler<GetProductsByCategoryNameQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Handles queries to retrieve a collection of <see cref="Product"/> entities based on a specified category name.
    /// </summary>
    /// <remarks>
    /// This class processes <see cref="GetProductsByCategoryNameQuery"/> requests and retrieves a filtered collection
    /// of <see cref="Product"/> entities using the data provided by the <see cref="IProductRepository"/>.
    /// </remarks>
    /// <seealso cref="GetProductsByCategoryNameQuery"/>
    /// <seealso cref="Product"/>
    /// <seealso cref="IProductRepository"/>
    public GetProductsByCategoryNameQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    //* Method...
    /// <summary>
    /// Handles the specified request to retrieve a collection of <see cref="Product"/> entities based on the provided category name.
    /// </summary>
    /// <param name="request">The <see cref="GetProductsByCategoryNameQuery"/> containing the category name used to filter the products.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation, with a collection of <see cref="Product"/> entities that match the specified category name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided request is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when no products are found for the specified category name.</exception>
    public async Task<IEnumerable<Product>> Handle(GetProductsByCategoryNameQuery request, CancellationToken cancellationToken)
    {
        if(request is null) throw new ArgumentNullException(nameof(request), "The request cannot be null!");

        IEnumerable<Product> products = await _productRepository.GetByCategoryNameAsync(request.CategoryName)
                                        ?? throw new KeyNotFoundException("No products found for the specified name!");

        if(products is null) throw new KeyNotFoundException("No products found for the specified name!");

        return products;
    }
}