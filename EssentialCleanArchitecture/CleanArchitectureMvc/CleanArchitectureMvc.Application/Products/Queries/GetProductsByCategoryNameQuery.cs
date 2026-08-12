using CleanArchitectureMvc.Domain.Entities;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Queries;

/// <summary>
/// Represents a query to retrieve a collection of products based on a specified category name.
/// </summary>
/// <remarks>
/// This query is used to fetch all products that match the given category.
/// It implements the <see cref="IRequest{TResult}"/> interface to work within a MediatR-based request pipeline,
/// where the result is a collection of <see cref="Product"/> entities.
/// </remarks>
public class GetProductsByCategoryNameQuery : IRequest<IEnumerable<Product>>
{
    /// <summary>
    /// Gets or sets the name of the category used to filter products in queries.
    /// </summary>
    /// <remarks>
    /// The category name serves as a parameter to retrieve products associated with a specific category.
    /// It is utilized in the context of queries that require filtering by category.
    /// </remarks>
    public string CategoryName { get; set; }

    /// <summary>
    /// Represents a query to retrieve a collection of products filtered by a specified category name.
    /// </summary>
    /// <remarks>
    /// This class is leveraged in a MediatR pipeline as a request to fetch all products belonging to a particular category.
    /// The result of this query is an enumerable collection of <see cref="Product"/> entities.
    /// </remarks>
    public GetProductsByCategoryNameQuery(string categoryName) => CategoryName = categoryName ?? throw new ArgumentNullException(nameof(categoryName));
}