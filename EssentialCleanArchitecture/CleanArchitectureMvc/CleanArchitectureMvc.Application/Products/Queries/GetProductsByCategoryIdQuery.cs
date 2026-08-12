using CleanArchitectureMvc.Domain.Entities;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Queries;

/// <summary>
/// Query object for retrieving a list of products based on the specified category ID.
/// </summary>
/// <remarks>
/// This query is used to retrieve an enumerable collection of <see cref="Product"/> objects associated with a specific category identifier.
/// Implements the MediatR <see cref="IRequest{TResponse}"/> interface.
/// </remarks>
public class GetProductsByCategoryIdQuery : IRequest<IEnumerable<Product>>
{
    /// <summary>
    /// Gets or sets the identifier of the category associated with the query or entity.
    /// </summary>
    /// <remarks>
    /// This property is used to specify or retrieve the unique identifier of a category to filter or associating related data such as products in the application.
    /// </remarks>
    public int CategoryId { get; set; }

    /// <summary>
    /// Represents a query to retrieve a collection of products belonging to a specific category.
    /// </summary>
    /// <remarks>
    /// This query is part of the application layer and is used for fetching products associated with a given category ID.
    /// It implements the MediatR IRequest interface to support the mediator pattern for handling requests and responses.
    /// </remarks>
    public GetProductsByCategoryIdQuery(int categoryId) => CategoryId = categoryId;
}