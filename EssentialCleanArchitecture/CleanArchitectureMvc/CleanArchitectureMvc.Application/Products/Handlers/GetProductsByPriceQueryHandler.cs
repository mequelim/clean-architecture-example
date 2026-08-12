using CleanArchitectureMvc.Application.Products.Queries;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Handlers;

/// <summary>
/// Handles the query to retrieve products filtered by a specified price.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IRequestHandler{TRequest, TResponse}"/> interface from MediatR,
/// where the request is of type <see cref="GetProductsByPriceQuery"/> and the response is an enumerable collection of <see cref="Product"/>.
/// The handler leverages an instance of <see cref="IProductRepository"/> to fetch data based on the query criteria.
/// </remarks>
public class GetProductsByPriceQueryHandler : IRequestHandler<GetProductsByPriceQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Handles the processing of GetProductsByPriceQuery to retrieve products filtered by the specified price.
    /// </summary>
    /// <remarks>
    /// Implements the MediatR IRequestHandler interface to process queries of type GetProductsByPriceQuery.
    /// Uses the IProductRepository to fetch products based on the price criteria provided in the query.
    /// </remarks>
    public GetProductsByPriceQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    //* Method...
    /// <summary>
    /// Processes the GetProductsByPriceQuery to fetch a collection of products filtered by the specified price criteria.
    /// </summary>
    /// <param name="request">The query object containing the price parameter used to filter the products.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to signal the asynchronous operation to cancel.</param>
    /// <returns>A collection of products whose price satisfies the given criteria.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided query object is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when no products are found matching the specified price criteria.</exception>
    public async Task<IEnumerable<Product>> Handle(GetProductsByPriceQuery request, CancellationToken cancellationToken)
    {
        if(request is null) throw new ArgumentNullException(nameof(request), "The request cannot be null!");

        IEnumerable<Product> products = await _productRepository.GetByPriceAsync(request.Price)
                                        ?? throw new KeyNotFoundException("No products found for the specified price!");

        if(products is null) throw new KeyNotFoundException("No products found for the specified price!");

        return products;
    }
}