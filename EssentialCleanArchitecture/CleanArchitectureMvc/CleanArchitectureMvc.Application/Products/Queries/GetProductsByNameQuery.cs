using CleanArchitectureMvc.Domain.Entities;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Queries;

/// <summary>
/// Represents a query that retrieves products based on their name.
/// </summary>
/// <remarks>
/// This class implements the MediatR IRequest interface and is used to encapsulate the data required to fetch a collection of <see cref="Product"/> entities matching a specified name.
/// </remarks>
public class GetProductsByNameQuery : IRequest<IEnumerable<Product>>
{
    /// <summary>
    /// Gets or sets the name parameter used to query products.
    /// </summary>
    /// <remarks>
    /// This property represents the name value used to filter the products.
    /// It serves as a key criterion for retrieving a collection of <see cref="Product"/> entities whose names match the specified value in the query.
    /// </remarks>
    public string Name { get; set; }

    /// <summary>
    /// Represents a query for retrieving products by their name.
    /// </summary>
    /// <remarks>
    /// This query is part of the application's query layer and is used to find a collection of <see cref="Product"/> entities whose names match a specified value.
    /// It serves as a data container passed to the MediatR pipeline.
    /// </remarks>
    public GetProductsByNameQuery(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
}