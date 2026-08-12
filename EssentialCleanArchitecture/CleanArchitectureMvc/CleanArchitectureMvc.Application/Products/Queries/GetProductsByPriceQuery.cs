using CleanArchitectureMvc.Domain.Entities;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Queries;

/// <summary>
/// Represents a query to retrieve products filtered by a specified price.
/// </summary>
/// <remarks>
/// This query is part of the application layer and is used to search for products in the system based on their price.
/// It implements the <see cref="IRequest{TResponse}"/> interface from MediatR, where the response is an enumerable collection of <see cref="Product"/> entities.
/// </remarks>
public class GetProductsByPriceQuery : IRequest<IEnumerable<Product>>
{
    /// <summary>
    /// Represents the monetary value or cost associated with a product or filtering criteria in queries.
    /// </summary>
    /// <remarks>
    /// In the context of a product, the <see cref="Product.Price"/> indicates the cost of that product in its respective currency.
    /// In the context of a query, such as <see cref="GetProductsByPriceQuery"/>, the Price is used as a filter to retrieve products that match or correspond to a specific monetary value.
    /// </remarks>
    public decimal Price { get; set; }

    /// <summary>
    /// Represents a query for retrieving products filtered by a specific price.
    /// </summary>
    /// <remarks>
    /// This query is used to fetch a collection of products whose price matches the specified value.
    /// It is implemented as a MediatR request and provides an enumerable collection of <see cref="Product"/> instances as the response.
    /// </remarks>
    public GetProductsByPriceQuery(decimal price) => Price = price;
}